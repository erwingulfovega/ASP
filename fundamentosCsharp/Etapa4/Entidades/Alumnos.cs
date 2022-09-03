namespace Etapa4.Entidades
{
    public class Alumnos
    {
        public string UniqueId { get; private set; }
        public string Nombre { get; set; }
        public List<Evaluaciones> Evaluaciones { get; set; }
        public Alumnos() =>UniqueId = Guid.NewGuid().ToString();
    }
}