using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace EntityFrameWorkRelationships.Models
{
    public class Context : DbContext
    {
        public DbSet<Personne> Gens { get; set; }

        public Context(DbContextOptions<Context> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personne>()
                .HasKey(x => x.PersonneId);

            modelBuilder.Entity<Personne>()
                .Property(x => x.Nom).HasColumnName("Nom")
                .HasColumnType("nvarchar")
                .HasMaxLength(120)
                .IsRequired();

            modelBuilder.Entity<Personne>()
                .Property(x => x.DateNaissance)
                .HasColumnName("DateNaissance")
                .HasColumnType("datetime2")
                .IsRequired();

            modelBuilder.Entity<Personne>()
                .Property(x => x.Poids)
                .HasColumnName("Poids")
                .HasColumnType("decimal(5,2)")
                .IsRequired(false);

            modelBuilder.Entity<Personne>().ToTable("Personne");
        }



    }
}
