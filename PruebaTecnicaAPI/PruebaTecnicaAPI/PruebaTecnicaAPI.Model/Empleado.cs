using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaAPI.Model
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public DateTime FechaIngreso { get; set; }

        public string NombrePuesto { get; set; }

        public int IdTipoIdentificacion { get; set; }

        public string NumeroIdentificacion { get; set; }
    }
}
