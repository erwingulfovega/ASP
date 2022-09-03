using System.Collections.Generic;
using System;
using static System.Console;

namespace Etapa3.Entidades
{
    public class Program
    {
        static void Main(string[] args)
        {
            var escuela = new Escuela("Platzi", 2012, TiposEscuela.Primaria,
            pais: "Colombia", ciudad: "Bogotá");
            escuela.TipoEscuela = TiposEscuela.Primaria;

            escuela.Cursos = new List<Curso>(){
                    new Curso(){  Nombre = "101"},
                    new Curso(){  Nombre = "201"},
                    new Curso(){  Nombre = "301"}
            };

            var otrColeccion = new List<Curso>(){
                    new Curso(){  Nombre = "401", Jornada = TiposJornada.Mañana},
                    new Curso(){  Nombre = "501", Jornada = TiposJornada.Mañana},
                    new Curso(){  Nombre = "501", Jornada = TiposJornada.Tarde}
            };

            escuela.Cursos.Add(new Curso { Nombre = "102", Jornada = TiposJornada.Tarde });
            escuela.Cursos.Add(new Curso { Nombre = "202", Jornada = TiposJornada.Tarde });

            Curso tmp = new Curso { Nombre = "Vacionacional-101", Jornada = TiposJornada.Noche };

            escuela.Cursos.AddRange(otrColeccion);
            escuela.Cursos.Add(tmp);
            imprimirCursosEscuela(escuela);

            escuela.Cursos.RemoveAll(delegate (Curso cur)
                                             {
                                                 return cur.Nombre == "301";
                                             });
            
            escuela.Cursos.RemoveAll((cur) => cur.Nombre == "501" && cur.Jornada==TiposJornada.Mañana);

            imprimirCursosEscuela(escuela);
        }

        private static bool Predicado(Curso curobj)
        {
            return curobj.Nombre == "301";
        }

        private static void imprimirCursosEscuela(Escuela escuela)
        {
            WriteLine("==========================");
            WriteLine("Cursos de la Escuela");
            WriteLine("==========================");

            if (escuela?.Cursos != null)
            {

                foreach (var curso in escuela.Cursos)
                {
                    WriteLine($"Nombre: {curso.Nombre} Id: {curso.UniqueId} Jornada: {curso.Jornada}");
                }

            }

        }

    }
}