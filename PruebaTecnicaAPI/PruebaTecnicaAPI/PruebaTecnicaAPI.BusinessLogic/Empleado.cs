using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaTecnicaAPI.BusinessLogic.Interface;
using PruebaTecnicaAPI.DataAccess.Interface;

namespace PruebaTecnicaAPI.BusinessLogic
{
    public class Empleado : Interface.IEmpleado
    {
        private readonly DataAccess.Interface.IEmpleado empleado;


        public Empleado(DataAccess.Interface.IEmpleado _empleado)
        {
           this.empleado = _empleado;
        }

        public void InsertarEmpleado(Model.Empleado emp)
        {
            empleado.InsertarEmpleado(emp);
        }
    }
}
