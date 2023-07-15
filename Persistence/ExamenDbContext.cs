using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class ExamenDbContext : DbContext
    {
        public ExamenDbContext(DbContextOptions<ExamenDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<tblArticuloTienda>().HasKey(u => new
            {
                u.TiendaID,
                u.ArticuloID
            });

        }

        public DbSet<tblArticulo> tblArticulo { get; set;}
        public DbSet<tblCliente> tblCliente { get; set;}
        public DbSet<tblTienda> tblTienda { get; set;}
        public DbSet<tblArticuloTienda> tblArticuloTienda { get; set;}
        public DbSet<tblClienteArticulo> tblClienteArticulo { get; set; }
    }
}
