using Microsoft.AspNetCore.Mvc;

namespace BreakingGymWebUI.Controllers
{
    public class InicioAdministrador : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
