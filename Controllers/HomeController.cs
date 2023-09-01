using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP07_CZERNUSZKA_KOZIUPA.Models;

namespace TP07_CZERNUSZKA_KOZIUPA.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult ConfigurarJuego()
    {
        Juego.InicializarJuego();
        ViewBag.listaCategorias = Juego.ObtenerCategorias();
        ViewBag.listaDificultades = Juego.ObtenerDificultades();
        return View("ConfigurarJuego");
    }
    public IActionResult Comenzar(string username, int dificultad, int categoria)
    {
        Juego.CargarPartida(username, dificultad, categoria);
        Preguntas _pregunta = Juego.ObtenerProximaPregunta();
        if(_pregunta != null) return RedirectToAction("Jugar");
        else return RedirectToAction("ConfigurarJuego");
    }
    public IActionResult Jugar()
    {
        ViewBag.pregunta = Juego.ObtenerProximaPregunta();
        if(ViewBag.pregunta != null){ViewBag.respuestas = Juego.ObtenerProximasRespuestas(Juego.ObtenerProximaPregunta().IdPregunta);}
        ViewBag.user = Juego.ObtenerUsername();
        ViewBag.puntaje = Juego.ObtenerPuntaje();
        ViewBag._preguntasRespondidas = Juego.ObtenerPreguntasRespondidas();
        if(Juego.ObtenerProximaPregunta() == null){
            return View("Fin");
        }
        else{
            return View("Juego");
        }
    }
    [HttpPost] public IActionResult VerificarRespuesta(int idPregunta, int idRespuesta)
    {
        ViewBag.esCorrecta = Juego.VerificarRespuesta(idPregunta, idRespuesta);
        ViewBag.Respuestas = Juego.ObtenerProximasRespuestas(idPregunta);
        return View("Respuesta");
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
