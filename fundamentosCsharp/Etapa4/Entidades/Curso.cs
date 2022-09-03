namespace Etapa4.Entidades
{
    public class Curso
    {
        public string UniqueId { get; private set; }
        public string Nombre { get; set; }
        public TiposJornada Jornada { get; set; }
        public List<Asignaturas> Asignaturas { get;set;}
        public List<Alumnos> Alumnos { get;set;}

        public Curso() =>UniqueId = Guid.NewGuid().ToString();
    }
}