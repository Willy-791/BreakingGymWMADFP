using BreakingGymWebEN;
using BreakinGymWebBL;
using Microsoft.AspNetCore.Mvc;

namespace BreakingGymWebUI.Controllers
{
    public class ServicioController : Controller
    {
        public IActionResult Index()
        {
            var servicioBL = new ServicioBL();
            var lista = servicioBL.MostrarServicio();

            if (lista == null)
                lista = new List<ServicioEN>();


            return View("Index", lista);
        }
    }
}