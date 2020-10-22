using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gens.Migrations
{
    public partial class GensMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gens",
                columns: table => new
                {
                    PersonneId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(maxLength: 80, nullable: false),
                    Age = table.Column<int>(nullable: false),
                    DateNaissance = table.Column<DateTime>(nullable: false),
                    Courriel = table.Column<string>(maxLength: 80, nullable: false),
                    ConfirmationCourriel = table.Column<string>(maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gens", x => x.PersonneId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gens");
        }
    }
}
