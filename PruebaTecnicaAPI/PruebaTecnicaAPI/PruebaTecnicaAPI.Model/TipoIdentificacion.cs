using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaAPI.Model
{
    public class TipoIdentificacion
    {
        [Key]
        public int IdTipoIdentificacion { get; set; }

        public string Codigo { get; set; }

        public string Descripcion { get; set; }
    }
}
