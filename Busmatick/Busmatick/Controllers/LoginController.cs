using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Busmatick.Models;
using Busmatick.MySql;
using MySqlX.XDevAPI.Common;

namespace Busmatick.Controllers;

public class LoginController : Controller
{
    public LoginController(Conexion db)
    {
        Db = db;
    }
    public Conexion Db { get; }

    [HttpGet]
    public async Task<IActionResult> Index2()
    {

        await Db.ConexionBD.OpenAsync();
        var query = new Login(Db);
        var result = await query.GetAll();
        return new OkObjectResult(result);
    }

    public IActionResult Index(string usuario, string clave)
    {

        if (String.IsNullOrEmpty(usuario)==true && String.IsNullOrEmpty(clave)==true)
        {
            
            ViewData["mensaje"] = "";
            return View();

        }else{
            
            Db.ConexionBD.Open();
            var query   = new Login(Db);
            var result  = query.Validar(usuario, clave);
            
            if (result == false)
            {
                ViewData["mensaje"] = "Usuario y/o contraseña inválidos!";
                return View();
            }

            var usuarios= query.Find(usuario);

            return RedirectToAction("Index", "Home", new { nombres= usuarios[0].Nombres });
        }
    }
}
