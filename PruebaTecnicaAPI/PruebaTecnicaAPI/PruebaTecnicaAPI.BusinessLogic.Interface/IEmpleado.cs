using PruebaTecnicaAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaAPI.BusinessLogic.Interface
{
    public interface IEmpleado
    {
        void InsertarEmpleado(Empleado empleado);

        void ModificarEmpleado(Empleado empleado);

        void EliminarEmpleado(Empleado empleado);

        IEnumerable<Model.Empleado> ListarEmpleado();
    }
}
