using BreakingGymWebBL;
using BreakingGymWebEN;
using BreakinGymWebBL;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace BreakingGymWebUI.Controllers
{
    public class EstadoController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("IdUsuario") == null) 
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var estadoBL = new EstadoBL();
            var lista = EstadoBL.MostrarEstado();

            if (lista == null)
                lista = new List<EstadoEN>();


            return View("Index", lista);
            }
        }
      
        [HttpGet]
        public IActionResult GuardarEstado()
        {
            Response.Headers["Cache-Control"] = "no-store, no-cache, must-revalidate";
            Response.Headers["Pragma"] = "no-cache";
            Response.Headers["Expires"] = "0";

            if (HttpContext.Session.GetInt32("IdUsuario") == null)
            {
                return RedirectToAction("Login", "Login");
            }
            return View();
        }
        [HttpPost]
        public IActionResult GuardarEstado(EstadoEN estadoEN)
        {
            Response.Headers["Cache-Control"] = "no-store, no-cache, must-revalidate";
            Response.Headers["Pragma"] = "no-cache";
            Response.Headers["Expires"] = "0";

            if (HttpContext.Session.GetInt32("IdUsuario") == null)
            {
                return RedirectToAction("Login", "Login");
            }

            if (ModelState.IsValid)
            {
                // ✅ Validar si ya existe un estado con el mismo nombre
                var listaEstados = EstadoBL.MostrarEstado();
                bool existe = listaEstados.Any(e => e.Nombre.ToLower().Trim() == estadoEN.Nombre.ToLower().Trim());

                if (existe)
                {
                    TempData["ErrorDuplicado"] = "El estado que intentas guardar ya existe.";
                    return RedirectToAction(nameof(Index));
                }

                EstadoBL.GuardarEstado(estadoEN);
                TempData["ExitoGuardar"] = "Estado guardado correctamente.";
                return RedirectToAction(nameof(Index));
            }

            return View(estadoEN);
        }
        [HttpGet]
        public IActionResult ModificarEstado(int Id)
        {
            Response.Headers["Cache-Control"] = "no-store, no-cache, must-revalidate";
            Response.Headers["Pragma"] = "no-cache";
            Response.Headers["Expires"] = "0";

            if (HttpContext.Session.GetInt32("IdUsuario") == null)
            {
                return RedirectToAction("Login", "Login");
            }
            var servicio = EstadoBL.MostrarEstado().FirstOrDefault(s => s.Id == Id);
            if (servicio == null) return NotFound();
            return View(servicio);
        }

        // POST: Tarea/ModificarTarea/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ModificarEstado(EstadoEN estadoEN)
        {
            Response.Headers["Cache-Control"] = "no-store, no-cache, must-revalidate";
            Response.Headers["Pragma"] = "no-cache";
            Response.Headers["Expires"] = "0";

            if (ModelState.IsValid)
            {
                var listaEstados = EstadoBL.MostrarEstado();
                bool existe = listaEstados.Any(e =>
                    e.Nombre.ToLower().Trim() == estadoEN.Nombre.ToLower().Trim()
                    && e.Id != estadoEN.Id); // ✅ evitar que choque con su propio nombre

                if (existe)
                {
                    TempData["ErrorDuplicado"] = "El estado que intentas modificar ya existe.";
                    return RedirectToAction(nameof(Index));
                }

                EstadoBL.ModificarEstado(estadoEN);
                TempData["ExitoModificar"] = "Estado modificado correctamente.";
                return RedirectToAction(nameof(Index));
            }

            return View(estadoEN);
        }
        [HttpGet]
        public IActionResult EliminarEstado(int Id)
        {
            Response.Headers["Cache-Control"] = "no-store, no-cache, must-revalidate";
            Response.Headers["Pragma"] = "no-cache";
            Response.Headers["Expires"] = "0";

            if (HttpContext.Session.GetInt32("IdUsuario") == null)
            {
                return RedirectToAction("Login", "Login");
            }
            var estado = EstadoBL.MostrarEstado().FirstOrDefault(E => E.Id == Id);
            if (estado == null) return NotFound();
            return View(estado); 
        }
        [HttpPost, ActionName("EliminarEstado")]
        public IActionResult EliminarEstadoConfirmado(int Id)
        {
            Response.Headers["Cache-Control"] = "no-store, no-cache, must-revalidate";
            Response.Headers["Pragma"] = "no-cache";
            Response.Headers["Expires"] = "0";

            EstadoBL.EliminarEstado(Id);
            TempData["ExitoEliminar"] = "Estado eliminado correctamente.";
            return RedirectToAction(nameof(Index));
        }


    }
}
