using EFCore.Data.Configurations;
using EFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFCore.Data
{
    public class ApplicationContext : DbContext 
    {
        private static readonly ILoggerFactory _logger = LoggerFactory.Create(p=>p.AddConsole());
        public DbSet<Commande> Commandes{get; set;}
        public DbSet<Produit> Produits { get; set; }
        public DbSet<Client> Clients{ get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
            .UseLoggerFactory(_logger)
            .EnableSensitiveDataLogging()
            .UseSqlServer("Data source=SDM-DEV\\SQL;Initial Catalog=EFCore;Trusted_Connection=True; Integrated Security=True; ");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }

    }
}