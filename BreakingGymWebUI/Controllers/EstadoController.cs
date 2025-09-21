using BreakingGymWebBL;
using BreakingGymWebEN;
using BreakinGymWebBL;
using Microsoft.AspNetCore.Mvc;

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
            if (HttpContext.Session.GetInt32("IdUsuario") == null)
            {
                return RedirectToAction("Login", "Login");
            }
            return View();
        }
        [HttpPost]
        public IActionResult GuardarEstado(EstadoEN estadoEN)
        {
            if (HttpContext.Session.GetInt32("IdUsuario") == null)
            {
                return RedirectToAction("Login", "Login");
            }
            if (ModelState.IsValid) 
            { 
                EstadoBL.GuardarEstado(estadoEN);
                TempData["ExitoGuardar"] = "Servicio guardado correctamente.";
                return RedirectToAction(nameof(Index));
            }
            return View(estadoEN);
        }
        [HttpGet]
        public IActionResult ModificarEstado(int Id)
        {
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
            if (ModelState.IsValid)
            {
                EstadoBL.ModificarEstado(estadoEN);
                TempData["ExitoModificar"] = "Estado modificado correctamente.";
                return RedirectToAction(nameof(Index));
            }
            return View(estadoEN);
        }
        [HttpGet]
        public IActionResult EliminarEstado(int Id)
        {
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
            EstadoBL.EliminarEstado(Id);
            TempData["ExitoEliminar"] = "Estado eliminado correctamente.";
            return RedirectToAction(nameof(Index));
        }


    }
}
