using GestionCV.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionCV.Mapping
{
    public class TypeCoursMap : IEntityTypeConfiguration<TypeCours>
    {
        public void Configure(EntityTypeBuilder<TypeCours> builder)
        {
            builder.HasKey(tc => tc.TypeCoursId);

            builder.Property(tc => tc.Type).IsRequired();
            builder.HasIndex(tc => tc.Type).IsUnique();

            builder.HasMany(tc => tc.Formations).WithOne(tc => tc.TypeCours).OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("TypeCours");
        }
    }
}
