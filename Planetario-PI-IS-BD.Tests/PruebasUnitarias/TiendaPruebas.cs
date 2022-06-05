using Microsoft.VisualStudio.TestTools.UnitTesting;
using Planetario.Handlers;
using System.Collections.Generic;
using Planetario.Models;

namespace Planetario_PI_IS_BD.Tests.PruebasUnitarias{

  [TestClass]
  public class TiendaPruebas{
    ProductoHandler ProductoHandler;

    public TiendaPruebas(){
      ProductoHandler = new ProductoHandler();
    }

    [TestMethod]
    public void PruebaObtenerProductosPorPaginaPrueba_OP_1(){
      int cantidadProductosFinal = ProductoHandler.ObtenerProductosPorPagina();
      List<ProductoModel> productos = ProductoHandler.ObtenerListaProductos(ProductoHandler.ObtenerTablaProductos());
      Assert.AreEqual(cantidadProductosFinal, productos.Count);
    }
  }
}
