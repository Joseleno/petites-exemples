using ControleurDepensesPersonnelles.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleurDepensesPersonnelles.Mapping
{
    public class MoisMap : IEntityTypeConfiguration<Mois>
    {
        public void Configure(EntityTypeBuilder<Mois> builder)
        {
            builder.HasKey(m => m.MoisId);
            builder.Property(m => m.MoisId).ValueGeneratedNever();
            builder.Property(m => m.Nom).HasMaxLength(15).IsRequired();

            builder.HasMany(m => m.Depenses).WithOne(m => m.Mois).HasForeignKey(m => m.MoisId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(m => m.Salaire).WithOne(m => m.Mois).OnDelete(DeleteBehavior.Cascade);
            
            builder.ToTable("Mois");
        }
    }
}
