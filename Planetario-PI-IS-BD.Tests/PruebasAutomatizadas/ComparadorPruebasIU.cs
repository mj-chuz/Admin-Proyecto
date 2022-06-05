using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Planetario_PI_IS_BD.Tests.PrepararPruebas;

namespace Planetario_PI_IS_BD.Tests.PruebasAutomatizadas{

  [TestClass]
  public class ComparadorPruebasIU{
    public PaginaComparador AccesoPaginaComparador;
    IWebDriver DriverChrome;

    public ComparadorPruebasIU(){
      DriverChrome = new ChromeDriver();
      AccesoPaginaComparador = new PaginaComparador(DriverChrome);
    }

    [TestMethod]
    public void CompararDosCuerposPrueba(){
      AccesoPaginaComparador.IniciarPagina();
      IWebElement planetaSeleccionado = AccesoPaginaComparador.CompararDosCuerpos();
      Assert.AreEqual("Júpiter", planetaSeleccionado.Text);
      DriverChrome.Quit();
    }

    [TestMethod]
    public void CompararConjuntoCuerposPrueba(){
      AccesoPaginaComparador.IniciarPagina();
      IWebElement planetaSeleccionado = AccesoPaginaComparador.CompararConjuntoCuerpos();
      Assert.AreEqual("La Luna", planetaSeleccionado.Text);
      DriverChrome.Quit();
    }
  }
}
