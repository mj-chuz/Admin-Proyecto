using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web;
using Planetario.Handlers;

namespace Planetario.Models {
  public class ResumenCompraProductosModel : ResumenCompraModel {

    private const double IVA = 1.13;
    public CarritoModel Carrito { get; set; }
    public double PrecioTotal { get; set; }
    public double SubTotal { get; set; }
    public double Impuestos { get; set; }


    public ResumenCompraProductosModel() {
    }

    public ResumenCompraProductosModel(CarritoModel productosComprados, double precioTotal) {
      this.Carrito = productosComprados;
      this.PrecioTotal = precioTotal;
    }


    public override IHtmlString GenerarResumen() {
      String resumen = "" +
        "<div class=\"row\">" +
        "<div class=\"col\">" +
        "<h5>Nombre<h5>" +
        "</div>" +
        "<div class=\"col\">" +
        "<h5>Total</h5>" +
        "</div>" +
        "</div>";
      foreach (KeyValuePair<string, int> elementoCarrito in Carrito.ProductosEnCarrito) {
        ProductoHandler productoHandler = new ProductoHandler();
        ProductoModel producto = productoHandler.ObtenerProductoModel(elementoCarrito.Key);
        int cantidad = elementoCarrito.Value;
        String resumenProducto = "";
        resumenProducto += "<div class=\"row\">" +
        "<div class=\"col\">" +
        "{0}" +
        "</div>" +
        "<div class=\"col\">" +
        "₡{1}" +
        "</div>" +
        "</div>";
        resumenProducto = String.Format(resumenProducto, producto.Nombre, producto.Precio*cantidad);
        resumen += resumenProducto;
      }
      IHtmlString resumenConvertido = new HtmlString(resumen);
      return resumenConvertido;
    }

    public override string SerializarAJson() {
      return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

  }
}