using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaTecnicaAPI.BusinessLogic.Interface;
using PruebaTecnicaAPI.DataAccess.Interface;

namespace PruebaTecnicaAPI.BusinessLogic
{
    public class TipoIdentificacion : Interface.ITipoIdentificacion
    {
        private readonly DataAccess.Interface.ITipoIdentificacion identificacion;


        public TipoIdentificacion(DataAccess.Interface.ITipoIdentificacion _identificacion)
        {
            this.identificacion = _identificacion;
        }

        public IEnumerable<Model.TipoIdentificacion> ListarTipoIdentificacion()
        {
            var response = identificacion.ListarTipoIdentificacion();

            return response;
        }
    }
}
