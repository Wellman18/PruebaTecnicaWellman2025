using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaAPI.BusinessLogic.Interface;
using PruebaTecnicaAPI.DataAccess;

namespace PruebaTecnicaAPI.Controllers
{
    [ApiController]
    [Route("")]

    public class TipoIdentificacionController : ControllerBase
    {
        ITipoIdentificacion identificacion;
        IEnumerable<Model.TipoIdentificacion> listaTipoIdentificacion = Enumerable.Empty<Model.TipoIdentificacion>();

        public TipoIdentificacionController(ITipoIdentificacion _identificacion)
        {
            this.identificacion = _identificacion;
        }

        [HttpGet]
        [Route("ObtenerTipoIdentificacion")]

        public async Task<IEnumerable<Model.TipoIdentificacion>> ObtenerTipoIdentificacion()
        {
            try
            {
                listaTipoIdentificacion = identificacion.ListarTipoIdentificacion();

                return listaTipoIdentificacion;
            }
            catch (Exception ex)
            {
                return listaTipoIdentificacion;
            }

        }


    }
}
