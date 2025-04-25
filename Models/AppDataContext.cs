using Microsoft.EntityFrameworkCore;

namespace BarAPI.Models{
    public class AppDataContext : DbContext{
        
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options) { }

        public DbSet<Bebida> Cardapio { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Mesa> Mesas { get; set; }
    }
}