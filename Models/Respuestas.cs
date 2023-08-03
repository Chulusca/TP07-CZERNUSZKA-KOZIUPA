using System;
using System.Collections.Generic;

namespace TP07_CZERNUSZKA_KOZIUPA.Models;

public class Respuestas{
    public int IdRespuesta{get;set;}
    public int IdPregunta{get;set;}
    public int Opcion{get;set;}
    public string Contenido{get;set;}
    public bool Correcta{get;set;}
}