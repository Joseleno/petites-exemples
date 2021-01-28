using EFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Data.Configurations
{
    public class ProduitConfiguration : IEntityTypeConfiguration<Produit>
    {
        public void Configure(EntityTypeBuilder<Produit> builder)
        {
            builder.ToTable("Produits");
            builder.HasKey(p=> p.Id);
            builder.Property(p=>p.Codebarre).HasColumnType("VARCHAR(80)").IsRequired();
            builder.Property(p=>p.Description).HasColumnType("VARCHAR(60)");
            builder.Property(p=>p.Valeur).IsRequired();
            builder.Property(p=>p.TypeProduit).HasConversion<string>();
        }
    }
}