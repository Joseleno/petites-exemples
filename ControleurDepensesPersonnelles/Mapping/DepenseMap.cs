using ControleurDepensesPersonnelles.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleurDepensesPersonnelles.Mapping
{
    public class DepenseMap : IEntityTypeConfiguration<Depense>
    {
        public void Configure(EntityTypeBuilder<Depense> builder)
        {
            builder.HasKey(d => d.DepenseId);

            builder.Property(d => d.Valeur).IsRequired();


            builder.HasOne(d => d.Mois).WithMany(d => d.Depenses).HasForeignKey(d => d.MoisId);
            builder.HasOne(d => d.TypeDepense).WithMany(d => d.Depenses).HasForeignKey(d => d.TypeDepenseId);

            builder.ToTable("Depense");
        }
    }
}
