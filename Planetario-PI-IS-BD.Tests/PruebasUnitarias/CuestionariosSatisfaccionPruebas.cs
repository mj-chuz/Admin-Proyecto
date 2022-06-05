using Microsoft.VisualStudio.TestTools.UnitTesting;
using Planetario.Controllers;
using System.Web.Mvc;

namespace Planetario_PI_IS_BD.Tests.PruebasUnitarias{

  [TestClass]
  public class CuestionariosSatisfaccionPruebas{
    public PreguntaSatisfaccionController AccesoAPreguntasSatisfaccion;

    public CuestionariosSatisfaccionPruebas(){
      AccesoAPreguntasSatisfaccion = new PreguntaSatisfaccionController();
    }

    [TestMethod]
    public void EnviarActividadEnNullPrueba_PSC_1(){
      ActionResult paginaSatisfaccionCompra = AccesoAPreguntasSatisfaccion.CuestionarioSatisfaccionCompra("1234", null);
      Assert.AreEqual("RedirectToRouteResult", paginaSatisfaccionCompra.GetType().Name);
    }

    [TestMethod]
    public void EnviarIdentificacionEnNullPrueba_PSC_2(){
      ActionResult paginaSatisfaccionCompra = AccesoAPreguntasSatisfaccion.CuestionarioSatisfaccionCompra(null, "actividad compra");
      Assert.AreEqual("RedirectToRouteResult", paginaSatisfaccionCompra.GetType().Name);
    }

    [TestMethod]
    public void InsertarCategoriaIncorrectaPrueba_PSC_3(){
      ActionResult paginaSatisfaccionCompra = AccesoAPreguntasSatisfaccion.CuestionarioSatisfaccionCompra("1234", "datos inválidos");
      Assert.AreEqual("RedirectToRouteResult", paginaSatisfaccionCompra.GetType().Name);
    }
  }
}
