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
        InscripcionBL inscripcionBL= new InscripcionBL();
        [HttpPost]
        public IActionResult GuardarInscripcion(InscripcionEN pinscripcionEN)
        {
            if (ModelState.IsValid) 
            {
                inscripcionBL.GuardarInscripcion(pinscripcionEN);
                TempData["MensajeExito"] = "¡Solicitud de Inscripción Agregada correctamente!";
            }
            else
            {
                TempData["MensajeError"] = "¡Debe completar todos los campos!";

            }
            return View();
        }
    }
}
