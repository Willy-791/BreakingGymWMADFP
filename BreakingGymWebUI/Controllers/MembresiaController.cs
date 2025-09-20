using BreakingGymWebDAL;
using BreakingGymWebEN;
using BreakinGymWebBL;
using Microsoft.AspNetCore.Mvc;

namespace BreakingGymWeb.Controllers
{
    public class MembresiaController : Controller
    {
        
        public IActionResult Index()
        {

            var membresiaBL = new MembresiaBL();
            var lista = MembresiaBL.MostrarMembresia();

            if (lista == null)
                lista = new List<MembresiaEN>();


            return View("Index", lista);
        }
        public IActionResult MostrarMembresia()
        {
            var membresiaBL = new MembresiaBL();
            var lista = MembresiaBL.MostrarMembresia();

            if (lista == null)
                lista = new List<MembresiaEN>();


            return View("MostrarMembresia", lista);
        }

        public IActionResult Ver(int id)
        {
            var membresia = MembresiaBL.ObtenerMembresiaPorId(id);

            if (membresia == null)
            {
                return NotFound();
            }

            return View(membresia);
        }
        public IActionResult GuardarMembresia()
        {
            return View("GuardarMembresia");
        }
        //POST: Guardar Membresia
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GuardarMembresia(MembresiaEN pmembresiaEN)
        {
            if (ModelState.IsValid)
            {
                MembresiaBL.GuardarMembresia(pmembresiaEN);
                TempData["Mensaje"] = " Membresía guardada correctamente";
                return RedirectToAction(nameof(MostrarMembresia));
            }
            else
            {
                TempData["Error"] = "¡Debe completar todos los campos!. Vuelva a intentarlo";

            }
            return View(pmembresiaEN);
        }
        public IActionResult ModificarMembresia(int id)
        {
            var membresia = MembresiaBL.MostrarMembresia().FirstOrDefault(m => m.Id == id);
            if (membresia == null) return NotFound();
            return View("ModificarMembresia", membresia);
        }

        //POST: Modificar Membresia
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ModificarMembresia(MembresiaEN pmembresiaEN)
        {
            if (ModelState.IsValid)
            {
                MembresiaBL.ModificarMembresia(pmembresiaEN);
                TempData["Mensaje"] = " Membresía modificada correctamente";
                return RedirectToAction(nameof(MostrarMembresia));
            }
            else
            {
                TempData["Error"] = "¡No se pudo modificar!. Complete todos los campos";
            }
            return View("ModificarMembresia", pmembresiaEN);
        }

        //GET
        public IActionResult EliminarMembresia(int id)
        {
            var membresia = MembresiaBL.MostrarMembresia().FirstOrDefault(m => m.Id == id);
            if (membresia == null) return NotFound();
            return View("EliminarMembresia", membresia);
        }

        //POST: Eliminar Membresia
        [HttpPost, ActionName("EliminarMembresia")]

        public IActionResult EliminarMembresiaConfirmada(int Id)
        {
            MembresiaBL.EliminarMembresia(Id);
            TempData["Mensaje"] = "Membresía eliminada correctamente.";
            return RedirectToAction(nameof(MostrarMembresia));
        }
    }
}