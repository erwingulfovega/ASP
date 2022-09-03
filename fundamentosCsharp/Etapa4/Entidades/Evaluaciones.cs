using System;
namespace Etapa4.Entidades
{
    public class Evaluaciones
    {
        public string UniqueId { get; private set; }
        public string Nombre { get; set; }

        public Alumnos Alumnos { get;set; }

        public Asignaturas Asignaturas { get;set;}

        public float Nota { get;set;}

        public override string ToString()
        {
            return $"{Nota}, {Alumnos.Nombre}, {Asignaturas.Nombre}";
        }

        public Evaluaciones() =>UniqueId = Guid.NewGuid().ToString();
    }
}