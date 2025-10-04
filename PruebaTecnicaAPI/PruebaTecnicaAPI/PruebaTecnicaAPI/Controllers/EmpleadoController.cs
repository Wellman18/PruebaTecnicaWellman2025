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
        private readonly ConnectionManagerDbContext context;

        public EmpleadoController(IEmpleado _empleado, ConnectionManagerDbContext _context)
        {
            this.empleado = _empleado;
            this.context = _context;
        }

        [HttpPost]
        [Route("CrearEmpleado")]

        public async Task<ActionResult> CrearEmpleado([FromBody] Model.Empleado emp)
        {
            try
            {
                empleado.InsertarEmpleado(emp);

                return Ok(new
                {
                    success = true,
                    estado = StatusCode(200)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    success = false,
                    estado = ex.Message.ToString()
                });
            }
        }
    }
}
