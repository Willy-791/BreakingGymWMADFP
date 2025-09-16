using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreakingGymWebEN;
using BreakingGymWebDAL;

namespace BreakingGymWebBL
{
    public class UsuarioBL
    {
        public static UsuarioEN IniciarSesion(string cuenta, string contrasenia)
        {
            return UsuarioDAL.ValidarUsuario(cuenta, contrasenia);
        }
        public static List<UsuarioEN> MostrarUsuario()
        {
            return UsuarioDAL.MostrarUsuario();
        }
        public static List<UsuarioEN> BuscarUsuario(string nombre)
        {
            return UsuarioDAL.BuscarUsuario(nombre);
        }
        public static int GuardarUsuario(UsuarioEN pusuarioEN)
        {
            return UsuarioDAL.AgregarUsuario(pusuarioEN);
        }
        public static int EliminarUsuario(int Id)
        {
            return UsuarioDAL.EliminarUsuario(Id);
        }
        public static int ModificarUsuario(UsuarioEN pusuarioEN)
        {
            return UsuarioDAL.ModificarUsuario(pusuarioEN);
        }

    }
}
