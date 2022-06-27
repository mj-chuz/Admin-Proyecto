using Microsoft.VisualStudio.TestTools.UnitTesting;
using Planetario.Controllers;
using Planetario.Models;
using Moq;
using System.Web.Mvc;

namespace Planetario_PI_IS_BD.Tests.PruebasUnitarias{

  [TestClass]
  public class PagoPruebas{

    private PagoController ObtenerPagoController(){
      PagoController AccesoAMetodosPago = new PagoController();
      var controllerContext = new Mock<ControllerContext>();
      double subtotal = 10000;
      double IVA = 1.13;
      controllerContext.SetupGet(p => p.HttpContext.Session["resumenDeCompra"]).Returns(new ResumenCompraProductosModel()
      {
        PrecioTotal = subtotal * IVA,
        SubTotal = subtotal,
        Impuestos = subtotal * IVA - subtotal,
      });
      AccesoAMetodosPago.ControllerContext = controllerContext.Object;
      return AccesoAMetodosPago;
    }
        
    [TestMethod]
    public void TestCuponAplicadoPrueba_AC_1(){
      PagoController accesoAMetodosPago = ObtenerPagoController();
      accesoAMetodosPago.AplicarDescuento("123456", "789");
      ResumenCompraProductosModel resumenCompra = (ResumenCompraProductosModel)accesoAMetodosPago.Session["resumenDeCompra"];
      Assert.IsTrue(resumenCompra.Descuento > 0);
    }

    [TestMethod]
    public void CuponCorrectoAplicadoPrueba_AC_2(){
      PagoController accesoAMetodosPago = ObtenerPagoController();
      ResumenCompraProductosModel resumenCompra = (ResumenCompraProductosModel)accesoAMetodosPago.Session["resumenDeCompra"];
      double descuentoAAplicar = resumenCompra.SubTotal * 0.2;
      accesoAMetodosPago.AplicarDescuento("123456", "789");
      resumenCompra = (ResumenCompraProductosModel)accesoAMetodosPago.Session["resumenDeCompra"];
      Assert.AreEqual(resumenCompra.Descuento, descuentoAAplicar);
    }
  }
}
