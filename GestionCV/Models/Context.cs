using GestionCV.Enums;
using GestionCV.Mapping;
using Microsoft.EntityFrameworkCore;
using GestionCV.Models;

namespace GestionCV.Models
{
    public class Context : DbContext
    {
        public DbSet<Curriculum> Curriculum { get; set; }
        public DbSet<Langue> Langue { get; set; }
        public DbSet<TypeCours> TypeCours { get; set; }
        public DbSet<Formation> Formation { get; set; }
        public DbSet<Objectif> Objectif { get; set; }
        public DbSet<Utilisateur> Utilisateur { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CurriculumMap());
            modelBuilder.ApplyConfiguration(new ExperienceProfessionnelleMap());
            modelBuilder.ApplyConfiguration(new FormationMap());
            modelBuilder.ApplyConfiguration(new InformationLoginMap());
            modelBuilder.ApplyConfiguration(new LangueMap());
            modelBuilder.ApplyConfiguration(new ObjectifMap());
            modelBuilder.ApplyConfiguration(new TypeCoursMap());
            modelBuilder.ApplyConfiguration(new UtilisateurMap());

        }

        public DbSet<GestionCV.Models.InformationLogin> InformationLogin { get; set; }
    }
}