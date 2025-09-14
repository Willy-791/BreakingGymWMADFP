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
        public List<UsuarioEN> MostrarUsuario()
        {
            return UsuarioDAL.MostrarUsuario();
        }
        public static List<UsuarioEN> BuscarUsuario(string nombre)
        {
            return UsuarioDAL.BuscarUsuario(nombre);
        }
        public int GuardarUsuario(UsuarioEN pusuarioEN)
        {
            return UsuarioDAL.AgregarUsuario(pusuarioEN);
        }
        public int EliminarUsuario(UsuarioEN pusuarioEN)
        {
            return UsuarioDAL.EliminarUsuario(pusuarioEN);
        }
        public int ModificarUsuario(UsuarioEN pusuarioEN)
        {
            return UsuarioDAL.ModificarUsuario(pusuarioEN);
        }

    }
}
