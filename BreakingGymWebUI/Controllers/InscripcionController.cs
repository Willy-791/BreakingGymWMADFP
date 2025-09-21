using BreakingGymWebBL;
using BreakingGymWebEN;
using BreakinGymWebBL;
using Microsoft.AspNetCore.Mvc;
namespace BreakingGymWebUI.Controllers
{
    public class InscripcionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
       
        [HttpPost]
        public IActionResult GuardarInscripcion()
        {

            return View("GuardarInscripcion"); 
        }

        // POST: Usuarios/GuardarUsuario
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GuardarInscripcion(InscripcionEN inscripcionEN)
        {
            // Obtener IdUsuario del usuario logueado
            var idUsuario = HttpContext.Session.GetInt32("IdUsuario");
            if (idUsuario == null)
            {
                return RedirectToAction("Login", "Usuario");
            }

            // Obtener membresía seleccionada para calcular FechaVencimiento
           

            // Crear objeto Inscripcion
            var inscripcion = new InscripcionEN
            {
                IdUsuario = idUsuario.Value,
             
                IdEstado = 1, // Activa
                FechaInscripcion = DateTime.Now,
            
            };

            // Guardar en la base de datos
            InscripcionBL.GuardarInscripcion(inscripcion);

            TempData["MensajeExito"] = "¡Inscripción registrada correctamente!";
            return RedirectToAction("Index", "Membresia");
        }
    }
}
