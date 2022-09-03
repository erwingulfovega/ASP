// See https://aka.ms/new-console-template for more information
using System;

namespace CoreEscuela
{
    class Escuela
    {
        public string? nombre;
        public string? direccion;

        public int añoFundacion;

        public void Timbrar()
        {
            //Todo
            Console.Beep(2000,3000);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            var miEscuela = new Escuela();
            miEscuela.nombre ="Platzi";
            miEscuela.direccion ="Cra 9 Calle 72";
            miEscuela.añoFundacion = 2012;
            Console.WriteLine("TIMBRE");
            miEscuela.Timbrar();
        }

    }
}