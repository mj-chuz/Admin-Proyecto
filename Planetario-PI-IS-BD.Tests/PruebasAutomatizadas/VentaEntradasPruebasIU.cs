using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Planetario_PI_IS_BD.Tests.PrepararPruebas;

namespace Planetario_PI_IS_BD.Tests.PruebasAutomatizadas{

  [TestClass]
  public class VentaEntradasPruebasIU{
    public PaginaActividad AccederPaginaActividad;
    public PaginaVisitante AccederPaginaVisitante;
    IWebDriver DriverChrome;

    public VentaEntradasPruebasIU(){
      DriverChrome = new ChromeDriver();
      AccederPaginaActividad = new PaginaActividad(DriverChrome);
      AccederPaginaVisitante = new PaginaVisitante(DriverChrome);
    }

    public String ReservarTiquetes(){
      String cantidadCupos = "2";
      AccederPaginaActividad.Iniciar();
      AccederPaginaActividad.ReservarTiquetesVisitante(cantidadCupos);
      return cantidadCupos;
    }

    [TestMethod]
    public void CompraEntradaVisitanteRecurrentePrueba(){
      String identificacion = "1234";
      String cantidadCupos = this.ReservarTiquetes();
      AccederPaginaActividad.ReservarVisitanteRecurrente();
      AccederPaginaVisitante.IngresarIdentificacionVisitanteRecurrente(identificacion);
      this.RealizarPago(cantidadCupos);
    }

    [TestMethod]
    public void CompraEntradaVisitanteNuevoPrueba(){
      String identificacion = "788878557";
      String cantidadCupos = this.ReservarTiquetes();
      AccederPaginaActividad.ReservarVisitanteNuevo();
      AccederPaginaVisitante.IngresarVisitanteNuevo(identificacion);
      this.RealizarPago(cantidadCupos);
    }

    public void RealizarPago(String cantidadCupos){
      AccederPaginaVisitante.IngresarInformacionTarjeta();
      this.VerificarCuposVentanaPago(cantidadCupos);
    }

    public void VerificarCuposVentanaPago(String cantidadCupos){
      IWebElement cuposEncontrados = AccederPaginaVisitante.VerificarCuposVentanaDePago();
      Assert.AreEqual(cuposEncontrados.Text, "Cantidad de espacios reservados: " + cantidadCupos);
      DriverChrome.Quit();
    }
  }
}

