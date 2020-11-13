using GestionCV.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionCV.Mapping
{
    public class CurriculumMap : IEntityTypeConfiguration<Curriculum>
    {
        public void Configure(EntityTypeBuilder<Curriculum> builder)
        {
            builder.HasKey(c => c.CurriculumId);

            builder.Property(c => c.Nom).IsRequired().HasMaxLength(50);
            builder.HasIndex(c => c.Nom).IsUnique();

            builder.HasOne(c => c.Utilisateur).WithMany(c => c.Curriculums).HasForeignKey(c => c.UtilisateurId);
            builder.HasMany(c => c.Objectifs).WithOne(c => c.Curriculum).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(c => c.Formations).WithOne(c => c.Curriculum).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(c => c.ExperiencesProfessionnelles).WithOne(c => c.Curriculum).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(c => c.Langues).WithOne(c => c.Curriculum).OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Curriculum");
        }
    }
}
