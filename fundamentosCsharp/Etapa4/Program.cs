using System.Collections.Generic;
using System;
using static System.Console;
using Etapa4.Util;

namespace Etapa4.Entidades
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            var engine = new EscuelaEngine();
            engine.Inicializar();
            Printer.EscribirTitulo("Bienvenidos a la Escuela");
            Printer.Beep(10000,cantidad:10);
            imprimirCursosEscuela(engine.Escuela);
        }

        private static bool Predicado(Curso curobj)
        {
            return curobj.Nombre == "301";
        }

        private static void imprimirCursosEscuela(Escuela escuela)
        {
            
            Printer.EscribirTitulo("Cursos de la Escuela");

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