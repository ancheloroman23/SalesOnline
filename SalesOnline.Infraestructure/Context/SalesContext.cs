using Microsoft.EntityFrameworkCore;
using SalesOnline.Domain.Entities;


namespace SalesOnline.Infraestructure.Context
{
    public class SalesContext : DbContext
    {
        public SalesContext(DbContextOptions<SalesContext> options) : base(options)
        {

        }

        public DbSet<Rol> rol { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

    }
}
