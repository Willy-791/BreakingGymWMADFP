using BreakingGymWebBL;
using BreakingGymWebDAL;
using BreakingGymWebEN;
using Microsoft.AspNetCore.Mvc;

namespace BreakingGymWebUI.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        // GET: Usuarios
        public IActionResult MostrarUsuario()
        {
            if (HttpContext.Session.GetInt32("IdUsuario") == null)
            {
                return RedirectToAction("Login", "Login");
            }
            var lista = UsuarioBL.MostrarUsuario();
            return View("MostrarUsuario", lista); // Vista: MostrarUsuarios.cshtml
        }

        // GET: Usuarios/GuardarUsuario
        public IActionResult GuardarUsuario()
        {

            return View("GuardarUsuario"); // Vista: GuardarUsuario.cshtml
        }

        // POST: Usuarios/GuardarUsuario
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GuardarUsuario(UsuarioEN pusuarioEN)
        {
            if (ModelState.IsValid)
            {
                UsuarioBL.GuardarUsuario(pusuarioEN);
                TempData["MensajeExito"] = "¡Usuario registrado correctamente!";
            }
            return View("GuardarUsuario", pusuarioEN);
        }

        // GET: Usuarios/ModificarUsuario/5
        public IActionResult ModificarUsuario(int id)
        {
            if (HttpContext.Session.GetInt32("IdUsuario") == null)
            {
                return RedirectToAction("Login", "Login");
            }
            var pusuarioEN = UsuarioBL.MostrarUsuario().FirstOrDefault(u => u.Id == id);
            if (pusuarioEN == null) return NotFound();
            return View("ModificarUsuario", pusuarioEN); // Vista: ModificarUsuario.cshtml
        }

        // POST: Usuarios/ModificarUsuario/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ModificarUsuario(UsuarioEN pusuarioEN)
        {

            if (ModelState.IsValid)
            {
                UsuarioBL.ModificarUsuario(pusuarioEN);
                return RedirectToAction(nameof(MostrarUsuario));
            }
            return View("ModificarUsuario", pusuarioEN);
        }

        // GET: Usuarios/EliminarUsuario/5
        public IActionResult EliminarUsuario(int id)
        {
            if (HttpContext.Session.GetInt32("IdUsuario") == null)
            {
                return RedirectToAction("Login", "Login");
            }
            var usuario = UsuarioBL.MostrarUsuario().FirstOrDefault(u => u.Id == id);
            if (usuario == null) return NotFound();
            return View("EliminarUsuario", usuario); // Vista: EliminarUsuario.cshtml
        }

        // POST: Usuarios/EliminarUsuario/5
        [HttpPost, ActionName("EliminarUsuario")]
        [ValidateAntiForgeryToken]
        public IActionResult EliminarUsuarioConfirmado(int id)
        {
            UsuarioBL.EliminarUsuario(id);
            return RedirectToAction(nameof(MostrarUsuario));
        }
        public IActionResult BuscarCliente(string celular = null)
        {
            if (HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login", "Login");

            var lista = UsuarioBL.BuscarCliente(celular);
            return View("BuscarCliente", lista); // Vista multitabla
        }
    }
}