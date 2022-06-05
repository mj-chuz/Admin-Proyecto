using Microsoft.VisualStudio.TestTools.UnitTesting;
using Planetario.Controllers;
using System;
using System.Web.Mvc;
using Planetario.Models;
using Planetario.Handlers;
using System.Data;

namespace Planetario_PI_IS_BD.Tests.PruebasUnitarias{

  [TestClass]
  public class ReporteSatisfaccionPruebas{
    public PreguntaSatisfaccionController AccesoPreguntasSatisfaccionController;
    public PreguntaSatisfaccionHandler AccesoPreguntaSatisfaccionHandler;

    public ReporteSatisfaccionPruebas(){
      AccesoPreguntasSatisfaccionController = new PreguntaSatisfaccionController();
      AccesoPreguntaSatisfaccionHandler = new PreguntaSatisfaccionHandler();
    }

    [TestMethod]
    public void VerReporteReporteDeSatisfaccionSinFiltrarNoNuloPrueba_RS_1(){
      ViewResult paginaReporte = (ViewResult)AccesoPreguntasSatisfaccionController.ReporteDeSatisfaccion(1);
      Assert.IsNotNull(paginaReporte);
    }

    [TestMethod]
    public void VerReporteReporteDeSatisfaccionConFechaCompletaPrueba_RS_2(){
      ViewResult paginaReporte = (ViewResult)AccesoPreguntasSatisfaccionController.ReporteDeSatisfaccion(1, null, null, null, Convert.ToDateTime("12/2/2021"), DateTime.Now);
      Assert.AreNotEqual("Por favor seleccione un formato de fechas válido.", paginaReporte.ViewBag.MensajeError);
    }

    [TestMethod]
    public void VerReporteReporteDeSatisfaccionConFechaInvalidaPrueba_RS_3(){
      ViewResult paginaReporte = (ViewResult)AccesoPreguntasSatisfaccionController.ReporteDeSatisfaccion(1, null, null, null, Convert.ToDateTime("12/2/2021"), Convert.ToDateTime("12/2/2021"));
      Assert.AreEqual("Por favor seleccione un formato de fechas válido.", paginaReporte.ViewBag.MensajeError);
    }

    [TestMethod]
    public void VerReporteReporteDeSatisfaccionConDatosCompletosNoNuloPrueba_RS_4(){
      ViewResult paginaReporte = (ViewResult)AccesoPreguntasSatisfaccionController.ReporteDeSatisfaccion(1, "Secundaria terminada" , "Masculino", "Compra productos", Convert.ToDateTime("11/2/2021"));
      Assert.IsNotNull(paginaReporte);
    }

    [TestMethod]
    public void RecuperarPreguntaHandlerNoNuloPrueba_RS_5(){
      PreguntaSatisfaccionModel preguntaObtenida = AccesoPreguntaSatisfaccionHandler.ObtenerPregunta("P1P");
      Assert.IsNotNull(preguntaObtenida);
    }
    [TestMethod]
    public void ConstruirPreguntaHandlerNoNuloPrueba_RS_6(){
      DataTable tablaPregunta = new DataTable();
      tablaPregunta.Columns.Add(new DataColumn("idPreguntaPK", System.Type.GetType("System.String")));
      tablaPregunta.Columns.Add(new DataColumn("pregunta", System.Type.GetType("System.String")));
      tablaPregunta.Columns.Add(new DataColumn("categoria", System.Type.GetType("System.String")));
      DataRow filaPregunta = tablaPregunta.NewRow();
      filaPregunta["idPreguntaPK"] = "P1P";
      filaPregunta["pregunta"] = "¿Cómo fue su experiencia navegando la tienda?";
      filaPregunta["categoria"] = "Compra productos";
      PrivateObject accesoAHandler = new PrivateObject(AccesoPreguntaSatisfaccionHandler);
      PreguntaSatisfaccionModel preguntaObtenida = (PreguntaSatisfaccionModel)accesoAHandler.Invoke("ConstruirPregunta", new object[] { filaPregunta, null });
      Assert.IsNotNull(preguntaObtenida);
    }

    [TestMethod]
    public void ConstruirPreguntaHandlerCorrectaPrueba_RS_7(){
      PreguntaSatisfaccionModel preguntaEsperada = new PreguntaSatisfaccionModel(){
        Categoria = "Compra productos",
        IdPregunta = "P1P",
        Pregunta = "¿Cómo fue su experiencia navegando la tienda?",
      };
      DataTable tablaPregunta = new DataTable();
      tablaPregunta.Columns.Add(new DataColumn("idPreguntaPK", System.Type.GetType("System.String")));
      tablaPregunta.Columns.Add(new DataColumn("pregunta", System.Type.GetType("System.String")));
      tablaPregunta.Columns.Add(new DataColumn("categoria", System.Type.GetType("System.String")));
      DataRow filaPregunta = tablaPregunta.NewRow();
      filaPregunta["idPreguntaPK"] = "P1P";
      filaPregunta["pregunta"] = "¿Cómo fue su experiencia navegando la tienda?";
      filaPregunta["categoria"] = "Compra productos";
      PrivateObject accesoAHandler = new PrivateObject(AccesoPreguntaSatisfaccionHandler);
      PreguntaSatisfaccionModel preguntaObtenida = (PreguntaSatisfaccionModel)accesoAHandler.Invoke("ConstruirPregunta", new object[] { filaPregunta, null });
      Assert.AreEqual(preguntaObtenida, preguntaEsperada);
    }
  }
}
