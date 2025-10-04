using PruebaTecnicaAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaAPI.DataAccess.Interface
{
    public interface IEmpleado
    {
        void InsertarEmpleado(Model.Empleado empleado);

        void ModificarEmpleado(Empleado empleado);
    }
}
