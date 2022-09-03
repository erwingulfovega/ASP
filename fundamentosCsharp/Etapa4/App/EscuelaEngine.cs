using System.Xml;
namespace Etapa4.Entidades
{
    public class EscuelaEngine
    {
        public Escuela Escuela { get; set; }

        public EscuelaEngine()
        {

        }

        public void Inicializar()
        {

            Escuela = new Escuela("Platzi", 2012, TiposEscuela.Primaria,
            pais: "Colombia", ciudad: "Bogotá");

            CargarCursos();
            CargarAsignaturas();
            CargarEvaluaciones();

        }

        private List<Alumnos> GenerarAlumnosAleatorio(int cantidad)
        {
            string[] nombres1 = { "Erwin", "Sandra", "Celeste" };
            string[] nombres2 = { "Miguel", "Vanessa", "María" };
            string[] apellidos = { "Gulfo Vega", "Orozco Pastrana", "Gulfo Orozco" };

            var listaAlumnos = from n1 in nombres1
                               from n2 in nombres2
                               from a1 in apellidos
                               select new Alumnos { Nombre = $"{n1} {n2} {a1}" };
            return listaAlumnos.OrderBy((al) => al.UniqueId).Take(cantidad).ToList();
        }

        private void CargarAsignaturas()
        {
            foreach (var curso in Escuela.Cursos)
            {
                List<Asignaturas> listaAsignaturas = new List<Asignaturas>(){
                    new Asignaturas{  Nombre = "Matemáticas"},
                    new Asignaturas{  Nombre = "Educación Física"},
                    new Asignaturas{  Nombre = "Castellano"},
                    new Asignaturas{  Nombre = "Ciencias Naturales"},
                    new Asignaturas{  Nombre = "Informática"}
                };
                curso.Asignaturas = listaAsignaturas;
            }
        }

        private void CargarCursos()
        {
            Escuela.Cursos = new List<Curso>(){
                    new Curso(){  Nombre = "101",Jornada = TiposJornada.Mañana},
                    new Curso(){  Nombre = "201",Jornada = TiposJornada.Mañana},
                    new Curso(){  Nombre = "301",Jornada = TiposJornada.Mañana},
                    new Curso(){  Nombre = "401", Jornada = TiposJornada.Tarde},
                    new Curso(){  Nombre = "501", Jornada = TiposJornada.Tarde}
            };
            Random rnd = new Random();

            foreach (var c in Escuela.Cursos)
            {
                int cantRandom = rnd.Next(5, 35);
                c.Alumnos = GenerarAlumnosAleatorio(cantRandom);
            }
        }
        private void CargarEvaluaciones()
        {
            foreach (var curso in Escuela.Cursos)
            {
                foreach (var asignaturas in curso.Asignaturas)
                {
                    foreach (var alumnos in curso.Alumnos)
                    {
                        var rnd = new Random(System.Environment.TickCount);

                        for (var i = 0; i < 5; i++)
                        {
                            var ev = new Evaluaciones
                            {
                                Asignaturas = asignaturas,
                                Nombre = $"{asignaturas.Nombre} Ev#: {i + 1}",
                                Nota = (float)(5 * rnd.NextDouble()),
                                Alumnos = alumnos
                            };
                            //alumnos.Evaluaciones.Add(ev);
                        }
                    }
                }
            }
        }

    }
}