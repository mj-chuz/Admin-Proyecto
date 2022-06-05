using Planetario.Handlers;
using System;
using System.Web.Mvc;


namespace Planetario.Controllers {
  public class ProductoController : Controller {
    private ProductoHandler _accesoADatosProducto;

    public ProductoController() {
      this._accesoADatosProducto = new ProductoHandler();
    }

    public ActionResult Catalogo() {
      ViewBag.Productos = ObtenerProductos();
      return View();
    }

    public JsonResult ObtenerProductos(String categoria = "", String columnaOrdenamiento = "", String direccionOrdenamiento = "", int pagina = 0, String busqueda = "") {
      String productos = _accesoADatosProducto.ObtenerProductos(categoria, columnaOrdenamiento, direccionOrdenamiento, pagina, busqueda);
      return Json(productos);
    }

    public JsonResult ObtenerCantidadProductos(String categoria = "", String columnaOrdenamiento = "") {
      String cantidadProductos = _accesoADatosProducto.ObtenerCantidadTotalProductos(categoria);
      return Json(cantidadProductos);
    }
  }
}