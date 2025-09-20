using BreakingGymWebEN;
using BreakinGymWebBL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BreakingGymWebUI.Controllers
{
    public class ServicioController : Controller
    {
        public IActionResult Index()
        {
            var servicioBL = new ServicioBL();
            var lista = ServicioBL.MostrarServicio();

            if (lista == null)
                lista = new List<ServicioEN>();


            return View("Index", lista);
        }
        [HttpGet]
        public IActionResult GuardarServicio()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GuardarServicio(ServicioEN servicioEN)
        {
            if (ModelState.IsValid)
            {
                ServicioBL.GuardarServicio(servicioEN);
                TempData["ExitoGuardar"] = "Servicio guardado correctamente.";
                return RedirectToAction(nameof(Index));
            }
            return View(servicioEN);
        }
        [HttpGet]
        public IActionResult ModificarServicio(int id)
        {
            var servicio = ServicioBL.MostrarServicio().FirstOrDefault(s => s.Id == id);
            if (servicio == null) return NotFound();
            return View(servicio);
        }

        // POST: Tarea/ModificarTarea/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ModificarServicio(ServicioEN servicoEN)
        {
            if (ModelState.IsValid)
            {
                ServicioBL.ModificarServicio(servicoEN);
                TempData["ExitoModificar"] = "Servicio modificado correctamente.";
                return RedirectToAction(nameof(Index));
            }
            return View(servicoEN);
        }
        [HttpGet]
        public IActionResult EliminarServicio(int Id)
        {
            var servicio = ServicioBL.MostrarServicio().FirstOrDefault(S => S.Id == Id);
            if (servicio == null) return NotFound();
            return View(servicio); // La vista debe llamarse EliminarTarea.cshtml
        }
        [HttpPost, ActionName("EliminarServicio")]
        public IActionResult EliminarServicioConfirmado(int Id)
        {
            ServicioBL.EliminarServicio(Id);
            TempData["ExitoEliminar"] = "Servicio eliminado correctamente.";
            return RedirectToAction(nameof(Index));
        }
    }
}

