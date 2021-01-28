using EFCore.Domain;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Data.Configurations
{
    public class ItenCommandeConfiguration : IEntityTypeConfiguration<ItenCommande>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ItenCommande> builder)
        {
            builder.ToTable("ItensCommandes");
            builder.HasKey(i=> i.Id);
            builder.Property(i=>i.Quantite).HasDefaultValue(1).IsRequired();
            builder.Property(i=>i.Valeur).IsRequired();
            builder.Property(i=>i.Remise).IsRequired();
        }
    }
}