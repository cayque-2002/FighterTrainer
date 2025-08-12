using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FighterTrainer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddLimiteAlunosTurma : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LimiteAlunos",
                table: "Turma",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "TreinadorId",
                table: "Turma",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "TurmaId",
                table: "FichasTreino",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Turma_TreinadorId",
                table: "Turma",
                column: "TreinadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Turma_UnidadeId",
                table: "Turma",
                column: "UnidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_FichasTreino_TurmaId",
                table: "FichasTreino",
                column: "TurmaId");

            migrationBuilder.AddForeignKey(
                name: "FK_FichasTreino_Turma_TurmaId",
                table: "FichasTreino",
                column: "TurmaId",
                principalTable: "Turma",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Turma_Treinadores_TreinadorId",
                table: "Turma",
                column: "TreinadorId",
                principalTable: "Treinadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Turma_Unidade_UnidadeId",
                table: "Turma",
                column: "UnidadeId",
                principalTable: "Unidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FichasTreino_Turma_TurmaId",
                table: "FichasTreino");

            migrationBuilder.DropForeignKey(
                name: "FK_Turma_Treinadores_TreinadorId",
                table: "Turma");

            migrationBuilder.DropForeignKey(
                name: "FK_Turma_Unidade_UnidadeId",
                table: "Turma");

            migrationBuilder.DropIndex(
                name: "IX_Turma_TreinadorId",
                table: "Turma");

            migrationBuilder.DropIndex(
                name: "IX_Turma_UnidadeId",
                table: "Turma");

            migrationBuilder.DropIndex(
                name: "IX_FichasTreino_TurmaId",
                table: "FichasTreino");

            migrationBuilder.DropColumn(
                name: "LimiteAlunos",
                table: "Turma");

            migrationBuilder.DropColumn(
                name: "TreinadorId",
                table: "Turma");

            migrationBuilder.DropColumn(
                name: "TurmaId",
                table: "FichasTreino");
        }
    }
}
