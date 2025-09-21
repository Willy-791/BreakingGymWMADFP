using Microsoft.AspNetCore.Mvc;
using BreakingGymWebDAL;
using BreakingGymWebBL;
using BreakingGymWebEN;

namespace BreakingGymWebUI.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string cuenta, string contrasenia)
        {
            UsuarioEN usuario = UsuarioBL.IniciarSesion(cuenta, contrasenia);

            if (usuario != null)
            {
                HttpContext.Session.SetString("Cuenta", usuario.Cuenta);
                HttpContext.Session.SetInt32("IdRol", usuario.IdRol);
                HttpContext.Session.SetInt32("IdUsuario", usuario.Id);

                

                // Redirigir por rol
                switch (usuario.IdRol)
                {
                    case 1: // Admin
                        return RedirectToAction("Index", "InicioAdministrador");

                    case 2: // Cliente
                        return RedirectToAction("Index", "InicioUsuario");

                    default:
                        ViewBag.Error = "Rol no reconocido.";
                        return View();
                }
            }
            else
            {
                ModelState.Clear();
                ViewBag.Error = "Cuenta o contraseña incorrectos.";
                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }

}
