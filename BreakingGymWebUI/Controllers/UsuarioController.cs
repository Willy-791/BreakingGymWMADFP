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
                return RedirectToAction("Login", "Usuario");
            }
            var lista = UsuarioBL.MostrarUsuario();
            return View("MostrarUsuario", lista);
        }

        // GET: Usuarios/GuardarUsuario
        public IActionResult GuardarUsuario()
        {
            return View("GuardarUsuario");
        }

        // POST: Usuarios/GuardarUsuario
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GuardarUsuario(UsuarioEN pusuarioEN)
        {
            if (ModelState.IsValid)
            {
                var listaU = UsuarioBL.MostrarUsuario();
                bool existeC = listaU.Any(u => u.Cuenta.ToLower().Trim() == pusuarioEN.Cuenta.ToLower().Trim());

                if (existeC)
                {
                    TempData["ErrorDuplicado"] = "La cuenta ingresada ya está siendo utilizada por alguien más.";
                    return RedirectToAction(nameof(GuardarUsuario));
                }

                UsuarioBL.GuardarUsuario(pusuarioEN);

                // Guardar mensaje de éxito
                TempData["ExitoGuardar"] = "¡Usuario registrado correctamente!";

                // Redirigir al Login
                return RedirectToAction("Login", "Login");
            }

            return View("GuardarUsuario", pusuarioEN);
        }

        // GET: Usuarios/ModificarUsuario/5
        public IActionResult ModificarUsuario(int id)
        {
            if (HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login", "Usuario");

            var pusuarioEN = UsuarioBL.MostrarUsuario().FirstOrDefault(u => u.Id == id);
            if (pusuarioEN == null) return NotFound();
            return View("ModificarUsuario", pusuarioEN);
        }

        // POST: Usuarios/ModificarUsuario/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ModificarUsuario(UsuarioEN pusuarioEN)
        {
            if (ModelState.IsValid)
            {
                var listaU = UsuarioBL.MostrarUsuario();
                bool existe = listaU.Any(u => u.Cuenta.ToLower().Trim() == pusuarioEN.Cuenta.ToLower().Trim() && u.Id != pusuarioEN.Id);
                bool existeN = listaU.Any(c => c.Celular.ToLower().Trim() == pusuarioEN.Celular.ToLower().Trim() && c.Id != pusuarioEN.Id);

                if (existe || existeN)
                {
                    TempData["ErrorDuplicadoModificado"] = "Algunos datos que intentas guardar ya existen.";
                    return RedirectToAction(nameof(MostrarUsuario));
                }

                UsuarioBL.ModificarUsuario(pusuarioEN);
                TempData["ExitoModificar"] = "Usuario modificado correctamente";
                return RedirectToAction(nameof(MostrarUsuario));
            }
            return View("ModificarUsuario", pusuarioEN);
        }

        // GET: Usuarios/EliminarUsuario/5
        [HttpGet]
        public IActionResult EliminarUsuario(int Id)
        {
            Response.Headers["Cache-Control"] = "no-store, no-cache, must-revalidate";
            Response.Headers["Pragma"] = "no-cache";
            Response.Headers["Expires"] = "0";

            if (HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login", "Usuario");

            var usuario = UsuarioBL.MostrarUsuario().FirstOrDefault(u => u.Id == Id);
            if (usuario == null) return NotFound();
            return View(usuario);
        }

        // POST: Usuarios/EliminarUsuario/5
        [HttpPost, ActionName("EliminarUsuario")]
        public IActionResult EliminarUsuarioConfirmado(int Id)
        {
            Response.Headers["Cache-Control"] = "no-store, no-cache, must-revalidate";
            Response.Headers["Pragma"] = "no-cache";
            Response.Headers["Expires"] = "0";

            var idUsuarioLogueado = HttpContext.Session.GetInt32("IdUsuario");

            if (idUsuarioLogueado != null && Id == idUsuarioLogueado)
            {
                TempData["ErrorEliminar"] = "No puedes eliminar el usuario con el que has iniciado sesión.";
                return RedirectToAction(nameof(MostrarUsuario));
            }

            UsuarioBL.EliminarUsuario(Id);
            TempData["ExitoEliminar"] = "Usuario eliminado correctamente.";
            return RedirectToAction(nameof(MostrarUsuario));
        }

        // GET: Usuarios/BuscarCliente
        public IActionResult BuscarCliente(string celular = null)
        {
            if (HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login", "Usuario");

            var lista = UsuarioBL.BuscarCliente(celular);
            return View("BuscarCliente", lista);
        }

        // GET: Usuarios/Login
        public IActionResult Login()
        {
            return View();
        }
    }
}
