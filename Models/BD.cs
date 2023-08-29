using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Dapper;

namespace TP07_CZERNUSZKA_KOZIUPA.Models;

public static class BD{
    private static string _connectionString = @"Server=localhost;DataBase=PreguntadOrt;Trusted_Connection=True;";

    public static List<Categorias> ObtenerCategorias(){
        List<Categorias> listaCategorias = null;
        using(SqlConnection BD = new SqlConnection(_connectionString)){
            string sql = "SELECT * FROM Categorias";
            listaCategorias = BD.Query<Categorias>(sql).ToList();
        }
        return listaCategorias;
    }

    public static List<Dificultades> ObtenerDificultades(){
        List<Dificultades> listaDificultades = null;
        using(SqlConnection BD = new SqlConnection(_connectionString)){
            string sql = "SELECT * FROM Dificultades";
            listaDificultades = BD.Query<Dificultades>(sql).ToList();
        }
        return listaDificultades;
    }

    public static List<Preguntas> ObtenerPreguntas(int IdDificultad, int IdCategoria){        
        using(SqlConnection BD = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Preguntas";
            DynamicParameters parametros = new DynamicParameters();

            if(IdDificultad != -1)
            {
                sql += " WHERE IdDificultad = @pIdDificultad";
                parametros.Add("@pIdDificultad", IdDificultad);
            }
            if(IdCategoria != -1)
            {
                sql += (IdDificultad != -1) ? " AND" : " WHERE";
                sql += " IdCategoria = @pIdCategoria";
                parametros.Add("@pIdCategoria", IdCategoria);
            }

            return BD.Query<Preguntas>(sql, parametros).ToList();  
        }
    }   

    public static List<Respuestas> ObtenerRespuestas(List<Preguntas> preguntas){
        List<Respuestas> respuestas = new List<Respuestas>();

        using(SqlConnection BD = new SqlConnection(_connectionString)){
            foreach (Preguntas pregunta in preguntas)
            {
                string sql = "SELECT * FROM Respuestas WHERE IdPregunta = @IdPregunta";
                int preg = pregunta.IdPregunta;
                respuestas.AddRange(BD.Query<Respuestas>(sql, new{IdPregunta = preg}).ToList());
            }
        }
        return respuestas;
    }
}