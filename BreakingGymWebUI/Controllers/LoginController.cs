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
        public IActionResult Login(string cuenta, string password)
        {
            if (string.IsNullOrEmpty(cuenta) || string.IsNullOrEmpty(password))
            {
                ViewBag.Error = "Debe ingresar usuario y contraseña";
                return View();
            }

            // 🔹 Lógica de autenticación 
            UsuarioEN usuario = UsuarioBL.IniciarSesion(cuenta, password);

            if (usuario != null)
            {
                // ✅ Guardar datos en sesión
                HttpContext.Session.SetString("Cuenta", usuario.Cuenta);
                HttpContext.Session.SetInt32("IdRol", usuario.IdRol);

                // 🔹 Redirigir según el rol
                if (usuario.IdRol == 1) // Administrador
                {
                    return RedirectToAction("Index", "Administrador");
                }
                else if (usuario.IdRol == 2) // Cliente
                {
                    return RedirectToAction("Index", "Cliente");
                }
                else
                {
                    ViewBag.Error = "Rol no reconocido.";
                    return View();
                }
            }
            else
            {
                ViewBag.Error = "Usuario o contraseña incorrectos";
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
