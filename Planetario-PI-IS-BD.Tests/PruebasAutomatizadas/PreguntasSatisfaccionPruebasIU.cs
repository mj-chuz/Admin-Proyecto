using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Planetario_PI_IS_BD.Tests.PrepararPruebas;

namespace Planetario_PI_IS_BD.Tests.PruebasAutomatizadas{

  [TestClass]
  public class PreguntasSatisfaccionPruebasIU{
    public PaginaPreguntasSatisfaccion AccederPaginaPreguntasSatisfaccion;
    public PaginaActividad AccederPaginaActividad;
    public PaginaVisitante AccederPaginaVisitante;
    IWebDriver DriverChrome;

    public PreguntasSatisfaccionPruebasIU(){
      DriverChrome = new ChromeDriver();
      AccederPaginaPreguntasSatisfaccion = new PaginaPreguntasSatisfaccion(DriverChrome);
      AccederPaginaActividad = new PaginaActividad(DriverChrome);
      AccederPaginaVisitante = new PaginaVisitante(DriverChrome);
    }

    [TestMethod]
    public void LlenarCuestionarioSatisfaccionDeProductosPrueba(){
      AccederPaginaPreguntasSatisfaccion.Iniciar();
      this.ComprobarRedireccionPaginaInicio();
    }

    [TestMethod]
    public void LlenarCuestionarioSatisfaccionDeTiquetesPrueba(){
      AccederPaginaActividad.Iniciar();
      AccederPaginaActividad.ReservarTiquetesVisitante("1");
      AccederPaginaActividad.ReservarVisitanteRecurrente();
      AccederPaginaVisitante.IngresarIdentificacionVisitanteRecurrente("1234");
      AccederPaginaVisitante.IngresarInformacionTarjeta();
      AccederPaginaPreguntasSatisfaccion.IngresarACuestionarioDeSatisfaccion();
      this.ComprobarRedireccionPaginaInicio();
    }

    public void ComprobarRedireccionPaginaInicio(){
      IWebElement tituloPaginaPrincipal = AccederPaginaPreguntasSatisfaccion.IngresarRespuestasDeSatisfaccion();
      Assert.AreEqual("PLANETARIO", tituloPaginaPrincipal.Text);
      DriverChrome.Quit();
    }
  }
}
