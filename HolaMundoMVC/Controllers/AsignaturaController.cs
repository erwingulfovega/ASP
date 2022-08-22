using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HolaMundoMVC.Models;
namespace HolaMundoMVC.Controllers
{
    public class AsignaturaController : Controller
    {
        public IActionResult Index()
        {
            var asignatura = new Asignatura
            {
                UniqueId = Guid.NewGuid().ToString(),
                Nombre = "Programación I"
            };

            return View(asignatura);
        }
        public IActionResult MultiAsignatura()
        {
            var listaAsignaturas = new List<Asignatura>(){
                new Asignatura{
                    UniqueId=Guid.NewGuid().ToString(),
                    Nombre="Programación I"
                },
                new Asignatura{
                    UniqueId=Guid.NewGuid().ToString(),
                    Nombre="Matemáticas"
                },
                new Asignatura{
                    UniqueId=Guid.NewGuid().ToString(),
                    Nombre="Química"
                },
                new Asignatura{
                    UniqueId=Guid.NewGuid().ToString(),
                    Nombre="Inglés"
                }

            };
            ViewBag.Fecha = DateTime.Now;
            return View(listaAsignaturas);
        }
    }
}