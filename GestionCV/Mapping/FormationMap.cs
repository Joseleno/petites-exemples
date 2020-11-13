using GestionCV.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionCV.Mapping
{
    public class FormationMap : IEntityTypeConfiguration<Formation>
    {
        public void Configure(EntityTypeBuilder<Formation> builder)
        {
            builder.HasKey(f => f.FormationId);

            builder.Property(f => f.Institution).IsRequired().HasMaxLength(50);
            builder.Property(f => f.AnneeDebut).IsRequired();
            builder.Property(f => f.AnneeFin);
            builder.Property(f => f.NomCours).IsRequired().HasMaxLength(50);

            builder.HasOne(f => f.TypeCours).WithMany(f => f.Formations).HasForeignKey(f=> f.TypeCoursId);
            builder.HasOne(f => f.Curriculum).WithMany(f => f.Formations).HasForeignKey(f => f.CurriculumId);


            builder.ToTable("Formation");
        }
    }
}
