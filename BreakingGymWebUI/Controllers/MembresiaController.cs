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
            var lista = MembresiaBL.MostrarMembresia();

            if (lista == null)
                lista = new List<MembresiaEN>();

            return View("Index", lista);
        }
        public IActionResult MostrarMembresia()
        {
            Response.Headers["Cache-Control"] = "no-store, no-cache, must-revalidate";
            Response.Headers["Pragma"] = "no-cache";
            Response.Headers["Expires"] = "0";


            if (HttpContext.Session.GetInt32("IdUsuario") == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var membresiaBL = new MembresiaBL();
                var lista = MembresiaBL.MostrarMembresia();

                if (lista == null)
                    lista = new List<MembresiaEN>();

                return View("MostrarMembresia", lista);
            }
        }
        public IActionResult MostrarMembresiaU()
        {
            Response.Headers["Cache-Control"] = "no-store, no-cache, must-revalidate";
            Response.Headers["Pragma"] = "no-cache";
            Response.Headers["Expires"] = "0";

            if (HttpContext.Session.GetInt32("IdUsuario") == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else {

                var lista = MembresiaBL.MostrarMembresia();

                if (lista == null)
                    lista = new List<MembresiaEN>();

                return View("MostrarMembresiaU", lista);
            }
        }

        public IActionResult Ver(int id)
        {
            if (HttpContext.Session.GetInt32("IdUsuario") == null)
            {
                return RedirectToAction("Login", "Login");
            }
            var membresia = MembresiaBL.ObtenerMembresiaPorId(id);

            if (membresia == null)
            {
                return NotFound();
            }

            return View(membresia);
        }
        public IActionResult GuardarMembresia()
        {
            Response.Headers["Cache-Control"] = "no-store, no-cache, must-revalidate";
            Response.Headers["Pragma"] = "no-cache";
            Response.Headers["Expires"] = "0";

            if (HttpContext.Session.GetInt32("IdUsuario") == null)
            {
                return RedirectToAction("Login", "Login");
            }
            return View("GuardarMembresia");
        }
        //POST: Guardar Membresia
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GuardarMembresia(MembresiaEN pmembresiaEN)
        {
            Response.Headers["Cache-Control"] = "no-store, no-cache, must-revalidate";
            Response.Headers["Pragma"] = "no-cache";
            Response.Headers["Expires"] = "0";

            if (HttpContext.Session.GetInt32("IdUsuario") == null)
            {
                return RedirectToAction("Login", "Login");
            }
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
            Response.Headers["Cache-Control"] = "no-store, no-cache, must-revalidate";
            Response.Headers["Pragma"] = "no-cache";
            Response.Headers["Expires"] = "0";

            if (HttpContext.Session.GetInt32("IdUsuario") == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var membresia = MembresiaBL.MostrarMembresia().FirstOrDefault(m => m.Id == id);
                if (membresia == null) return NotFound();
                return View("ModificarMembresia", membresia);
            }
        }

        //POST: Modificar Membresia
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ModificarMembresia(MembresiaEN pmembresiaEN)
        {
            Response.Headers["Cache-Control"] = "no-store, no-cache, must-revalidate";
            Response.Headers["Pragma"] = "no-cache";
            Response.Headers["Expires"] = "0";

            if (HttpContext.Session.GetInt32("IdUsuario") == null)
            {
                return RedirectToAction("Login", "Login");
            }
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
            Response.Headers["Cache-Control"] = "no-store, no-cache, must-revalidate";
            Response.Headers["Pragma"] = "no-cache";
            Response.Headers["Expires"] = "0";

            if (HttpContext.Session.GetInt32("IdUsuario") == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                var membresia = MembresiaBL.MostrarMembresia().FirstOrDefault(m => m.Id == id);
                if (membresia == null) return NotFound();
                return View("EliminarMembresia", membresia);
            }
        }

        //POST: Eliminar Membresia
        [HttpPost, ActionName("EliminarMembresia")]

        public IActionResult EliminarMembresiaConfirmada(int Id)
        {
            Response.Headers["Cache-Control"] = "no-store, no-cache, must-revalidate";
            Response.Headers["Pragma"] = "no-cache";
            Response.Headers["Expires"] = "0";

            if (HttpContext.Session.GetInt32("IdUsuario") == null)
            {
                return RedirectToAction("Login", "Login");
            }
            MembresiaBL.EliminarMembresia(Id);
            TempData["Mensaje"] = "Membresía eliminada correctamente.";
            return RedirectToAction(nameof(MostrarMembresia));
        }
      

        [HttpGet]
        public IActionResult ConfirmarInscripcion(int idMembresia)
        {
            Response.Headers["Cache-Control"] = "no-store, no-cache, must-revalidate";
            Response.Headers["Pragma"] = "no-cache";
            Response.Headers["Expires"] = "0";

            var idUsuario = HttpContext.Session.GetInt32("IdUsuario");

            if (idUsuario == null)
            {
                TempData["Error"] = "Debes iniciar sesión para inscribirte.";
                return RedirectToAction("Login", "Login");
            }

            var membresia = MembresiaBL.ObtenerMembresiaPorId(idMembresia);

            if (membresia == null)
            {
                TempData["Error"] = "La membresía seleccionada no existe.";
                return RedirectToAction("MostrarMembresiaU");
            }

            var inscripcionEN = new InscripcionEN
            {
                IdUsuario = idUsuario.Value,
                IdMembresia = idMembresia,
                IdEstado = 1,
                FechaInscripcion = DateTime.Now,
                FechaVencimiento = DateTime.Now.AddMonths(1)
            };

            return View("ConfirmarInscripcion", inscripcionEN);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GuardarInscripcionConfirmada(InscripcionEN inscripcionEN)
        {
            Response.Headers["Cache-Control"] = "no-store, no-cache, must-revalidate";
            Response.Headers["Pragma"] = "no-cache";
            Response.Headers["Expires"] = "0";

            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Error al procesar la inscripción.";
                return RedirectToAction("MostrarMembresiaU");
            }

            InscripcionBL.GuardarInscripcion(inscripcionEN);
            TempData["Mensaje"] = "¡Inscripción realizada con éxito!";
            return RedirectToAction("MostrarMembresiaU");
        }
    }
}