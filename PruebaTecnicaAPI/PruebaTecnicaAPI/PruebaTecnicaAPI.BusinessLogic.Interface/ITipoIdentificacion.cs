using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaAPI.BusinessLogic.Interface
{
    public interface ITipoIdentificacion
    {
        IEnumerable<Model.TipoIdentificacion> ListarTipoIdentificacion();
    }
}
