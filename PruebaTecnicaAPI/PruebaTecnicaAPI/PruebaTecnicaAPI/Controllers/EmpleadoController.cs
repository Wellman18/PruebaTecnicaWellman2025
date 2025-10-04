using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaAPI.BusinessLogic.Interface;
using PruebaTecnicaAPI.DataAccess;

namespace PruebaTecnicaAPI.Controllers
{
    [ApiController]
    [Route("")]

    public class EmpleadoController : ControllerBase
    {
        IEmpleado empleado;
        IEnumerable<Model.Empleado> listaEmpleados = Enumerable.Empty<Model.Empleado>();
        private readonly ConnectionManagerDbContext _context;

        public EmpleadoController(IEmpleado empleado, ConnectionManagerDbContext context)
        {
            this.empleado = empleado;
            this._context = context;
        }
    }
}
