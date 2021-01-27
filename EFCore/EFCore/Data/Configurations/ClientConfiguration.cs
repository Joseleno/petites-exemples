using EFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Data.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Clients");
            builder.HasKey(c=> c.Id);
            builder.Property(c=>c.Nom).HasColumnType("VARCHAR(80)").IsRequired();
            builder.Property(c=>c.Tel).HasColumnType("CHAR(11)");
            builder.Property(c=>c.CEP).HasColumnType("CHAR(8)").IsRequired();
            builder.Property(c=>c.Province).HasColumnType("CHAR(2)").IsRequired();
            builder.Property(c=>c.Ville).HasMaxLength(60).IsRequired();

            builder.HasIndex(i => i.Tel).HasName("idx_client_tel");
        }
    }
}