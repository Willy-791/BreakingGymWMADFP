using BreakingGymWebDAL;
using BreakingGymWebEN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakinGymWebBL
{
    public class MembresiaBL
    {
        public static MembresiaEN ObtenerMembresiaPorId(int id)
        {
            // Llama al método estático de la DAL directamente
            return MembresiaDAL.ObtenerMembresiaPorId(id);
        }
        public static List<MembresiaEN> MostrarMembresia()
        {
            return MembresiaDAL.MostrarMembresia();
        }
        public static List<MembresiaEN> BuscarMembresia(string nombre)
        {
            return MembresiaDAL.BuscarMembresia(nombre);
        }
        public static int GuardarMembresia(MembresiaEN pmembresiaEN)
        {
            return MembresiaDAL.AgregarMembresia(pmembresiaEN);
        }
        public static int EliminarMembresia(int Id)
        {
            return MembresiaDAL.EliminarMembresia(Id);
        }
        public static int ModificarMembresia(MembresiaEN pmembresiaEN)
        {
            return MembresiaDAL.ModificarMembresia(pmembresiaEN);
        }
    }
}
