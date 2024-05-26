using app_ventas_ds502.Models;
using Microsoft.EntityFrameworkCore;


namespace app_ventas_ds502.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 
        }

        public DbSet<Personal> Personal { get; set; }

        public DbSet<Producto> Producto { get; set; }

        public DbSet<Categoria> Categoria { get; set; }

        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<Compra> Compra { get; set; }

        public DbSet<Pedido> Pedido { get; set; }

        public DbSet<Proveedor> Proveedor { get; set; }

        
    }
}
