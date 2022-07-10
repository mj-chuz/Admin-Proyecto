using System;
using System.Web.Mvc;
using Planetario.Handlers;
using Planetario.Models;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

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
      dynamic parsedContent = "";
      try {
        string[] content = System.IO.File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "JSON/cientificos.json"));

        string contentExtracted = "";
        foreach (string line in content) {
          contentExtracted += line + "\n";
        }
        parsedContent = JsonConvert.DeserializeObject(contentExtracted);
      }
      catch (Exception e) {
        string error = "Error while parsing JSON raw data \n" + e.ToString();
      }

      Dictionary<string, string[]> scientists = new Dictionary<string, string[]>();
      foreach (var element in parsedContent) {
        scientists.Add(element.Id.ToString(), new string[] { element.Name, element.Description, element.ImageRef });
      }

      @ViewBag.Scientists = scientists;

      return View();
    }
  }
    
}