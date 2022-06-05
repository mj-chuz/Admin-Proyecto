using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Planetario_PI_IS_BD.Tests.PrepararPruebas{

  public class PaginaVisitante{

    public struct VisitanteNuevo{
      public String Correo { get; set; }
      public String Nombre { get; set; }
      public String PrimerApellido { get; set; }
      public String SegundoApellido { get; set; }
      public String Genero { get; set; }
      public String Pais { get; set; }
      public String FechaNacimiento { get; set; }
      public String NumeroTarjeta { get; set; }
      public String NombreTarjeta { get; set; }
      public String CodigoSeguridad { get; set; }
      public String MesVencimiento { get; set; }
      public String AnhoVencimiento { get; set; }

      public void AgregarDatos(){
        this.Correo = "mariolopez@gmail.com";
        this.Nombre = "Mario";
        this.PrimerApellido = "Vargas";
        this.SegundoApellido = "Salazar";
        this.Genero = "Masculino";
        this.Pais = "Alemania";
        this.FechaNacimiento = "10/10/2000";
        this.NumeroTarjeta = "1234123412341234";
        this.NombreTarjeta = "Mario Vargas Salazar";
        this.MesVencimiento = "12";
        this.AnhoVencimiento = "2025";
        this.CodigoSeguridad = "123";
      }
    }

    public IWebDriver DriverChrome;
    public By NumeroIdentificacion = By.Id("NumeroIdentificacion");
    public By BotonContinuarAPago = By.Id("continuarAPago");
    public By NumeroTarjeta = By.Id("numeroTarjeta");
    public By NombreTarjeta = By.Id("nombreTarjeta");
    public By MesExpiracion = By.Id("mes-expiracion");
    public By AnhoExpiracion = By.Id("anho-expiracion");
    public By Cvc = By.Id("cvc");
    public By BotonPagar = By.Id("boton-pagar");
    public By EncontrarCuposReservadosFinal = By.XPath("/html/body/div/div/div/div/div[4]/div[2]/p");
    public By BotonContinuarPagoVisitanteNuevo = By.XPath("/html/body/div/form/div/input");
    public By EntradaCedula = By.Id("NumeroIdentificacion");
    public By EntradaNombre = By.Id("Nombre");
    public By EntradaPrimerApellido = By.Id("PrimerApellido");
    public By EntradaSegundoApellido = By.Id("SegundoApellido");
    public By EntradaCorreo = By.Id("Correo");
    public By EntradaGenero = By.Id("Genero");
    public By EntradaNacionalidad = By.Id("paisSeleccionado");
    public By EntradaFechaNacimiento = By.Id("FechaDeNacimiento");

    public PaginaVisitante(IWebDriver driverChrome){
      this.DriverChrome = driverChrome;
    }

    public void IngresarIdentificacionVisitanteRecurrente(String identificacion){
      DriverChrome.FindElement(NumeroIdentificacion).SendKeys(identificacion);
      DriverChrome.FindElement(BotonContinuarAPago).Click();
    }

    public void IngresarVisitanteNuevo(String identificacion){
      VisitanteNuevo datosVisitante = new VisitanteNuevo();
      datosVisitante.AgregarDatos();
      DriverChrome.FindElement(EntradaCedula).SendKeys(identificacion);
      DriverChrome.FindElement(EntradaCorreo).SendKeys(datosVisitante.Correo);
      DriverChrome.FindElement(EntradaNombre).SendKeys(datosVisitante.Nombre);
      DriverChrome.FindElement(EntradaPrimerApellido).SendKeys(datosVisitante.PrimerApellido);
      DriverChrome.FindElement(EntradaSegundoApellido).SendKeys(datosVisitante.SegundoApellido);
      this.SeleccionarDatosVisitanteNuevo(datosVisitante);
    }

    public void SeleccionarDatosVisitanteNuevo(VisitanteNuevo datosVisitante)
    {
      IJavaScriptExecutor js = (IJavaScriptExecutor)DriverChrome;
      js.ExecuteScript("window.scrollTo(0, 954)");
      Thread.Sleep(1000);
      SelectElement seleccionarGenero = new SelectElement(DriverChrome.FindElement(EntradaGenero));
      seleccionarGenero.SelectByValue(datosVisitante.Genero);
      SelectElement seleccionarPais = new SelectElement(DriverChrome.FindElement(EntradaNacionalidad));
      seleccionarPais.SelectByValue(datosVisitante.Pais);
      IWebElement fecha = DriverChrome.FindElement(EntradaFechaNacimiento);
      fecha.SendKeys(datosVisitante.FechaNacimiento);
      DriverChrome.FindElement(BotonContinuarPagoVisitanteNuevo).Click();
    }


    public void IngresarInformacionTarjeta(){
      VisitanteNuevo datosVisitante = new VisitanteNuevo();
      datosVisitante.AgregarDatos();
      IJavaScriptExecutor js = (IJavaScriptExecutor)DriverChrome;
      js.ExecuteScript("window.scrollTo(0, 1003)");
      Thread.Sleep(1000);
      DriverChrome.FindElement(NumeroTarjeta).SendKeys(datosVisitante.NumeroTarjeta);
      DriverChrome.FindElement(Cvc).SendKeys(datosVisitante.CodigoSeguridad);
      DriverChrome.FindElement(NombreTarjeta).SendKeys(datosVisitante.NombreTarjeta);
      this.IngresarFechaVencimiento(datosVisitante);
    }

    public void IngresarFechaVencimiento(VisitanteNuevo datosVisitante){
      SelectElement seleccionarMes = new SelectElement(DriverChrome.FindElement(MesExpiracion));
      seleccionarMes.SelectByValue(datosVisitante.MesVencimiento);
      SelectElement seleccionarAnho = new SelectElement(DriverChrome.FindElement(AnhoExpiracion));
      seleccionarAnho.SelectByValue(datosVisitante.AnhoVencimiento);
      DriverChrome.FindElement(BotonPagar).Click();
    }

    public IWebElement VerificarCuposVentanaDePago(){
      IWebElement cuposEncontrados = DriverChrome.FindElement(EncontrarCuposReservadosFinal);
      return cuposEncontrados;
    }
  }
}