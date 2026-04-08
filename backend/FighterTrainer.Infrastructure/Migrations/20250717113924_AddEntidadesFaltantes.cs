using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FighterTrainer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddEntidadesFaltantes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Usuarios",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Agilidade",
                table: "Atletas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Altura",
                table: "Atletas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Apelido",
                table: "Atletas",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Defesa",
                table: "Atletas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FocoMental",
                table: "Atletas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LutaEmPe",
                table: "Atletas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Peso",
                table: "Atletas",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Resistencia",
                table: "Atletas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Solo",
                table: "Atletas",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Wrestling",
                table: "Atletas",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Agilidade",
                table: "Atletas");

            migrationBuilder.DropColumn(
                name: "Altura",
                table: "Atletas");

            migrationBuilder.DropColumn(
                name: "Apelido",
                table: "Atletas");

            migrationBuilder.DropColumn(
                name: "Defesa",
                table: "Atletas");

            migrationBuilder.DropColumn(
                name: "FocoMental",
                table: "Atletas");

            migrationBuilder.DropColumn(
                name: "LutaEmPe",
                table: "Atletas");

            migrationBuilder.DropColumn(
                name: "Peso",
                table: "Atletas");

            migrationBuilder.DropColumn(
                name: "Resistencia",
                table: "Atletas");

            migrationBuilder.DropColumn(
                name: "Solo",
                table: "Atletas");

            migrationBuilder.DropColumn(
                name: "Wrestling",
                table: "Atletas");
        }
    }
}
