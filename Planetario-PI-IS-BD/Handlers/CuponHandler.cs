using System;
using System.Data.SqlClient;
using Planetario.Models;
using System.Data;

namespace Planetario.Handlers {
  public class CuponHandler : BaseDeDatosHandler {

    public CuponModel ObtenerCupon(String codigoCupon) {
      String consulta = "SELECT * FROM Cupon WHERE codigoCuponPK = @codigoCupon";
      SqlCommand comandoParaConsulta = new SqlCommand(consulta, ConexionPlanetario);
      comandoParaConsulta.Parameters.AddWithValue("@codigoCupon", codigoCupon);
      DataTable filaCupon = CrearTablaConsulta(comandoParaConsulta);
      CuponModel cupon;
      if (filaCupon.Rows.Count == 0) {
        cupon = new CuponModel {
          Codigo = "0"
        };
      } else {
        DataRow filaCuponResultado = filaCupon.Rows[0];
        cupon = CrearCupon(filaCuponResultado);
      }
      return cupon;
    }


    private CuponModel CrearCupon(DataRow filaCupon) {
      String codigoCupon = filaCupon["codigoCuponPK"].ToString();
      double descuentoRelativo = Convert.ToDouble(filaCupon["descuento"]);
      int usosMaximos = Convert.ToInt32(filaCupon["usosMaximos"]);
      return new CuponModel(codigoCupon, descuentoRelativo, usosMaximos);
    }

    public void UsarCuponCompra(String codigoCupon, String numeroIdentificacionComprador, SqlTransaction transaccion = null) {
      if (VisitanteUsoCupon(codigoCupon, numeroIdentificacionComprador, transaccion)) {
        ActualizarUsosCupon(codigoCupon, numeroIdentificacionComprador, transaccion);
      } else {
        AgregarPrimerUsoCupon(codigoCupon, numeroIdentificacionComprador, transaccion);
      }
    }

    public bool VisitanteUsoCupon(String codigoCupon, String numeroIdentificacionComprador, SqlTransaction transaccion = null) {
      String consulta = "SELECT * FROM UsaCupon WHERE codigoCuponFK = @codigoCupon AND numeroIdentificacionFK = @numeroIdentificacion";
      SqlCommand comandoParaConsulta;
      if (transaccion == null) {
        comandoParaConsulta = new SqlCommand(consulta, ConexionPlanetario);
      } else {
        comandoParaConsulta = new SqlCommand(consulta, ConexionPlanetario, transaccion);
      }
      comandoParaConsulta.Parameters.AddWithValue("@codigoCupon", codigoCupon);
      comandoParaConsulta.Parameters.AddWithValue("@numeroIdentificacion", numeroIdentificacionComprador);
      return CrearTablaConsulta(comandoParaConsulta).Rows.Count > 0;
    }

    private void ActualizarUsosCupon(String codigoCupon, String numeroIdentificacionComprador, SqlTransaction transaccion) {
      String consulta = "UPDATE UsaCupon SET usosRestantes = usosRestantes-1 WHERE codigoCuponFK = @codigoCupon AND numeroIdentificacionFK = @numeroIdentificacion";
      SqlCommand comandoParaConsulta;
      bool switchear = ConexionPlanetario.State == ConnectionState.Closed;
      if (transaccion == null) {
        comandoParaConsulta = new SqlCommand(consulta, ConexionPlanetario);
      } else {
        comandoParaConsulta = new SqlCommand(consulta, ConexionPlanetario, transaccion);
      }
      comandoParaConsulta.Parameters.AddWithValue("@codigoCupon", codigoCupon);
      comandoParaConsulta.Parameters.AddWithValue("@numeroIdentificacion", numeroIdentificacionComprador);
      if (switchear) ConexionPlanetario.Open();
      comandoParaConsulta.ExecuteNonQuery();
      if (switchear) ConexionPlanetario.Close();
    }

    private void AgregarPrimerUsoCupon(String codigoCupon, String numeroIdentificacionComprador, SqlTransaction transaccion = null) {
      CuponModel cupon = ObtenerCupon(codigoCupon);
      String consulta = "INSERT INTO UsaCupon VALUES (@codigoCupon,@numeroIdentificacion,@usosMaximos-1)";
      SqlCommand comandoParaConsulta;
      bool switchear = ConexionPlanetario.State == ConnectionState.Closed;
      if (transaccion == null) {
        comandoParaConsulta = new SqlCommand(consulta, ConexionPlanetario);
      } else {
        comandoParaConsulta = new SqlCommand(consulta, ConexionPlanetario, transaccion);
      }
      comandoParaConsulta.Parameters.AddWithValue("@codigoCupon", codigoCupon);
      comandoParaConsulta.Parameters.AddWithValue("@numeroIdentificacion", numeroIdentificacionComprador);
      comandoParaConsulta.Parameters.AddWithValue("@usosMaximos", cupon.UsosMaximos);
      if (switchear) ConexionPlanetario.Open();
      comandoParaConsulta.ExecuteNonQuery();
      if (switchear) ConexionPlanetario.Close();
    }

    public bool EsCuponAplicable(String codigoCupon, String numeroIdentificacionComprador) {
      String consulta = "SELECT * FROM UsaCupon WHERE codigoCuponFK = @codigoCupon AND numeroIdentificacionFK = @numeroIdentificacion AND usosRestantes > 0";
      SqlCommand comandoParaConsulta = new SqlCommand(consulta, ConexionPlanetario);
      comandoParaConsulta.Parameters.AddWithValue("@codigoCupon", codigoCupon);
      comandoParaConsulta.Parameters.AddWithValue("@numeroIdentificacion", numeroIdentificacionComprador);
      return CrearTablaConsulta(comandoParaConsulta).Rows.Count > 0;
    }

  }
}