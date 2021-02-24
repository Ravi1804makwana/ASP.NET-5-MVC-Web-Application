using Microsoft.EntityFrameworkCore;

namespace MyWeb.Models
{
    public class AppContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Games> Games { get; set; }
        public DbSet<Movie> Movies { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MyWebDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            base.OnConfiguring(optionsBuilder);
        }
    }
}