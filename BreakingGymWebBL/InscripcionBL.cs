using BreakingGymWebDAL;
using BreakingGymWebEN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakinGymWebBL
{
    public class InscripcionBL
    {
        public static List<InscripcionEN> MostrarInscripcion()
        {
            return InscripcionDAL.MostrarInscripcion();
        }
        public static List<InscripcionEN> BuscarInscripcion(string idCliente)
        {
            return InscripcionDAL.BuscarInscripcion(idCliente);
        }
        public static int GuardarInscripcion(InscripcionEN pinscripcionEN)
        {
            return InscripcionDAL.AgregarInscripcion(pinscripcionEN);
        }
        public static int EliminarInscripcion(int Id)
        {
            return InscripcionDAL.EliminarInscripcion(Id);
        }
        public static int ModificarInscripcion(InscripcionEN pinscripcionEN)
        {
            return InscripcionDAL.ModificarInscripcion(pinscripcionEN);
        }
    }
}
