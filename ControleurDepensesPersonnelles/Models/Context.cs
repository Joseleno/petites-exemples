using ControleurDepensesPersonnelles.Mapping;
using Microsoft.EntityFrameworkCore;

namespace ControleurDepensesPersonnelles.Models
{
    public class Context : DbContext
    {
        public DbSet<Mois> Mois { get; set; }
        public DbSet<Salaire> Salaires { get; set; }
        public DbSet<Depense> Depenses { get; set; }
        public DbSet<TypeDepense> TypeDepenses { get; set; }
        public Context(DbContextOptions<Context> options) : base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration( new TypeDepenseMap());
            modelBuilder.ApplyConfiguration(new DepenseMap());
            modelBuilder.ApplyConfiguration(new SaleireMap());
            modelBuilder.ApplyConfiguration(new MoisMap());
        }
    }
}
