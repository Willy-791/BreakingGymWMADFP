using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreakingGymWebDAL;
using BreakingGymWebEN;

namespace BreakinGymWebBL
{
    public class ServicioBL
    {
        public static List<ServicioEN> MostrarServicio()
        {
            return ServicioDAL.MostrarServicio();
        }
        public static int GuardarServicio(ServicioEN pservicioEN)
        {
            return ServicioDAL.AgregarServicio(pservicioEN);
        }
        public static int EliminarServicio(int Id)
        {
            return ServicioDAL.EliminarServicio(Id);
        }
        public static int ModificarServicio(ServicioEN pservicioEN)
        {
            return ServicioDAL.ModificarServicio(pservicioEN);
        }
    }
}
