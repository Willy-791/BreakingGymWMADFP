using Microsoft.AspNetCore.Mvc;

namespace BreakingGymWebUI.Controllers
{
    public class InicioUsuarioController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("IdUsuario") == null)
            {
                return RedirectToAction("Login", "Login");
            }
            return View();
        }
    }
}
