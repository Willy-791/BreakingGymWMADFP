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
                var listaInscripcion = InscripcionBL.MostrarInscripcion();
                bool existe = listaInscripcion.Any(e =>
                    e.IdUsuario.ToString().Trim() == inscripcionEN.IdUsuario.ToString().Trim()
                    && e.Id != inscripcionEN.Id); //  evitar que choque con su propio nombre

                if (existe)
                {
                    TempData["ErrorDuplicado"] = "Este usuario  ya tiene una inscripcion.";
                    return RedirectToAction(nameof(MostrarInscripcion));
                }
               

                InscripcionBL.ModificarInscripcion(inscripcionEN);
                var usuarioBL = UsuarioBL.MostrarUsuario();
                ViewBag.Usuarios = new SelectList(usuarioBL, "Id", "Nombre", inscripcionEN.IdUsuario);
                var membresiaBL = MembresiaBL.MostrarMembresia();
                ViewBag.Membresias = new SelectList(membresiaBL, "Id", "Nombre", inscripcionEN.IdMembresia);
                var estadoBL = EstadoBL.MostrarEstado();
                ViewBag.Estados = new SelectList(estadoBL, "Id", "Nombre", inscripcionEN.IdEstado);

                TempData["ExitoModificar"] = "Inscripcion modificada correctamente.";
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
            TempData["ExitoEliminar"] = "Inscripcion eliminada correctamente.";
            return RedirectToAction(nameof(MostrarInscripcion));
        }

        public IActionResult BuscarInscripcion(string celular = null)
        {
            if (HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login", "Login");

            var lista = InscripcionBL.BuscarInscripcion(celular);
            return View("BuscarInscripcion", lista); // Vista multitabla
        }

        [HttpPost]
        public IActionResult CambiarEstadoInscripcion(int id)
        {
            if (HttpContext.Session.GetInt32("IdUsuario") == null)
                return RedirectToAction("Login", "Login");

            var inscripcion = InscripcionBL.MostrarInscripcion().FirstOrDefault(e => e.Id == id);
            if (inscripcion == null) return NotFound();

            // Alternar estado
            if (inscripcion.IdEstado == 1)
                inscripcion.IdEstado = 2; // Cambiar a inactivo
            else
                inscripcion.IdEstado = 1; // Cambiar a activo

            InscripcionBL.ModificarInscripcion(inscripcion);

            TempData["ExitoCambioEstado"] = "El estado de la inscripción fue cambiado correctamente.";
            return RedirectToAction(nameof(MostrarInscripcion));
        }

    }
}

