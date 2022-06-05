using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Planetario.Controllers;
using Planetario.Models;
using System;
using System.Web.Mvc;

namespace Planetario_PI_IS_BD.Tests.PruebasUnitarias{

  [TestClass]
  public class CarritoPruebas{
    public CarritoController CarritoController;

    public CarritoPruebas(){
      CarritoController = new CarritoController();
    }

    [TestMethod]
    public void AgregarProductoPrueba_CC_1(){
      var contexto = new Mock<ControllerContext>();
      String identificadorProducto = "1Ll";
      contexto.Setup(carritoMock => carritoMock.HttpContext.Session["carrito"]).Returns(new CarritoModel());
      contexto.Setup(carritoMock => carritoMock.HttpContext.Session["cantidadProductosCarrito"]).Returns(0);
      CarritoController.ControllerContext = contexto.Object;
      CarritoController.AgregarProducto(identificadorProducto);
      CarritoModel carrito = (CarritoModel)CarritoController.Session["carrito"];
      Assert.IsTrue(carrito.ProductosEnCarrito.ContainsKey(identificadorProducto));
    }

    [TestMethod]
    public void AgregarProductoInvalidoPrueba_CC_2(){
      var contexto = new Mock<ControllerContext>();
      String identificadorProducto = "idInvalido";
      contexto.Setup(carritoMock => carritoMock.HttpContext.Session["carrito"]).Returns(new CarritoModel());
      contexto.Setup(carritoMock => carritoMock.HttpContext.Session["cantidadProductosCarrito"]).Returns(0);
      CarritoController.ControllerContext = contexto.Object;
      CarritoController.AgregarProducto(identificadorProducto);
      ActionResult vistaRetornada = CarritoController.AgregarProducto(identificadorProducto);
      CarritoModel carrito = (CarritoModel)CarritoController.Session["carrito"];
      Assert.AreEqual("RedirectToRouteResult", vistaRetornada.GetType().Name);
      Assert.IsFalse(carrito.ProductosEnCarrito.ContainsKey(identificadorProducto));
    }

  }
}
