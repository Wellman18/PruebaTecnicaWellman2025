using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PruebaTecnicaWebApp.Models
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }

        public string? Nombre { get; set; }

        public string? Apellido { get; set; }

        public DateTime? FechaIngreso { get; set; }

        public string? NombrePuesto { get; set; }

        [Display(Name = "TipoIdentificacion")]
        public int? IdTipoIdentificacion { get; set; }

        public string? NumeroIdentificacion { get; set; }

        //public TipoIdentificacion Identificacion { get; set; }
    }
}
