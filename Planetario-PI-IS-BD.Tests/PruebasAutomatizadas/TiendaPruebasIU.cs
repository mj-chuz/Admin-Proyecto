using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Planetario_PI_IS_BD.Tests.PrepararPruebas;

namespace Planetario_PI_IS_BD.Tests.PruebasAutomatizadas{

  [TestClass]
  public class TiendaPruebasIU{
    public PaginaTienda AccederPaginaTienda;
    IWebDriver DriverChrome;

    public TiendaPruebasIU(){
      DriverChrome = new ChromeDriver();
      AccederPaginaTienda = new PaginaTienda(DriverChrome);
      AccederPaginaTienda.Iniciar();
    }

    [TestMethod]
    public void PruebaOrdenamientoDeProductosPrueba(){
      IWebElement primerProducto = AccederPaginaTienda.CompararOrdenamiento("Nombre-Asc");
      IWebElement segundoProducto = AccederPaginaTienda.CompararOrdenamiento("Nombre-Desc");
      DriverChrome.Quit();
      Assert.AreNotEqual(primerProducto, segundoProducto);
    }
  }
}
