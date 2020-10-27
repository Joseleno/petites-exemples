using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameWorkRelationships.Migrations
{
    public partial class ManyToManyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adresse",
                columns: table => new
                {
                    AdresseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Rue = table.Column<string>(type: "nvarchar", maxLength: 200, nullable: false),
                    Ville = table.Column<string>(type: "nvarchar", maxLength: 100, nullable: false),
                    CodePostal = table.Column<string>(type: "nvarchar", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresse", x => x.AdresseId);
                });

            migrationBuilder.CreateTable(
                name: "Profession",
                columns: table => new
                {
                    ProfessionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profession", x => x.ProfessionId);
                });

            migrationBuilder.CreateTable(
                name: "Telephone",
                columns: table => new
                {
                    TelephoneId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Numero = table.Column<string>(type: "nvarchar", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telephone", x => x.TelephoneId);
                });

            migrationBuilder.CreateTable(
                name: "Personne",
                columns: table => new
                {
                    PersonneId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(type: "nvarchar", maxLength: 120, nullable: false),
                    DateNaissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Poids = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    AdresseId = table.Column<int>(nullable: false),
                    TelephoneId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personne", x => x.PersonneId);
                    table.ForeignKey(
                        name: "FK_Personne_Adresse_AdresseId",
                        column: x => x.AdresseId,
                        principalTable: "Adresse",
                        principalColumn: "AdresseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personne_Telephone_TelephoneId",
                        column: x => x.TelephoneId,
                        principalTable: "Telephone",
                        principalColumn: "TelephoneId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonneProfession",
                columns: table => new
                {
                    PersonneId = table.Column<int>(nullable: false),
                    ProfessionId = table.Column<int>(nullable: false),
                    Salaire = table.Column<decimal>(type: "decimal(5,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonneProfession", x => new { x.PersonneId, x.ProfessionId });
                    table.ForeignKey(
                        name: "FK_PersonneProfession_Personne_PersonneId",
                        column: x => x.PersonneId,
                        principalTable: "Personne",
                        principalColumn: "PersonneId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonneProfession_Profession_ProfessionId",
                        column: x => x.ProfessionId,
                        principalTable: "Profession",
                        principalColumn: "ProfessionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personne_AdresseId",
                table: "Personne",
                column: "AdresseId");

            migrationBuilder.CreateIndex(
                name: "IX_Personne_TelephoneId",
                table: "Personne",
                column: "TelephoneId",
                unique: true,
                filter: "[TelephoneId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PersonneProfession_ProfessionId",
                table: "PersonneProfession",
                column: "ProfessionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonneProfession");

            migrationBuilder.DropTable(
                name: "Personne");

            migrationBuilder.DropTable(
                name: "Profession");

            migrationBuilder.DropTable(
                name: "Adresse");

            migrationBuilder.DropTable(
                name: "Telephone");
        }
    }
}
