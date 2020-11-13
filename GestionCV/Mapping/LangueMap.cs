using GestionCV.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionCV.Mapping
{
    public class LangueMap : IEntityTypeConfiguration<Langue>
    {
        public void Configure(EntityTypeBuilder<Langue> builder)
        {
            builder.HasKey(i => i.LangueId);
            builder.Property(i => i.Nom).IsRequired().HasMaxLength(50);
            builder.HasIndex(i => i.Nom).IsUnique();

            builder.Property(i => i.Niveau).IsRequired();

            builder.HasOne(i => i.Curriculum).WithMany(i => i.Langues).HasForeignKey(i => i.CurriculumId);

            builder.ToTable("Langue");
        }
    }
}
