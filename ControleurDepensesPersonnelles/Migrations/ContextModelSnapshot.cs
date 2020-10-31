﻿// <auto-generated />
using ControleurDepensesPersonnelles.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ControleurDepensesPersonnelles.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ControleurDepensesPersonnelles.Models.Depense", b =>
                {
                    b.Property<int>("DepenseId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MoisId");

                    b.Property<int>("TypeDepenseId");

                    b.Property<double>("Valeur");

                    b.HasKey("DepenseId");

                    b.HasIndex("MoisId");

                    b.HasIndex("TypeDepenseId");

                    b.ToTable("Depense");
                });

            modelBuilder.Entity("ControleurDepensesPersonnelles.Models.Mois", b =>
                {
                    b.Property<int>("MoisId");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.HasKey("MoisId");

                    b.ToTable("Mois");
                });

            modelBuilder.Entity("ControleurDepensesPersonnelles.Models.Salaire", b =>
                {
                    b.Property<int>("SalaireId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MoisId");

                    b.Property<double>("Valeur");

                    b.HasKey("SalaireId");

                    b.HasIndex("MoisId")
                        .IsUnique();

                    b.ToTable("Salaire");
                });

            modelBuilder.Entity("ControleurDepensesPersonnelles.Models.TypeDepense", b =>
                {
                    b.Property<int>("TypeDepenseId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.HasKey("TypeDepenseId");

                    b.ToTable("TypeDepense");
                });

            modelBuilder.Entity("ControleurDepensesPersonnelles.Models.Depense", b =>
                {
                    b.HasOne("ControleurDepensesPersonnelles.Models.Mois", "Mois")
                        .WithMany("Depenses")
                        .HasForeignKey("MoisId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ControleurDepensesPersonnelles.Models.TypeDepense", "TypeDepense")
                        .WithMany("Depenses")
                        .HasForeignKey("TypeDepenseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ControleurDepensesPersonnelles.Models.Salaire", b =>
                {
                    b.HasOne("ControleurDepensesPersonnelles.Models.Mois", "Mois")
                        .WithOne("Salaire")
                        .HasForeignKey("ControleurDepensesPersonnelles.Models.Salaire", "MoisId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
