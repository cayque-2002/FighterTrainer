using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FighterTrainer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreatePresenca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "presenca",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    turmaid = table.Column<long>(type: "bigint", nullable: false),
                    atletaid = table.Column<long>(type: "bigint", nullable: false),
                    datahoracadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_presenca", x => x.id);
                    table.ForeignKey(
                        name: "FK_presenca_atletas_atletaid",
                        column: x => x.atletaid,
                        principalTable: "atletas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_presenca_turma_turmaid",
                        column: x => x.turmaid,
                        principalTable: "turma",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });
        }
    }
}
