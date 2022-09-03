namespace Etapa4.Entidades
{
    public class Asignaturas
    {
        public string UniqueId { get; private set; }
        public string Nombre { get; set; }

        public Asignaturas() =>UniqueId = Guid.NewGuid().ToString();
    }
}