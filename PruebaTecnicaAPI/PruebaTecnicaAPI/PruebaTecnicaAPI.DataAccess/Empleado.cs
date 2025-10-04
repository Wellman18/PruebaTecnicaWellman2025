using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaTecnicaAPI.DataAccess.Interface;
using Microsoft.EntityFrameworkCore;


namespace PruebaTecnicaAPI.DataAccess
{
    public class Empleado : IEmpleado
    {
        private readonly ConnectionManagerDbContext context;

        public Empleado(ConnectionManagerDbContext _context)
        {
            context = _context;
        }

        public void InsertarEmpleado(Model.Empleado _emp)
        {

            context.Empleado.Add(_emp);
            context.SaveChanges();
        }

        public void ModificarEmpleado(Model.Empleado _emp)
        {
            context.Update(_emp);
            context.SaveChanges();
        }
    }
}
