using BreakingGymWebBL;
using BreakingGymWebEN;
using BreakinGymWebBL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace BreakingGymWebUI.Controllers
{
    public class InscripcionController : Controller
    {
        public IActionResult MostrarInscripcion()
        {
            if (HttpContext.Session.GetInt32("IdUsuario") == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var inscripcionBL = new InscripcionBL();
                var lista = InscripcionBL.MostrarInscripcion();

                if (lista == null)
                    lista = new List<InscripcionEN>();


                return View("MostrarInscripcion", lista);
            }
        }

        
        
        
        [HttpGet]
        public IActionResult ModificarInscripcion(int Id)
        {
            Response.Headers["Cache-Control"] = "no-store, no-cache, must-revalidate";
            Response.Headers["Pragma"] = "no-cache";
            Response.Headers["Expires"] = "0";

            if (HttpContext.Session.GetInt32("IdUsuario") == null)
            {
                return RedirectToAction("Login", "Login");
            }
            
            var inscripcion = InscripcionBL.MostrarInscripcion().FirstOrDefault(s => s.Id == Id);
            if (inscripcion == null) return NotFound();
            var usuarioBL = UsuarioBL.MostrarUsuario();
            ViewBag.Usuarios = new SelectList(usuarioBL, "Id", "Nombre", inscripcion.IdUsuario);
            var membresiaBL = MembresiaBL.MostrarMembresia();
            ViewBag.Membresias = new SelectList(membresiaBL, "Id", "Nombre", inscripcion.IdMembresia);
            var estadoBL = EstadoBL.MostrarEstado();
            ViewBag.Estados = new SelectList(estadoBL, "Id", "Nombre", inscripcion.IdEstado);
            return View(inscripcion);
        }

        // POST: Tarea/ModificarTarea/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ModificarInscripcion(InscripcionEN inscripcionEN)
        {
            Response.Headers["Cache-Control"] = "no-store, no-cache, must-revalidate";
            Response.Headers["Pragma"] = "no-cache";
            Response.Headers["Expires"] = "0";

            if (ModelState.IsValid)
            {
                var listaInscripcion = EstadoBL.MostrarEstado();
                bool existe = listaInscripcion.Any(e =>
                    e.Nombre.ToLower().Trim() == inscripcionEN.IdUsuario.ToString().Trim()
                    && e.Id != inscripcionEN.Id); //  evitar que choque con su propio nombre

                if (existe)
                {
                    TempData["ErrorDuplicado"] = "El estado que intentas modificar ya existe.";
                    return RedirectToAction(nameof(MostrarInscripcion));
                }

                InscripcionBL.ModificarInscripcion(inscripcionEN);
                TempData["ExitoModificar"] = "Inscripcion modificada correctamente.";
                var usuarioBL = UsuarioBL.MostrarUsuario();
                ViewBag.Usuarios = new SelectList(usuarioBL, "Id", "Nombre", inscripcionEN.IdUsuario);
                var membresiaBL = MembresiaBL.MostrarMembresia();
                ViewBag.Membresias = new SelectList(membresiaBL, "Id", "Nombre", inscripcionEN.IdMembresia);
                var estadoBL = EstadoBL.MostrarEstado();
                ViewBag.Estados = new SelectList(estadoBL, "Id", "Nombre", inscripcionEN.IdEstado);
                return RedirectToAction(nameof(MostrarInscripcion));
            }

            return View(inscripcionEN);
        }
        [HttpGet]
        public IActionResult EliminarInscripcion(int Id)
        {
            Response.Headers["Cache-Control"] = "no-store, no-cache, must-revalidate";
            Response.Headers["Pragma"] = "no-cache";
            Response.Headers["Expires"] = "0";

            if (HttpContext.Session.GetInt32("IdUsuario") == null)
            {
                return RedirectToAction("Login", "Login");
            }
            var inscripcion = InscripcionBL.MostrarInscripcion().FirstOrDefault(E => E.Id == Id);
            if (inscripcion == null) return NotFound();
            return View(inscripcion);
        }
        [HttpPost, ActionName("EliminarInscripcion")]
        public IActionResult EliminarEstadoConfirmado(int Id)
        {
            Response.Headers["Cache-Control"] = "no-store, no-cache, must-revalidate";
            Response.Headers["Pragma"] = "no-cache";
            Response.Headers["Expires"] = "0";

            InscripcionBL.EliminarInscripcion(Id);
            TempData["ExitoEliminar"] = "Estado eliminado correctamente.";
            return RedirectToAction(nameof(MostrarInscripcion));
        }

        public IActionResult BuscarInscripcion(string celular = null)
        {
            if (HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login", "Login");

            var lista = InscripcionBL.BuscarInscripcion(celular);
            return View("BuscarInscripcion", lista); // Vista multitabla
        }
    }
}

