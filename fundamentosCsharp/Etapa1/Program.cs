using System;
namespace Etapa1.Entidades
{
    class Program
    {
        static void Main(string[] args)
        {
            var escuela = new Escuela("Platzi", 2012, TiposEscuela.Primaria,
            pais:"Colombia", ciudad:"Bogotá");
            escuela.TipoEscuela= TiposEscuela.Primaria;
            Console.WriteLine(escuela);
        }
    }
}