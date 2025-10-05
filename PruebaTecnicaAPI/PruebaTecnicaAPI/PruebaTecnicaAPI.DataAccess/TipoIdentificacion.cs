using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaTecnicaAPI.DataAccess.Interface;

namespace PruebaTecnicaAPI.DataAccess
{
    public class TipoIdentificacion : ITipoIdentificacion
    {
        private readonly ConnectionManagerDbContext context;

        public TipoIdentificacion(ConnectionManagerDbContext _context)
        {
            context = _context;
        }

        public IEnumerable<Model.TipoIdentificacion> ListarTipoIdentificacion()
        {
            var listaTipoIdentificacion = context.TipoIdentificacion.ToList();

            return listaTipoIdentificacion;
        }
    }
}
