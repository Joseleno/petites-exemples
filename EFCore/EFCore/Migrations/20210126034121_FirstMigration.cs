using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "VARCHAR(80)", nullable: false),
                    Tel = table.Column<string>(type: "CHAR(11)", nullable: true),
                    CEP = table.Column<string>(type: "CHAR(8)", nullable: false),
                    Province = table.Column<string>(type: "CHAR(2)", nullable: false),
                    Ville = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codebarre = table.Column<string>(type: "VARCHAR(80)", nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(60)", nullable: true),
                    Valeur = table.Column<decimal>(nullable: false),
                    TypeProduit = table.Column<string>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Commandes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(nullable: false),
                    Debut = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    Fin = table.Column<DateTime>(nullable: false),
                    TypeLivraison = table.Column<string>(nullable: false),
                    StatutCommande = table.Column<string>(nullable: false),
                    Remarque = table.Column<string>(type: "VARCHAR(512)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commandes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commandes_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItensCommandes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommandeId = table.Column<int>(nullable: false),
                    ProduitId = table.Column<int>(nullable: false),
                    Quantite = table.Column<int>(nullable: false, defaultValue: 1),
                    Valeur = table.Column<decimal>(nullable: false),
                    Remise = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensCommandes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItensCommandes_Commandes_CommandeId",
                        column: x => x.CommandeId,
                        principalTable: "Commandes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItensCommandes_Produits_ProduitId",
                        column: x => x.ProduitId,
                        principalTable: "Produits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx_client_tel",
                table: "Clients",
                column: "Tel");

            migrationBuilder.CreateIndex(
                name: "IX_Commandes_ClientId",
                table: "Commandes",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensCommandes_CommandeId",
                table: "ItensCommandes",
                column: "CommandeId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensCommandes_ProduitId",
                table: "ItensCommandes",
                column: "ProduitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItensCommandes");

            migrationBuilder.DropTable(
                name: "Commandes");

            migrationBuilder.DropTable(
                name: "Produits");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
