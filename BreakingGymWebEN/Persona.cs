﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakingGymWebEN
{
    public abstract class Persona
    {
        public int Id { get; set; }
        public int IdRol { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Celular { get; set; }
        public Persona() { } // constructor vacio
        public Persona(int Id, int IdRol, string Nombre, string Apellido, string Celular)
        {
            this.Id = Id;
            this.IdRol = IdRol;
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.Celular = Celular;
        }
    }
}
