using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Planetario_PI_IS_BD.Tests.PrepararPruebas{
  public class PaginaPreguntasSatisfaccion{
    public IWebDriver DriverChrome;
    public By BotonCuestionario = By.XPath("/html/body/div/div/div/div/div[6]/div[1]/button");
    public By IrACuestionario = By.XPath("//*[@id='modal-preguntas']/div/div/div[2]/a[1]");
    public String DireccionPreguntaSatisfaccionTiquetes = "http://pruebaproyectopi.azurewebsites.net/PreguntaSatisfaccion/CuestionarioSatisfaccionCompra?identificacionVisitante=1234&tipoActividad=Compra%20tiquetes";
    public String DireccionPreguntaSatisfaccionProductos = "http://pruebaproyectopi.azurewebsites.net/PreguntaSatisfaccion/CuestionarioSatisfaccionCompra?identificacionVisitante=1234&tipoActividad=Compra%20productos";
    public By PrimerPreguntaImagen = By.XPath("/html/body/div/div/form/div[1]/div/div/div/div[3]/label/img");
    public By SegundaPreguntaImagen = By.XPath("/html/body/div/div/form/div[2]/div/div/div/div[2]/label/img");
    public By TerceraPreguntaImagen = By.XPath("/html/body/div/div/form/div[3]/div/div/div/div[1]/label/img");
    public By BotonEnviar = By.XPath("/html/body/div/div/form/input[2]");
    public By TituloInicio = By.XPath("//*[@id='titulo-principal']/h1[1]");


    public PaginaPreguntasSatisfaccion(IWebDriver driverChrome){
      this.DriverChrome = driverChrome;
    }

    public void Iniciar(){
      DriverChrome.Manage().Window.Maximize();
      DriverChrome.Navigate().GoToUrl(DireccionPreguntaSatisfaccionProductos);
    }

    public void IngresarACuestionarioDeSatisfaccion(){
      DriverChrome.FindElement(BotonCuestionario).Click();
      WebDriverWait esperar = new WebDriverWait(DriverChrome, TimeSpan.FromSeconds(3));
      esperar.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(IrACuestionario));
      DriverChrome.FindElement(IrACuestionario).Click();
    }

    public IWebElement IngresarRespuestasDeSatisfaccion(){
      DriverChrome.FindElement(PrimerPreguntaImagen).Click();
      DriverChrome.FindElement(SegundaPreguntaImagen).Click();
      DriverChrome.FindElement(TerceraPreguntaImagen).Click();
      DriverChrome.FindElement(BotonEnviar).Click();
      return DriverChrome.FindElement(TituloInicio);
    }
  }
}
