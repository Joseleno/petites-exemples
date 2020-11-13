using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GestionCV.Models;

namespace GestionCV.Mapping
{
    public class InformationLoginMap : IEntityTypeConfiguration<InformationLogin>
    {
        public void Configure(EntityTypeBuilder<InformationLogin> builder)
        {
            builder.HasKey(i => i.InformationLoginId);
            builder.Property(i => i.AdresseIp).IsRequired();
            builder.Property(i => i.Date).IsRequired();
            builder.Property(i => i.Hour).IsRequired();

            builder.HasOne(i => i.Utilisateur).WithMany(i => i.InformationLogin).HasForeignKey(i => i.UtilisateurId);

            builder.ToTable("InformationLogin");
        }
    }
}
