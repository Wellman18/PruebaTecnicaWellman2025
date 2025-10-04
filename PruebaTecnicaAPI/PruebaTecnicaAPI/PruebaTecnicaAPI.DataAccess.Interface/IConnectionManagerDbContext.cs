using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaAPI.Model;

namespace PruebaTecnicaAPI.DataAccess.Interface
{
    public interface IConnectionManagerDbContext
    {
        DbSet<Empleado> Empleado { get; set; }

        DbSet<TipoIdentificacion> TipoIdentificacion { get;set; }
    }
}
