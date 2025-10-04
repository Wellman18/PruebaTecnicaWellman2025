using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaTecnicaAPI.Model;
using PruebaTecnicaAPI.DataAccess.Interface;

namespace PruebaTecnicaAPI.DataAccess
{
    public class ConnectionManagerDbContext : DbContext,IConnectionManagerDbContext
    {
        public ConnectionManagerDbContext(DbContextOptions<ConnectionManagerDbContext> options) : base(options) 
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Model.Empleado>()
                .HasKey(e => e.IdEmpleado);

            modelBuilder.Entity<Model.TipoIdentificacion>()
                    .HasKey(e => e.IdTipoIdentificacion);
        }


        public DbSet<Model.Empleado> Empleado { get; set; }

        public DbSet<TipoIdentificacion> TipoIdentificacion { get; set; }
    }
}
