using System;
using System.Web.Mvc;
using Planetario.Handlers;
using Planetario.Models;
using System.Collections.Generic;

namespace Planetario.Controllers {
  public class JuegosController : Controller {

    private JuegosHandler AccesoMetodosJuegos;

    public JuegosController() {
      AccesoMetodosJuegos = new JuegosHandler();
    }

    public ActionResult PaginaPrincipal() {
      return View();
    }


    public ActionResult Juego(String tipo) {
      List<JuegoModel> listaJuegos = AccesoMetodosJuegos.CargarListaJuegos(tipo);
      var aleatorizador = new Random();
      JuegoModel juegoEscogido = listaJuegos[aleatorizador.Next(listaJuegos.Count)];
      ViewBag.NombreJuego = juegoEscogido.Nombre;
      ViewBag.LinkJuego = juegoEscogido.Link;
      return View();
    }


    public ActionResult TypingPlanetario() {
      return View();
    }

    public ActionResult JuegoMemoria() {
      return View();
    }
  }
    
}