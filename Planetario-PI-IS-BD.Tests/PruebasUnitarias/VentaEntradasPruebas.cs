using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Planetario.Controllers;
using Planetario.Models;
using System.Web.Mvc;
using Planetario.Handlers;
using Moq;
using System.Collections.Specialized;

namespace Planetario_PI_IS_BD.Tests.PruebasUnitarias{

  [TestClass]
  public class VentaEntradasPruebas{
    public VisitanteController ControladorVisitante;
    public VisitanteModel VisitantePrueba;
    public PagoController AccesoAMetodosPago;

    public VentaEntradasPruebas(){
      ControladorVisitante = new VisitanteController(){
        AccesoMetodosVisitante = new VisitanteHandler(),
        AccesoDatosActividad = new ActividadHandler(),
      };

      AccesoAMetodosPago = new PagoController();

      VisitantePrueba = new VisitanteModel{
        NumeroIdentificacion = "456789",
        Nombre = "Pedrito",
        PrimerApellido = "Campos",
        Correo = "pedritocam@gmail.com",
        Genero = "Masculino",
        Pais = "Costa_Rica",
        FechaDeNacimiento = Convert.ToDateTime("10/10/2000"),
        NivelEducativo = "Primaria terminada",
        TituloActividadInscrita = "Biosfera",
        FechaActividadInscrita = Convert.ToDateTime("12/4/2021 8:35:00 PM")
      };
    }

    [TestMethod]
    public void PruebaInscribirVisitanteVacioPrueba_IV_1(){
      NameValueCollection form = new NameValueCollection();
      form["paisSeleccionado"] = "Nicaragua";
      var contexto = new Mock<ControllerContext>();
      contexto.Setup(frm => frm.HttpContext.Request.Form).Returns(form);
      VisitanteModel visitante = new VisitanteModel();
      visitante.TituloActividadInscrita = "Actividad Mala";
      visitante.FechaActividadInscrita = DateTime.Now;
      ControladorVisitante.ControllerContext = contexto.Object;
      ViewResult vistaVisitante = (ViewResult)ControladorVisitante.InscribirVisitante(visitante, 3);
      Assert.AreEqual("Algo salió mal y no fue posible realizar la inscripción", vistaVisitante.ViewBag.Message);
    }

    [TestMethod]
    public void VisitanteInscritoPrueba_VI_1(){
      ActionResult vistaVisitante = ControladorVisitante.VerificarInscripcionEnPlanetario(VisitantePrueba, 2,"actividad");
      Assert.AreEqual("RedirectToRouteResult", vistaVisitante.GetType().Name);
    }

    [TestMethod]
    public void InscribirVisitantePrueba_IV_2(){
      NameValueCollection form = new NameValueCollection();
      form["paisSeleccionado"] = "Costa Rica";
      var contexto = new Mock<ControllerContext>();
      contexto.Setup(frm => frm.HttpContext.Request.Form).Returns(form);
      VisitantePrueba.NumeroIdentificacion = "89009";
      ControladorVisitante.ControllerContext = contexto.Object;
      ActionResult vistaVisitante = ControladorVisitante.InscribirVisitante(VisitantePrueba, 3, "actividad");
      Assert.AreEqual("RedirectToRouteResult", vistaVisitante.GetType().Name);
    }
  }
}
