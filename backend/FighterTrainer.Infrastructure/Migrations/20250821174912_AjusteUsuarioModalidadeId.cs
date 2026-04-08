using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FighterTrainer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AjusteUsuarioModalidadeId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FichasTreino_UsuarioModalidade_UsuarioModalidadeUsuarioId_U~",
                table: "FichasTreino");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuarioModalidade",
                table: "UsuarioModalidade");

            migrationBuilder.DropIndex(
                name: "IX_FichasTreino_UsuarioModalidadeUsuarioId_UsuarioModalidadeMo~",
                table: "FichasTreino");

            migrationBuilder.DropColumn(
                name: "UsuarioModalidadeModalidadeId",
                table: "FichasTreino");

            migrationBuilder.DropColumn(
                name: "UsuarioModalidadeUsuarioId",
                table: "FichasTreino");

            migrationBuilder.AddColumn<long>(
                name: "ModalidadeId1",
                table: "UsuarioModalidade",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Apelido",
                table: "Atletas",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuarioModalidade",
                table: "UsuarioModalidade",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioModalidade_ModalidadeId1",
                table: "UsuarioModalidade",
                column: "ModalidadeId1");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioModalidade_UsuarioId",
                table: "UsuarioModalidade",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_FichasTreino_UsuarioModalidadeId",
                table: "FichasTreino",
                column: "UsuarioModalidadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_FichasTreino_UsuarioModalidade_UsuarioModalidadeId",
                table: "FichasTreino",
                column: "UsuarioModalidadeId",
                principalTable: "UsuarioModalidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioModalidade_Modalidade_ModalidadeId1",
                table: "UsuarioModalidade",
                column: "ModalidadeId1",
                principalTable: "Modalidade",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FichasTreino_UsuarioModalidade_UsuarioModalidadeId",
                table: "FichasTreino");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioModalidade_Modalidade_ModalidadeId1",
                table: "UsuarioModalidade");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuarioModalidade",
                table: "UsuarioModalidade");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioModalidade_ModalidadeId1",
                table: "UsuarioModalidade");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioModalidade_UsuarioId",
                table: "UsuarioModalidade");

            migrationBuilder.DropIndex(
                name: "IX_FichasTreino_UsuarioModalidadeId",
                table: "FichasTreino");

            migrationBuilder.DropColumn(
                name: "ModalidadeId1",
                table: "UsuarioModalidade");

            migrationBuilder.AddColumn<long>(
                name: "UsuarioModalidadeModalidadeId",
                table: "FichasTreino",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UsuarioModalidadeUsuarioId",
                table: "FichasTreino",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<string>(
                name: "Apelido",
                table: "Atletas",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuarioModalidade",
                table: "UsuarioModalidade",
                columns: new[] { "UsuarioId", "ModalidadeId" });

            migrationBuilder.CreateIndex(
                name: "IX_FichasTreino_UsuarioModalidadeUsuarioId_UsuarioModalidadeMo~",
                table: "FichasTreino",
                columns: new[] { "UsuarioModalidadeUsuarioId", "UsuarioModalidadeModalidadeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_FichasTreino_UsuarioModalidade_UsuarioModalidadeUsuarioId_U~",
                table: "FichasTreino",
                columns: new[] { "UsuarioModalidadeUsuarioId", "UsuarioModalidadeModalidadeId" },
                principalTable: "UsuarioModalidade",
                principalColumns: new[] { "UsuarioId", "ModalidadeId" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
