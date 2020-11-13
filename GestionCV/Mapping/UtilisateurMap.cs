using GestionCV.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace GestionCV.Mapping
{
    public class UtilisateurMap : IEntityTypeConfiguration<Utilisateur>
    {
        public void Configure(EntityTypeBuilder<Utilisateur> builder)
        {
            builder.HasKey(u => u.UtilisateurId);

            builder.Property(u=> u.Courriel).IsRequired();
            builder.HasIndex(u=> u.Courriel).IsUnique();

            builder.Property(u => u.MotDePasse).IsRequired().HasMaxLength(20);

            builder.HasMany(u => u.Curriculums).WithOne(u => u.Utilisateur).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(u => u.InformationLogin).WithOne(u => u.Utilisateur).OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.InformationLogin).WithOne(u => u.Utilisateur).OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Utilisateur");
        }

    }
}
