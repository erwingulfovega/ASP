using System.Collections.Generic;
using System;
using static System.Console;

namespace Etapa2.Entidades
{
    public class Program
    {
        static void Main(string[] args)
        {
            var escuela = new Escuela("Platzi", 2012, TiposEscuela.Primaria,
            pais: "Colombia", ciudad: "Bogotá");
            escuela.TipoEscuela = TiposEscuela.Primaria;

            escuela.Cursos = new Curso[]{
                                       new Curso(){  Nombre = "101"},
                                       new Curso(){  Nombre = "201"},
                                       new Curso(){  Nombre = "301"}
                                     };

            
            imprimirCursosEscuela(escuela);

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