using System;
using System.Collections.Generic;

namespace TP07_CZERNUSZKA_KOZIUPA.Models;

public static class Juego
{
    private static string _username;
    private static int _puntajeActual;
    private static int _cantidadPreguntasCorrectas;
    private static List<Pregunta> _preguntas;
    private static List<Respuesta> _respuestas;

    public static void InicializarJuego()
    {
        _username = "";
        _puntajeActual = 0;
        _cantidadPreguntasCorrectas = 0;
    }

    public static List<string> ObtenerCategorias()
    {
        
    }

    public static List<string> ObtenerDificultades()
    {
       
    }

    public static void CargarPartida(string username, int dificultad, int categoria)
    {
        ObtenerPreguntas(dificultad, categoria);
        ObtenerRespuestas();
    }

    private static void ObtenerPreguntas(int dificultad, int categoria)
    {
        
    }

    private static void ObtenerRespuestas()
    {
        
    }

    public static Pregunta ObtenerProximaPregunta()
    {
        if (_preguntas.Count > 0)
        {
            
        }
        return null;
    }

    public static List<Respuesta> ObtenerProximasRespuestas(int idPregunta)
    {
        
    }

    public static bool VerificarRespuesta(int idPregunta, int idRespuesta)
    {
        
        if (respuestaEsCorrecta)
        {
            _puntajeActual += 10; 
            _cantidadPreguntasCorrectas++;
        }

        return respuestaEsCorrecta;
    }
}