using Microsoft.AspNetCore.Mvc;

namespace BreakingGymWebUI.Controllers
{
    public class InicioAdministrador : Controller
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
