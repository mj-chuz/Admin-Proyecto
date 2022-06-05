using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace Planetario_PI_IS_BD.Tests.PrepararPruebas{
  public class PaginaActividad{
    public IWebDriver DriverChrome;
    public String DireccionPaginaCharlas = "http://pruebaproyectopi.azurewebsites.net/Actividad/ListaCharlas";
    public String DireccionPaginaTalleres = "http://pruebaproyectopi.azurewebsites.net/Actividad/ListaTalleres";
    public By BotonComprarTiquetes = By.XPath("//*[@id='container-actividades']/div[1]/div/div/div[2]/button");
    public By SeleccionarNumeroTiquete = By.Id("cuposComprados");
    public By SeleccionarBotonContinuar = By.XPath("//*[@id='comprarTiquetes']/div/div/div[2]/form/div[5]/button");

    public PaginaActividad(IWebDriver driverChrome){
      this.DriverChrome = driverChrome;
    }

    public void Iniciar(){
      DriverChrome.Manage().Window.Maximize();
      DriverChrome.Navigate().GoToUrl(DireccionPaginaTalleres);
    }

    public void ReservarTiquetesVisitante(String numeroCupos){
      DriverChrome.FindElement(BotonComprarTiquetes).Click();
      WebDriverWait esperar = new WebDriverWait(DriverChrome, TimeSpan.FromSeconds(3));
      esperar.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(SeleccionarNumeroTiquete));
      SelectElement cuposSeleccionados = new SelectElement(DriverChrome.FindElement(SeleccionarNumeroTiquete));
      cuposSeleccionados.SelectByValue(numeroCupos);
      DriverChrome.FindElement(SeleccionarBotonContinuar).Click();
    }

    public void ReservarVisitanteRecurrente(){
      By botonVisitanteRecurrente = By.XPath("//*[@id='comprarTiquetes']/div/div/div[2]/form/div[5]/ul/li[2]/input");
      DriverChrome.FindElement(botonVisitanteRecurrente).Click();
    }

    public void ReservarVisitanteNuevo(){
      By seleccionarVisitanteNuevo = By.XPath("//*[@id='comprarTiquetes']/div/div/div[2]/form/div[5]/ul/li[1]/input");
      DriverChrome.FindElement(seleccionarVisitanteNuevo).Click();
    }
  }
}
