using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakingGymWebEN
{
    public class UsuarioEN : Persona
    {
        public string Cuenta { get; set; }
        public string Contrasenia { get; set; }
        public string? Nombre_Rol { get; set; } 

        public UsuarioEN() : base()
        {
        }

        //  Constructor sin Nombre_Rol (para guardar)
        public UsuarioEN(int Id, int IdRol, string Nombre, string Apellido, string Celular, string Cuenta, string Contrasenia)
            : base(Id, IdRol, Nombre, Apellido, Celular)
        {
            this.Cuenta = Cuenta;
            this.Contrasenia = Contrasenia;
        }

        //  Constructor extendido con Nombre_Rol (para mostrar)
        public UsuarioEN(int Id, int IdRol, string Nombre, string Apellido, string Celular, string Cuenta, string Contrasenia, string Nombre_Rol)
            : base(Id, IdRol, Nombre, Apellido, Celular)
        {
            this.Cuenta = Cuenta;
            this.Contrasenia = Contrasenia;
            this.Nombre_Rol = Nombre_Rol;
        }
    }
}