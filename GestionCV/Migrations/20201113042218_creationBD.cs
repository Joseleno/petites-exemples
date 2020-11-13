using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionCV.Migrations
{
    public partial class creationBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TypeCours",
                columns: table => new
                {
                    TypeCoursId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeCours", x => x.TypeCoursId);
                });

            migrationBuilder.CreateTable(
                name: "Utilisateur",
                columns: table => new
                {
                    UtilisateurId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Courriel = table.Column<string>(maxLength: 50, nullable: false),
                    MotDePasse = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateur", x => x.UtilisateurId);
                });

            migrationBuilder.CreateTable(
                name: "Curriculum",
                columns: table => new
                {
                    CurriculumId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(maxLength: 50, nullable: false),
                    UtilisateurId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curriculum", x => x.CurriculumId);
                    table.ForeignKey(
                        name: "FK_Curriculum_Utilisateur_UtilisateurId",
                        column: x => x.UtilisateurId,
                        principalTable: "Utilisateur",
                        principalColumn: "UtilisateurId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InformationLogin",
                columns: table => new
                {
                    InformationLoginId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdresseIp = table.Column<string>(nullable: false),
                    Date = table.Column<string>(nullable: false),
                    Hour = table.Column<string>(nullable: false),
                    UtilisateurId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformationLogin", x => x.InformationLoginId);
                    table.ForeignKey(
                        name: "FK_InformationLogin_Utilisateur_UtilisateurId",
                        column: x => x.UtilisateurId,
                        principalTable: "Utilisateur",
                        principalColumn: "UtilisateurId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExperienceProfessionnelle",
                columns: table => new
                {
                    ExperienceProfessionnelleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Entreprise = table.Column<string>(maxLength: 50, nullable: false),
                    TitrePoste = table.Column<string>(maxLength: 50, nullable: false),
                    AnneeDebut = table.Column<int>(nullable: false),
                    AnneeFin = table.Column<int>(nullable: false),
                    Activites = table.Column<string>(maxLength: 1000, nullable: false),
                    CurriculumId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperienceProfessionnelle", x => x.ExperienceProfessionnelleId);
                    table.ForeignKey(
                        name: "FK_ExperienceProfessionnelle_Curriculum_CurriculumId",
                        column: x => x.CurriculumId,
                        principalTable: "Curriculum",
                        principalColumn: "CurriculumId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Formation",
                columns: table => new
                {
                    FormationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypeCoursId = table.Column<int>(nullable: false),
                    Institution = table.Column<string>(maxLength: 50, nullable: false),
                    AnneeDebut = table.Column<int>(nullable: false),
                    AnneeFin = table.Column<int>(nullable: false),
                    NomCours = table.Column<string>(maxLength: 50, nullable: false),
                    CurriculumId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formation", x => x.FormationId);
                    table.ForeignKey(
                        name: "FK_Formation_Curriculum_CurriculumId",
                        column: x => x.CurriculumId,
                        principalTable: "Curriculum",
                        principalColumn: "CurriculumId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Formation_TypeCours_TypeCoursId",
                        column: x => x.TypeCoursId,
                        principalTable: "TypeCours",
                        principalColumn: "TypeCoursId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Langue",
                columns: table => new
                {
                    LangueId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(maxLength: 50, nullable: false),
                    Niveau = table.Column<int>(nullable: false),
                    CurriculumId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Langue", x => x.LangueId);
                    table.ForeignKey(
                        name: "FK_Langue_Curriculum_CurriculumId",
                        column: x => x.CurriculumId,
                        principalTable: "Curriculum",
                        principalColumn: "CurriculumId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Objectif",
                columns: table => new
                {
                    ObjectifId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<int>(maxLength: 1000, nullable: false),
                    CurriculumId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objectif", x => x.ObjectifId);
                    table.ForeignKey(
                        name: "FK_Objectif_Curriculum_CurriculumId",
                        column: x => x.CurriculumId,
                        principalTable: "Curriculum",
                        principalColumn: "CurriculumId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Curriculum_Nom",
                table: "Curriculum",
                column: "Nom",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Curriculum_UtilisateurId",
                table: "Curriculum",
                column: "UtilisateurId");

            migrationBuilder.CreateIndex(
                name: "IX_ExperienceProfessionnelle_CurriculumId",
                table: "ExperienceProfessionnelle",
                column: "CurriculumId");

            migrationBuilder.CreateIndex(
                name: "IX_Formation_CurriculumId",
                table: "Formation",
                column: "CurriculumId");

            migrationBuilder.CreateIndex(
                name: "IX_Formation_TypeCoursId",
                table: "Formation",
                column: "TypeCoursId");

            migrationBuilder.CreateIndex(
                name: "IX_InformationLogin_UtilisateurId",
                table: "InformationLogin",
                column: "UtilisateurId");

            migrationBuilder.CreateIndex(
                name: "IX_Langue_CurriculumId",
                table: "Langue",
                column: "CurriculumId");

            migrationBuilder.CreateIndex(
                name: "IX_Langue_Nom",
                table: "Langue",
                column: "Nom",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Objectif_CurriculumId",
                table: "Objectif",
                column: "CurriculumId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeCours_Type",
                table: "TypeCours",
                column: "Type",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateur_Courriel",
                table: "Utilisateur",
                column: "Courriel",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExperienceProfessionnelle");

            migrationBuilder.DropTable(
                name: "Formation");

            migrationBuilder.DropTable(
                name: "InformationLogin");

            migrationBuilder.DropTable(
                name: "Langue");

            migrationBuilder.DropTable(
                name: "Objectif");

            migrationBuilder.DropTable(
                name: "TypeCours");

            migrationBuilder.DropTable(
                name: "Curriculum");

            migrationBuilder.DropTable(
                name: "Utilisateur");
        }
    }
}
