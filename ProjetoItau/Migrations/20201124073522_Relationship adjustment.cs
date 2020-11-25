using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoItau.Migrations
{
    public partial class Relationshipadjustment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MateriaProfessor");

            migrationBuilder.DropColumn(
                name: "MateriaId",
                table: "Professores");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MateriaId",
                table: "Professores",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_MateriaProfessor_ProfessoresId",
                table: "MateriaProfessor",
                column: "ProfessoresId");
        }
    }
}
