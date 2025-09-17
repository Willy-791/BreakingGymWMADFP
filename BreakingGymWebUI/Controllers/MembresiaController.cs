using BreakinGymWebBL;
using Microsoft.AspNetCore.Mvc;

namespace BreakingGymWeb.Controllers
{
    public class MembresiaController : Controller
    {
        public IActionResult Index()
        {
            var lista = new MembresiaBL().MostrarMembresia();
            return View(lista);
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
    }
}