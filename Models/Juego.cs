using System;
using System.Collections.Generic;

namespace TP07_CZERNUSZKA_KOZIUPA.Models;

public static class Juego
{
    private static string _username;
    private static int _puntajeActual;
    private static int _cantidadPreguntasCorrectas;
    private static List<Preguntas> _preguntas;
    private static List<Respuestas> _respuestas;

    public static void InicializarJuego()
    {
        _username = "";
        _puntajeActual = 0;
        _cantidadPreguntasCorrectas = 0;
    }

    public static List<string> ObtenerCategorias()
    {
        return BD.ObtenerCategorias();
    }

    public static List<string> ObtenerDificultades()
    {
       return BD.ObtenerDificultades();
    }

    public static void CargarPartida(string username, int dificultad, int categoria)
    {
        _preguntas = BD.ObtenerPreguntas(dificultad, categoria);
        _respuestas = BD.ObtenerRespuestas(_preguntas);
    }

    public static Preguntas ObtenerProximaPregunta()
    {

    }

    public static List<Respuestas> ObtenerProximasRespuestas(int idPregunta)
    {
        
    }

    public static bool VerificarRespuesta(int idPregunta, int idRespuesta)
    {

    }
}