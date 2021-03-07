using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Repository.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questaos",
                columns: table => new
                {
                    QuestaoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Banca = table.Column<string>(nullable: true),
                    Orgao = table.Column<string>(nullable: true),
                    Disciplina = table.Column<string>(nullable: true),
                    Assunto = table.Column<string>(nullable: true),
                    Ano = table.Column<string>(nullable: true),
                    Enunciado = table.Column<string>(nullable: true),
                    ComentarioProfessor = table.Column<string>(nullable: true),
                    AlternativaA = table.Column<string>(nullable: true),
                    AlternativaB = table.Column<string>(nullable: true),
                    AlternativaC = table.Column<string>(nullable: true),
                    AlternativaD = table.Column<string>(nullable: true),
                    AlternativaE = table.Column<string>(nullable: true),
                    Resposta = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questaos", x => x.QuestaoId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Plano = table.Column<string>(nullable: true),
                    Contratacao = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Cadernos",
                columns: table => new
                {
                    CadernoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cadernos", x => x.CadernoId);
                    table.ForeignKey(
                        name: "FK_Cadernos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CadernosQuestaos",
                columns: table => new
                {
                    CadernoId = table.Column<int>(nullable: false),
                    QuestaoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CadernosQuestaos", x => new { x.CadernoId, x.QuestaoId });
                    table.ForeignKey(
                        name: "FK_CadernosQuestaos_Cadernos_CadernoId",
                        column: x => x.CadernoId,
                        principalTable: "Cadernos",
                        principalColumn: "CadernoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CadernosQuestaos_Questaos_QuestaoId",
                        column: x => x.QuestaoId,
                        principalTable: "Questaos",
                        principalColumn: "QuestaoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cadernos_UsuarioId",
                table: "Cadernos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_CadernosQuestaos_QuestaoId",
                table: "CadernosQuestaos",
                column: "QuestaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CadernosQuestaos");

            migrationBuilder.DropTable(
                name: "Cadernos");

            migrationBuilder.DropTable(
                name: "Questaos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
