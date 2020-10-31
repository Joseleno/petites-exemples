using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleurDepensesPersonnelles.Migrations
{
    public partial class CreationBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mois",
                columns: table => new
                {
                    MoisId = table.Column<int>(nullable: false),
                    Nom = table.Column<string>(maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mois", x => x.MoisId);
                });

            migrationBuilder.CreateTable(
                name: "TypeDepense",
                columns: table => new
                {
                    TypeDepenseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeDepense", x => x.TypeDepenseId);
                });

            migrationBuilder.CreateTable(
                name: "Salaire",
                columns: table => new
                {
                    SalaireId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MoisId = table.Column<int>(nullable: false),
                    Valeur = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salaire", x => x.SalaireId);
                    table.ForeignKey(
                        name: "FK_Salaire_Mois_MoisId",
                        column: x => x.MoisId,
                        principalTable: "Mois",
                        principalColumn: "MoisId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Depense",
                columns: table => new
                {
                    DepenseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MoisId = table.Column<int>(nullable: false),
                    TypeDepenseId = table.Column<int>(nullable: false),
                    Valeur = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Depense", x => x.DepenseId);
                    table.ForeignKey(
                        name: "FK_Depense_Mois_MoisId",
                        column: x => x.MoisId,
                        principalTable: "Mois",
                        principalColumn: "MoisId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Depense_TypeDepense_TypeDepenseId",
                        column: x => x.TypeDepenseId,
                        principalTable: "TypeDepense",
                        principalColumn: "TypeDepenseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Depense_MoisId",
                table: "Depense",
                column: "MoisId");

            migrationBuilder.CreateIndex(
                name: "IX_Depense_TypeDepenseId",
                table: "Depense",
                column: "TypeDepenseId");

            migrationBuilder.CreateIndex(
                name: "IX_Salaire_MoisId",
                table: "Salaire",
                column: "MoisId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Depense");

            migrationBuilder.DropTable(
                name: "Salaire");

            migrationBuilder.DropTable(
                name: "TypeDepense");

            migrationBuilder.DropTable(
                name: "Mois");
        }
    }
}
