using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameWorkRelationships.Migrations
{
    public partial class OneToOneMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdresseId",
                table: "Personne",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Personne_AdresseId",
                table: "Personne",
                column: "AdresseId",
                unique: true,
                filter: "[AdresseId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Personne_Adresse_AdresseId",
                table: "Personne",
                column: "AdresseId",
                principalTable: "Adresse",
                principalColumn: "AdresseId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personne_Adresse_AdresseId",
                table: "Personne");

            migrationBuilder.DropTable(
                name: "Adresse");

            migrationBuilder.DropIndex(
                name: "IX_Personne_AdresseId",
                table: "Personne");

            migrationBuilder.DropColumn(
                name: "AdresseId",
                table: "Personne");
        }
    }
}
