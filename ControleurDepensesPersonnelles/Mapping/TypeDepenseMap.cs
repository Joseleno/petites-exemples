using ControleurDepensesPersonnelles.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleurDepensesPersonnelles.Mapping
{
    public class TypeDepenseMap : IEntityTypeConfiguration<TypeDepense>
    {
        public void Configure(EntityTypeBuilder<TypeDepense> builder)
        {
            builder.HasKey(TypeDepense => TypeDepense.TypeDepenseId);
            builder.Property(td => td.Nom).HasMaxLength(60).IsRequired();

            builder.HasMany(td => td.Depenses).WithOne(td => td.TypeDepense).HasForeignKey(td => td.TypeDepenseId);

            builder.ToTable("TypeDepense");
        }
    }
}
