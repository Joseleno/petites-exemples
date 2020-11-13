using GestionCV.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionCV.Mapping
{
    public class ExperienceProfessionnelleMap : IEntityTypeConfiguration<ExperienceProfessionnelle>
    {
        public void Configure(EntityTypeBuilder<ExperienceProfessionnelle> builder)
        {
            builder.HasKey(e => e.ExperienceProfessionnelleId);

            builder.Property(e => e.Entreprise).IsRequired().HasMaxLength(50);
            builder.Property(e => e.TitrePoste).IsRequired().HasMaxLength(50);
            builder.Property(e => e.AnneeDebut).IsRequired();
            builder.Property(e => e.AnneeFin);
            builder.Property(e => e.Activites).IsRequired().HasMaxLength(1000);

            builder.HasOne(e => e.Curriculum).WithMany(e => e.ExperiencesProfessionnelles).HasForeignKey(e => e.CurriculumId);

            builder.ToTable("ExperienceProfessionnelle");
        }
    }
}
