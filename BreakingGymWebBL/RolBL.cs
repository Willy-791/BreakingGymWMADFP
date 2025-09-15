using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreakingGymWebEN;
using BreakingGymWebDAL;

namespace BreakingGymWebBL
{
    public class RolBL
    {
        public static List<RolEN> MostrarRol()
        {
            return RolDAL.MostrarRol();
        }
        public static int GuardarRol(RolEN prolEN)
        {
            return RolDAL.AgregarRol(prolEN);
        }
        public static int EliminarRol(RolEN prolEN)
        {
            return RolDAL.EliminarRol(prolEN);
        }
        public static int ModificarRol(RolEN prolEN)
        {
            return RolDAL.ModificarRol(prolEN);
        }
    }
}
