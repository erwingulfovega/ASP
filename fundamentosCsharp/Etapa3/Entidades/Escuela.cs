namespace Etapa3.Entidades
{
    class Escuela
    {
        string nombre = "";
        public string Nombre
        {
            get { return "Copia del nombre: " + nombre; }
            set { nombre = value.ToUpper(); }
        }
        public int añoCreacion { get; set; }
        public string? Pais { get; set; }
        public string? Ciudad { get; set; }

        public TiposEscuela TipoEscuela { get; set; }

        //public List<Curso> Cursos { get; set; }
        public List<Curso> Cursos { get; set; }
        //Igualación por tuplas
        public Escuela(string nombre, int año) => (Nombre, añoCreacion) = (nombre, año);

        public Escuela(string nombre, int año, 
                TiposEscuela Tipo, 
                string pais = "", string ciudad = "")
        {
                (Nombre, añoCreacion) = (nombre, año);
                (Pais, Ciudad) = (pais, ciudad);
        }

        public override string ToString()
        {
            return $"Nombre: \"{Nombre}\", Tipo: {TipoEscuela} {System.Environment.NewLine} Pais: {Pais}, Ciudad: {Ciudad}";
        }


    }
}