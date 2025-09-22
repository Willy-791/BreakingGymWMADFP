using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakingGymWebEN
{
    public class InscripcionEN
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; } = string.Empty;

        public int IdMembresia { get; set; }
        public string NombreMembresia { get; set; } = string.Empty;
        public int IdEstado { get; set; }
        public DateTime? FechaInscripcion { get; set; }
        public DateTime? FechaVencimiento { get; set; }
    }
}
