using ControleurDepensesPersonnelles.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleurDepensesPersonnelles.Mapping
{
    public class SaleireMap : IEntityTypeConfiguration<Salaire>
    {
        public void Configure(EntityTypeBuilder<Salaire> builder)
        {
            builder.HasKey(s => s.SalaireId);
            
            builder.Property(s => s.Valeur).IsRequired();

            
            builder.HasOne(s => s.Mois).WithOne(s => s.Salaire).HasForeignKey<Salaire>(s=> s.MoisId);

            builder.ToTable("Salaire");
        }
    }
}
