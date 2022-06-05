using System;
using System.Collections.Generic;
using Planetario.Models;
using System.Data.SqlClient;
using System.Data;

namespace Planetario.Handlers {
  public class CompraProductosHandler : BaseDeDatosHandler {


    public CompraProductosHandler() {

    }

    public void ActualizarTablasCompra(ResumenCompraProductosModel resumenDeCompra, String numeroIdentificacionComprador) {
      ConexionPlanetario.Open();
      SqlTransaction transaccion = ConexionPlanetario.BeginTransaction(IsolationLevel.RepeatableRead);
      try {
        ActualizarTablaProductos(resumenDeCompra, transaccion);
        CrearFactura(resumenDeCompra, numeroIdentificacionComprador, transaccion);
        transaccion.Commit();
        ConexionPlanetario.Close();
      }
      catch (Exception) {
        ConexionPlanetario.Close();
      }
    }

    private bool ActualizarTablaProductos(ResumenCompraProductosModel resumenDeCompra, SqlTransaction transaccion = null) {
      ProductoHandler productoHandler = new ProductoHandler();
      bool exitoActualizar = true;
      foreach (KeyValuePair<String, int> elementoCarrito in resumenDeCompra.Carrito.ProductosEnCarrito) {
        ProductoModel productoComprado = productoHandler.ObtenerProductoModel(elementoCarrito.Key);
        int cantidadComprada = elementoCarrito.Value;
        SqlCommand comandoParaConsulta = GenerarComandoParaRestarUnidades(cantidadComprada, productoComprado.IdentificadorProducto, transaccion);
        exitoActualizar = comandoParaConsulta.ExecuteNonQuery() >= 1;
      }
      return exitoActualizar;
    }

    private SqlCommand GenerarComandoParaRestarUnidades(int cantidadComprada, String idProducto, SqlTransaction transaccion = null) {
      String consulta = "UPDATE Producto SET unidadesDisponibles = unidadesDisponibles - @unidadesCompradas " +
          "WHERE idProductoPK = @idProducto";
      SqlCommand comandoParaConsulta;
      if (transaccion == null) {
        comandoParaConsulta = new SqlCommand(consulta, ConexionPlanetario);
      } else {
        comandoParaConsulta = new SqlCommand(consulta, ConexionPlanetario, transaccion);
      }
      comandoParaConsulta.Parameters.AddWithValue("@unidadesCompradas", cantidadComprada);
      comandoParaConsulta.Parameters.AddWithValue("@idProducto", idProducto);
      return comandoParaConsulta;
    }



    private void CrearFactura(ResumenCompraProductosModel resumenDeCompra, String numeroIdentificacionComprador, SqlTransaction transaccion = null) {
      DateTime fechaDeCompra = DateTime.Now;
      String consulta = "INSERT INTO Factura(fechaCompraPK,numeroIdentificacionVisitanteFK, subTotal, impuesto, total) " +
        "VALUES(@fechaDeCompra, @numeroIdentificacionComprador, @subTotal, @impuesto, @total)";
      SqlCommand comandoParaConsulta;
      bool switchear = ConexionPlanetario.State == ConnectionState.Closed;
      if (transaccion == null) {
        comandoParaConsulta = new SqlCommand(consulta, ConexionPlanetario);
      } else {
        comandoParaConsulta = new SqlCommand(consulta, ConexionPlanetario, transaccion);
      }
      comandoParaConsulta.Parameters.AddWithValue("@fechaDeCompra", fechaDeCompra);
      comandoParaConsulta.Parameters.AddWithValue("@numeroIdentificacionComprador", numeroIdentificacionComprador);
      comandoParaConsulta.Parameters.AddWithValue("@subTotal", resumenDeCompra.SubTotal);
      comandoParaConsulta.Parameters.AddWithValue("@impuesto", resumenDeCompra.Impuestos);
      comandoParaConsulta.Parameters.AddWithValue("@total", resumenDeCompra.PrecioTotal);
      if (switchear) ConexionPlanetario.Open();
      comandoParaConsulta.ExecuteNonQuery();
      if (switchear) ConexionPlanetario.Close();
      CrearDetallesFactura(fechaDeCompra, numeroIdentificacionComprador, resumenDeCompra, transaccion);
    }

    private bool CrearDetallesFactura(DateTime fechaDeCompra, String numeroIdentificacionComprador, ResumenCompraProductosModel resumenDeCompra, SqlTransaction transaccion = null) {
      bool exitoActualizar = true;
      ProductoHandler productoHandler = new ProductoHandler(ConexionPlanetario);
      bool switchear = ConexionPlanetario.State == System.Data.ConnectionState.Closed;
      if (switchear) ConexionPlanetario.Open();
      foreach (KeyValuePair<string, int> elementoCarrito in resumenDeCompra.Carrito.ProductosEnCarrito) {
        ProductoModel productoComprado = productoHandler.ObtenerProductoModel(elementoCarrito.Key, transaccion);
        int cantidadComprada = elementoCarrito.Value;
        SqlCommand comandoParaConsulta = GenerarComandoParaDetalleFactura(productoComprado, fechaDeCompra, numeroIdentificacionComprador, cantidadComprada, transaccion);
        exitoActualizar = comandoParaConsulta.ExecuteNonQuery() >= 1;
        if (!exitoActualizar) {
          if (switchear) ConexionPlanetario.Close();
          return exitoActualizar;
        }
      }
      if (switchear) ConexionPlanetario.Close();
      return exitoActualizar;
    }

    private SqlCommand GenerarComandoParaDetalleFactura(ProductoModel productoComprado, DateTime fechaDeCompra,
                                                        String numeroIdentificacionComprador, int cantidadComprada, SqlTransaction transaccion = null) {
      String consulta = "INSERT INTO DetalleFactura VALUES(@fechaDeCompra, @numeroIdVisitante, @idProducto, @cantidadComprada, @precioTotalProducto)";
      SqlCommand comandoParaConsulta;
      if (transaccion == null) {
        comandoParaConsulta = new SqlCommand(consulta, ConexionPlanetario);
      } else {
        comandoParaConsulta = new SqlCommand(consulta, ConexionPlanetario, transaccion);
      }
      comandoParaConsulta.Parameters.AddWithValue("@fechaDeCompra", fechaDeCompra);
      comandoParaConsulta.Parameters.AddWithValue("@numeroIdVisitante", numeroIdentificacionComprador);
      comandoParaConsulta.Parameters.AddWithValue("@idProducto", productoComprado.IdentificadorProducto);
      comandoParaConsulta.Parameters.AddWithValue("@cantidadComprada", cantidadComprada);
      comandoParaConsulta.Parameters.AddWithValue("@precioTotalProducto", productoComprado.Precio);
      return comandoParaConsulta;
    }
  }
}