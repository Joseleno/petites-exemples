﻿// <auto-generated />
using System;
using EntityFrameWorkRelationships.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EntityFrameWorkRelationships.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20201023141752_PersonneMigration")]
    partial class PersonneMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EntityFrameWorkRelationships.Models.Personne", b =>
                {
                    b.Property<int>("PersonneId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateNaissance")
                        .HasColumnName("DateNaissance")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnName("Nom")
                        .HasColumnType("nvarchar")
                        .HasMaxLength(120);

                    b.Property<decimal?>("Poids")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnName("Poids")
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("PersonneId");

                    b.ToTable("Personne");
                });
#pragma warning restore 612, 618
        }
    }
}
