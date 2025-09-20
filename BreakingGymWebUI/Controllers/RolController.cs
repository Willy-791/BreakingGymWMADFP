using BreakingGymWebBL;
using BreakingGymWebEN;
using Microsoft.AspNetCore.Mvc;

namespace BreakingGymWebUI.Controllers
{
    public class RolController : Controller
    {
        public IActionResult Index()
        {
            var rolBL = new RolBL();
            var lista = RolBL.MostrarRol();

            if (lista == null)
                lista = new List<RolEN>();


            return View("Index", lista);
        }

        [HttpGet]
        public IActionResult GuardarRol()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GuardarRol(RolEN rolEN)
        {
            if (ModelState.IsValid)
            {
                RolBL.GuardarRol(rolEN);
                TempData["ExitoGuardar"] = "Rol guardado correctamente.";
                return RedirectToAction(nameof(Index));
            }
            return View(rolEN);
        }
        [HttpGet]
        public IActionResult ModificarRol(int Id)
        {
            var rol = RolBL.MostrarRol().FirstOrDefault(r => r.Id == Id);
            if (rol == null) return NotFound();
            return View(rol);
        }

        // POST: Tarea/ModificarTarea/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ModificarRol(RolEN rolEN)
        {
            if (ModelState.IsValid)
            {
                RolBL.ModificarRol(rolEN);
                TempData["ExitoModificar"] = "Rol modificado correctamente.";
                return RedirectToAction(nameof(Index));
            }
            return View(rolEN);
        }
        [HttpGet]
        public IActionResult EliminarRol(int Id)
        {
            var rol = RolBL.MostrarRol().FirstOrDefault(r => r.Id == Id);
            if (rol == null) return NotFound();
            return View(rol);
        }
        [HttpPost, ActionName("EliminarRol")]
        public IActionResult EliminarRolConfirmado(int Id)
        {
            RolBL.EliminarRol(Id);
            TempData["ExitoEliminar"] = "Rol eliminado correctamente.";
            return RedirectToAction(nameof(Index));
        }


    }
}
