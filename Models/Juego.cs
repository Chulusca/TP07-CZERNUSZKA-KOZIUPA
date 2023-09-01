using System;
using System.Collections.Generic;
using System.Linq;

namespace TP07_CZERNUSZKA_KOZIUPA.Models;

public static class Juego
{
    private static string _username;
    private static int _puntajeActual;
    private static int _cantidadPreguntasCorrectas;
    private static int _cantidadPreguntas;
    private static List<Preguntas> _preguntas;
    private static List<Respuestas> _respuestas;

    public static void InicializarJuego()
    {
        _cantidadPreguntas = 1;
        _username = "";
        _puntajeActual = 0;
        _cantidadPreguntasCorrectas = 0;
    }

    public static List<Categorias> ObtenerCategorias()
    {
        return BD.ObtenerCategorias();
    }

    public static List<Dificultades> ObtenerDificultades()
    {
    return BD.ObtenerDificultades();
    }

    public static void CargarPartida(string username, int dificultad, int categoria)
    {
        _preguntas = BD.ObtenerPreguntas(dificultad, categoria);
        _respuestas = BD.ObtenerRespuestas(_preguntas);
        _username = username;
    }

    public static Preguntas ObtenerProximaPregunta()
    {
        if(_preguntas.Count > 0){
            return _preguntas[0];
        }
        else
        {
            return null;
        }
    }

    public static List<Respuestas> ObtenerProximasRespuestas(int IdPregunta)
    {
        List<Respuestas> lista = _respuestas.Where(r => r.IdPregunta == IdPregunta).ToList();
        return lista;
    }

    public static bool VerificarRespuesta(int IdPregunta, int IdRespuesta)
    {
        int i = 0;
        bool esCorrecta = false;

        while(i < _respuestas.Count() && !esCorrecta){
            if(_respuestas[i].IdRespuesta == IdRespuesta){
                if(_respuestas[i].Correcta){
                _puntajeActual += 1507;
                _cantidadPreguntasCorrectas += 1;
                esCorrecta = true;
                } 
            }
            i ++;
        } 
        _cantidadPreguntas ++;
        _preguntas.RemoveAt(0);
        return esCorrecta;
    }
    public static string ObtenerUsername(){
        return _username;
    }
    public static int ObtenerPuntaje(){
        return _puntajeActual;
    }
    public static int ObtenerPreguntasRespondidas(){return _cantidadPreguntas;}
}