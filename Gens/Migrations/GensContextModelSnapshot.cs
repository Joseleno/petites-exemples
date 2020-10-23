﻿// <auto-generated />
using System;
using Gens.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Gens.Migrations
{
    [DbContext(typeof(GensContext))]
    partial class GensContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Gens.Models.Personne", b =>
                {
                    b.Property<int>("PersonneId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age");

                    b.Property<string>("ConfirmationCourriel")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<string>("Courriel")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<DateTime>("DateNaissance");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.HasKey("PersonneId");

                    b.ToTable("Gens");
                });
#pragma warning restore 612, 618
        }
    }
}