using Microsoft.AspNetCore.Mvc;

namespace BreakingGymWebUI.Controllers
{
    public class InicioUsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
