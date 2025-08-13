using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FighterTrainer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AjustesDataCadastro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "Usuarios",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            //migrationBuilder.AddColumn<long>(
            //    name: "Id",
            //    table: "UsuarioModalidade",
            //    type: "bigint",
            //    nullable: false,
            //    defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "Treinadores",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "Modalidade",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "Graduacao",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "Federacao",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "Atletas",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "Usuarios");

            //migrationBuilder.DropColumn(
            //    name: "Id",
            //    table: "UsuarioModalidade");

            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "Treinadores");

            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "Modalidade");

            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "Graduacao");

            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "Federacao");

            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "Atletas");
        }
    }
}
