using EFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Data.Configurations
{
    public class CommandeConfiguration : IEntityTypeConfiguration<Commande>
    {
        public void Configure(EntityTypeBuilder<Commande> builder)
        {
            builder.ToTable("Commandes");
            builder.HasKey(c=> c.Id);
            builder.Property(c=>c.Debut).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
            builder.Property(c=>c.StatutCommande).HasConversion<string>();
            builder.Property(c=>c.TypeLivraison).HasConversion<string>();
            builder.Property(c=>c.Remarque).HasColumnType("VARCHAR(512)");

            builder.HasMany(c=> c.ItensCommandes)
                .WithOne(c=>c.Commande)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}