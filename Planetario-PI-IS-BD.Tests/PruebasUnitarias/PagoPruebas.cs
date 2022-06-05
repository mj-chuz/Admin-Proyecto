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
  }
}
