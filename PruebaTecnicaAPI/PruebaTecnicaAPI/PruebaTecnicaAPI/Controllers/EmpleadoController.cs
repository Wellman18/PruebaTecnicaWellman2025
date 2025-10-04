using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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


        [HttpPost]
        [Route("ModificarEmpleado")]

        public async Task<ActionResult> ModificarEmpleado([FromBody] Model.Empleado emp)
        {
            try
            {
                var _empleado = context.Empleado.Find(emp.IdEmpleado);

                if (_empleado != null)
                {
                    _empleado.Nombre = emp.Nombre;
                    _empleado.Apellido = emp.Apellido;
                    _empleado.FechaIngreso = emp.FechaIngreso;
                    _empleado.NombrePuesto = emp.NombrePuesto;
                    _empleado.IdTipoIdentificacion = emp.IdTipoIdentificacion;
                    _empleado.NumeroIdentificacion = emp.NumeroIdentificacion;
                }

                empleado.ModificarEmpleado(_empleado);

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


        [HttpPost]
        [Route("EliminarEmpleado")]

        public async Task<ActionResult> EliminarEmpleado([FromBody] Model.Empleado emp)
        {
            try
            {
                var _empleado = context.Empleado.Find(emp.IdEmpleado);

                empleado.EliminarEmpleado(_empleado);

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
