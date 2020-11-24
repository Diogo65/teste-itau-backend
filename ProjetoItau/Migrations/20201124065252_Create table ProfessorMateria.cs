using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoItau.Migrations
{
    public partial class CreatetableProfessorMateria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Professores_Materias_MateriaId",
                table: "Professores");

            migrationBuilder.DropIndex(
                name: "IX_Professores_MateriaId",
                table: "Professores");

            migrationBuilder.CreateTable(
                name: "MateriaProfessor",
                columns: table => new
                {
                    MateriasId = table.Column<int>(type: "int", nullable: false),
                    ProfessoresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MateriaProfessor", x => new { x.MateriasId, x.ProfessoresId });
                    table.ForeignKey(
                        name: "FK_MateriaProfessor_Materias_MateriasId",
                        column: x => x.MateriasId,
                        principalTable: "Materias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MateriaProfessor_Professores_ProfessoresId",
                        column: x => x.ProfessoresId,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfessoresMaterias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfessorId = table.Column<int>(type: "int", nullable: false),
                    MateriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessoresMaterias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfessoresMaterias_Materias_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "Materias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfessoresMaterias_Professores_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MateriaProfessor_ProfessoresId",
                table: "MateriaProfessor",
                column: "ProfessoresId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessoresMaterias_MateriaId",
                table: "ProfessoresMaterias",
                column: "MateriaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessoresMaterias_ProfessorId",
                table: "ProfessoresMaterias",
                column: "ProfessorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MateriaProfessor");

            migrationBuilder.DropTable(
                name: "ProfessoresMaterias");

            migrationBuilder.CreateIndex(
                name: "IX_Professores_MateriaId",
                table: "Professores",
                column: "MateriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Professores_Materias_MateriaId",
                table: "Professores",
                column: "MateriaId",
                principalTable: "Materias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
