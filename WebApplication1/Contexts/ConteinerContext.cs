using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Contexts
{
    public class ConteinerContext : DbContext
    {
        public ConteinerContext() { }
        public ConteinerContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"DataSource=database.db");
        }
        
        public DbSet<Conteiner> conteiner { get; set; }

        public DbSet<Movimento> movimento { get; set; }

        public DbSet<Cliente> cliente { get; set; }
    }
}
