using Planetario.Handlers;
using Planetario.Models;
using System;
using System.Web.Mvc;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using QRCoder;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace Planetario.Controllers {
  public class PagoController : Controller {
    public VisitanteHandler AccesoMetodosVisitante;
    public ActividadHandler AccesoDatosActividad;
    public ProductoHandler AccesoAProductos;
    public CompraProductosHandler AccesoACompras;
    private const double IVA = 1.13;

    public PagoController() {
      AccesoMetodosVisitante = new VisitanteHandler();
      AccesoDatosActividad = new ActividadHandler();
      AccesoAProductos = new ProductoHandler();
      AccesoACompras = new CompraProductosHandler();
    }

    public ActionResult PagoActividad(String identificacionVisitante, String nombreActividad, String fechaActividad, int cantidadCupos, String mensajeError = "") {
      ActividadModel actividad = AccesoDatosActividad.ObtenerActividad(nombreActividad, Convert.ToDateTime(fechaActividad));
      double precioTotal = cantidadCupos * actividad.PrecioSugerido * IVA;
      ResumenCompraModel infoTiquete = new ResumenCompraTiqueteModel(nombreActividad, fechaActividad, cantidadCupos, precioTotal);
      return VentanaDePago(identificacionVisitante, infoTiquete, "actividad", mensajeError);
    }

    public ActionResult PagoProductos(String identificacionVisitante = "") {
      CarritoModel carritoDeCompra = (CarritoModel)Session["carrito"];
      double subtotal = carritoDeCompra.CalcularSubtotal();
      ResumenCompraModel resumenDeCompra = new ResumenCompraProductosModel() {
        Carrito = carritoDeCompra,
        PrecioTotal = subtotal * IVA,
        SubTotal = subtotal,
        Impuestos = subtotal * IVA - subtotal,
      };
      return VentanaDePago(identificacionVisitante, resumenDeCompra, "producto");
    }

    public ActionResult VentanaDePago(String identificacionVisitante, ResumenCompraModel resumenCompra, String tipoPago, String mensajeError = "") {
      if (identificacionVisitante != "") {
        ViewBag.Visitante = AccesoMetodosVisitante.RecuperarVisitante(identificacionVisitante);
        ViewBag.ResumenCompra = resumenCompra;
        ViewBag.TipoPago = tipoPago;
        Session["resumenDeCompra"] = resumenCompra;
        if (mensajeError != "") ViewBag.Message = mensajeError;
        return View("VentanaDePago");
      }
      return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    public ActionResult VentanaDePago(String identificacionVisitante) {
      ViewBag.Visitante = AccesoMetodosVisitante.RecuperarVisitante(identificacionVisitante);
      String numeroTarjeta = Request.Form["numeroTarjeta"];
      String CVC = Request.Form["cvc"];
      String nombreTarjeta = Request.Form["nombreTarjeta"];
      String resumenCompraSerializado = Request.Form["infoCompra"];
      String tipoPago = Request.Form["tipoPago"];
      ResumenCompraModel resumenCompra;
      if (tipoPago == "actividad") {
        resumenCompra = JsonConvert.DeserializeObject<ResumenCompraTiqueteModel>(resumenCompraSerializado);
      } else {
        resumenCompra = (ResumenCompraProductosModel)Session["resumenDeCompra"];
      }
      ViewBag.ResumenCompra = Session["resumenDeCompra"];
      ViewBag.TipoPago = tipoPago;
      bool numeroValido = ValidarNumeroTarjeta(numeroTarjeta);
      bool CVCValido = ValidarCVC(CVC);
      bool nombreTarjetaValido = (nombreTarjeta != "");
      bool datosDePagoValidos = numeroValido && CVCValido && nombreTarjetaValido;
      if (datosDePagoValidos) {
        if (tipoPago == "actividad") {
          return CompraFinalizadaTiquete(identificacionVisitante, (ResumenCompraTiqueteModel)resumenCompra);
        } else {
          Session["carrito"] = null;
          Session["cantidadProductosCarrito"] = 0;
          return CompraFinalizadaProductos(identificacionVisitante, (ResumenCompraProductosModel)resumenCompra);
        }
      } else {
        return VentanaDePago(identificacionVisitante, resumenCompra, tipoPago, "Los datos ingresados no son válidos");
      }

    }

    private bool ValidarNumeroTarjeta(String numero = "") {
      String numeroSinGuionesNiEspacios = numero.Replace("-", "");
      numeroSinGuionesNiEspacios = numeroSinGuionesNiEspacios.Replace(" ", "");
      bool esNumerico = Regex.IsMatch(numeroSinGuionesNiEspacios, @"^\d+$");
      bool tieneLongitudCorrecta = (numeroSinGuionesNiEspacios.Length == 16);
      return (esNumerico && tieneLongitudCorrecta);
    }

    private bool ValidarCVC(String CVC = "") {
      bool esNumerico = int.TryParse(CVC, out _);
      bool tieneLongitudCorrecta = (CVC.Length == 3);
      return esNumerico && tieneLongitudCorrecta;
    }


    private byte[] GenerarQR(String codigo) {
      QRCodeGenerator generadorQR = new QRCodeGenerator();
      QRCodeData datosQR = generadorQR.CreateQrCode(codigo, QRCodeGenerator.ECCLevel.Q);
      QRCode codigoQR = new QRCode(datosQR);
      Bitmap imagenQR = codigoQR.GetGraphic(20);
      byte[] QRenBytes;
      using (MemoryStream stream = new MemoryStream()) {
        imagenQR.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
        QRenBytes =  stream.ToArray();
      }
      return QRenBytes;
    }

    public ActionResult CompraFinalizadaTiquete(String identificacionVisitante, ResumenCompraTiqueteModel resumenCompra) {
      ViewBag.Actividad = AccesoDatosActividad.ObtenerActividad(resumenCompra.NombreActividad, Convert.ToDateTime(resumenCompra.FechaActividad));
      ViewBag.Comprador = AccesoMetodosVisitante.RecuperarVisitante(identificacionVisitante);
      ViewBag.PrecioTotal = resumenCompra.PrecioTotal;
      ViewBag.Cupos = resumenCompra.CantidadCupos;
      ViewBag.Codigo = AccesoMetodosVisitante.AgregarInscripcion(ViewBag.Comprador, ViewBag.Actividad, resumenCompra.CantidadCupos);
      ViewBag.QR = GenerarQR(ViewBag.Codigo);
      AccesoDatosActividad.ActualizarCuposDisponibles(ViewBag.Actividad, resumenCompra.CantidadCupos);
      return View("CompraFinalizadaTiquete");
    }

    public ActionResult CompraFinalizadaProductos(String identificacionVisitante, ResumenCompraProductosModel resumenCompra) {
      ViewBag.ResumenCompra = resumenCompra;
      ViewBag.Identificacion = identificacionVisitante;
      AccesoACompras.ActualizarTablasCompra(resumenCompra, identificacionVisitante);
      return View("CompraFinalizadaProductos");
    }

    public ActionResult MostrarCarritoCompras() {
      if (Session["carrito"] == null) Session["carrito"] = new CarritoModel();
      ViewBag.Carrito = (CarritoModel)Session["carrito"];
      return View();
    }
  }
}