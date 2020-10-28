using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using EntityFrameWorkRelationships.Models;

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
                .HasColumnType("text")
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

            modelBuilder.Entity<Adresse>()
                .HasKey(x => x.AdresseId);

            modelBuilder.Entity<Adresse>()
                .Property(x => x.NumeroCivique).HasColumnName("Numero")
                .HasColumnType("int")
                .IsRequired();

            modelBuilder.Entity<Adresse>()
                .Property(x => x.Rue).HasColumnName("Rue")
                .HasColumnType("text")
                .HasMaxLength(200)
                .IsRequired();

            modelBuilder.Entity<Adresse>()
                .Property(x => x.Ville).HasColumnName("Ville")
                .HasColumnType("text")
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Adresse>()
                .Property(x => x.CodePostal).HasColumnName("CodePostal")
                .HasColumnType("text")
                .HasMaxLength(8)
                .IsRequired();

            modelBuilder.Entity<Adresse>().ToTable("Adresse");

            modelBuilder.Entity<Telephone>()
               .HasKey(x => x.TelephoneId);

            modelBuilder.Entity<Telephone>()
                .Property(x => x.Numero).HasColumnName("Numero")
                .HasColumnType("text")
                .HasMaxLength(10)
                .IsRequired();

            modelBuilder.Entity<PersonneProfession>()
                .Property(x => x.Salaire)
                .HasColumnName("Salaire")
                .HasColumnType("decimal(5,2)")
                .IsRequired(false);

            modelBuilder.Entity<Personne>().HasOne(p => p.Adresse).WithMany(p => p.Personnes).HasForeignKey(p => p.AdresseId);

            modelBuilder.Entity<Adresse>().HasMany(a => a.Personnes).WithOne(a => a.Adresse);

            modelBuilder.Entity<Personne>().HasOne(x => x.Telephone).WithOne(x => x.Personne).HasForeignKey<Personne>(x => x.TelephoneId);

            modelBuilder.Entity<Telephone>().HasOne(x => x.Personne).WithOne(x => x.Telephone);

            modelBuilder.Entity<PersonneProfession>().HasKey(x => new { x.PersonneId, x.ProfessionId });

            modelBuilder.Entity<PersonneProfession>().HasOne(x => x.Personne).WithMany(x => x.PersonneProfessions).HasForeignKey(x=>x.PersonneId);

            modelBuilder.Entity<PersonneProfession>().HasOne(x => x.Profession).WithMany(x => x.PersonneProfessions).HasForeignKey(x => x.ProfessionId);
        }

        public DbSet<EntityFrameWorkRelationships.Models.PersonneProfession> PersonneProfession { get; set; }

        public DbSet<EntityFrameWorkRelationships.Models.Adresse> Adresse { get; set; }

        public DbSet<EntityFrameWorkRelationships.Models.Profession> Profession { get; set; }

        public DbSet<EntityFrameWorkRelationships.Models.Telephone> Telephone { get; set; }
    }
}
