using GestionCV.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionCV.Mapping
{
    public class ObjectifMap : IEntityTypeConfiguration<Objectif>
    {
        public void Configure(EntityTypeBuilder<Objectif> builder)
        {
            builder.HasKey(o => o.ObjectifId);
            builder.Property(o => o.Description).IsRequired().HasMaxLength(1000);

            builder.HasOne(o => o.Curriculum).WithMany(o => o.Objectifs).HasForeignKey(o=>o.CurriculumId);

            builder.ToTable("Objectif");
        }
    }
}