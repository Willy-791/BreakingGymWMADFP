using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreakingGymWebEN;
using BreakingGymWebDAL;

namespace BreakingGymWebBL
{
    public class EstadoBL
    {

        public static List<EstadoEN> MostrarEstado()
        {
            return EstadoDAL.MostrarEstado();
        }
        public static int GuardarEstado(EstadoEN pestadoEN)
        {
            return EstadoDAL.AgregarEstado(pestadoEN);
        }
        public static int EliminarEstado(EstadoEN pestadoEN)
        {
            return EstadoDAL.EliminarEstado(pestadoEN);
        }
        public static int ModificarEstado(EstadoEN pestadoEN)
        {
            return EstadoDAL.ModificarEstado(pestadoEN);
        }
    }
}
