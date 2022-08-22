using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HolaMundoMVC.Models;

namespace HolaMundoMVC.Controllers;

public class EscuelaController : Controller
{

    public IActionResult Index()
    {
        var escuela = new Escuela();
        
        escuela.AñoDeCreación=2022;
        escuela.Nombre="Liceo Máximo Mercado";
        escuela.Ciudad="Montería";
        escuela.Pais="Colombia";
        escuela.TipoEscuela=TiposEscuela.Secundaria;
        escuela.Dirección="Calle 8 Nro 12-20 Barrio Buenavista";
        //escuela.UniqueId=Guid.NewGuid().ToString();
        return View(escuela);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult About()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}