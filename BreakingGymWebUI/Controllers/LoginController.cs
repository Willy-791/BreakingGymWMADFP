using Microsoft.AspNetCore.Mvc;

namespace BreakingGymWebUI.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //GET:
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        //POST: Login
        [HttpPost]
        public IActionResult Login(string cuenta, string password)
        {
            if (cuenta == "" && password == "")
            {
                HttpContext.Session.SetString("", cuenta);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = "Cuenta o contraseña incorrectos";
                return View();
            }
        }
        //GET: Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
