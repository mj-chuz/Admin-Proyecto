using System.Web.Mvc;


namespace Planetario.Controllers {
    public class PlanetarioController : Controller {

      public ActionResult InformacionPlanetario(){
        return View();
      }
      public ActionResult InformacionHorarios() {
        return InformacionPlanetario();
      }
  }
}