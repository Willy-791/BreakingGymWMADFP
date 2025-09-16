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

        // POST: Login
        [HttpPost]
        public IActionResult Login(string cuenta, string contrasenia)
        {
            // 🔹 Usar el método de tu BL
            UsuarioEN usuario = UsuarioBL.IniciarSesion(cuenta, contrasenia);

            if (usuario != null)
            {
                // Guardar sesión
                HttpContext.Session.SetString("Cuenta", usuario.Cuenta);
                HttpContext.Session.SetInt32("IdRol", usuario.IdRol);

                // Redirigir según Rol
                if (usuario.IdRol == 1) // Administrador
                {
                    return RedirectToAction("Index", "InicioAdministrador");
                }
                else if (usuario.IdRol == 2) // Cliente
                {
                    return RedirectToAction("Index", "InicioUsuario");
                }
                else
                {
                    ViewBag.Error = "Rol no reconocido.";
                    return View();
                }
            }
            else
            {
                ViewBag.Error = "Cuenta o contraseña incorrectos.";
                return View();
            }
        }

        // GET: Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
