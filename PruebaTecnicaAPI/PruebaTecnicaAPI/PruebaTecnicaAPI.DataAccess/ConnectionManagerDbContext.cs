using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaTecnicaAPI.Model;

namespace PruebaTecnicaAPI.DataAccess
{
    public class ConnectionManagerDbContext : DbContext
    {
        public ConnectionManagerDbContext(DbContextOptions<ConnectionManagerDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder) { }


        public DbSet<Empleado> Empleado { get; set; }

        public DbSet<TipoIdentificacion> TipoIdentificacion { get; set; }
    }
}
