using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FighterTrainer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUsuarioModalidade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Atletas",
            //    columns: table => new
            //    {
            //        Id = table.Column<long>(type: "bigint", nullable: false)
            //            .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
            //        UsuarioId = table.Column<long>(type: "bigint", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Atletas", x => x.Id);
            //    });

            migrationBuilder.CreateTable(
                name: "Federacao",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Federacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modalidade",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modalidade", x => x.Id);
                });

            //migrationBuilder.CreateTable(
            //    name: "Treinadores",
            //    columns: table => new
            //    {
            //        Id = table.Column<long>(type: "bigint", nullable: false)
            //            .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
            //        UsuarioId = table.Column<long>(type: "bigint", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Treinadores", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Usuarios",
            //    columns: table => new
            //    {
            //        Id = table.Column<long>(type: "bigint", nullable: false)
            //            .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
            //        Nome = table.Column<string>(type: "text", nullable: false),
            //        Email = table.Column<string>(type: "text", nullable: false),
            //        SenhaHash = table.Column<string>(type: "text", nullable: false),
            //        TipoUsuario = table.Column<int>(type: "integer", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Usuarios", x => x.Id);
            //    });

            migrationBuilder.CreateTable(
                name: "Graduacao",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ModalidadeId = table.Column<long>(type: "bigint", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    Nivel = table.Column<int>(type: "integer", nullable: false),
                    Grau = table.Column<int>(type: "integer", nullable: true),
                    FederacaoId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Graduacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Graduacao_Federacao_FederacaoId",
                        column: x => x.FederacaoId,
                        principalTable: "Federacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioModalidade",
                columns: table => new
                {
                    UsuarioId = table.Column<long>(type: "bigint", nullable: false),
                    ModalidadeId = table.Column<long>(type: "bigint", nullable: false),
                    GraduacaoId = table.Column<long>(type: "bigint", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioModalidade", x => new { x.UsuarioId, x.ModalidadeId });
                    table.ForeignKey(
                        name: "FK_UsuarioModalidade_Graduacao_GraduacaoId",
                        column: x => x.GraduacaoId,
                        principalTable: "Graduacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioModalidade_Modalidade_ModalidadeId",
                        column: x => x.ModalidadeId,
                        principalTable: "Modalidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioModalidade_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            //migrationBuilder.CreateTable(
            //    name: "FichasTreino",
            //    columns: table => new
            //    {
            //        Id = table.Column<long>(type: "bigint", nullable: false)
            //            .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
            //        AtletaId = table.Column<long>(type: "bigint", nullable: false),
            //        UsuarioModalidadeId = table.Column<long>(type: "bigint", nullable: false),
            //        UsuarioModalidadeUsuarioId = table.Column<long>(type: "bigint", nullable: false),
            //        UsuarioModalidadeModalidadeId = table.Column<long>(type: "bigint", nullable: false),
            //        Nivel = table.Column<int>(type: "integer", nullable: false),
            //        Descricao = table.Column<string>(type: "text", nullable: false),
            //        DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_FichasTreino", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_FichasTreino_Atletas_AtletaId",
            //            column: x => x.AtletaId,
            //            principalTable: "Atletas",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_FichasTreino_UsuarioModalidade_UsuarioModalidadeUsuarioId_U~",
            //            columns: x => new { x.UsuarioModalidadeUsuarioId, x.UsuarioModalidadeModalidadeId },
            //            principalTable: "UsuarioModalidade",
            //            principalColumns: new[] { "UsuarioId", "ModalidadeId" },
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_FichasTreino_AtletaId",
            //    table: "FichasTreino",
            //    column: "AtletaId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_FichasTreino_UsuarioModalidadeUsuarioId_UsuarioModalidadeMo~",
            //    table: "FichasTreino",
            //    columns: new[] { "UsuarioModalidadeUsuarioId", "UsuarioModalidadeModalidadeId" });

            migrationBuilder.CreateIndex(
                name: "IX_Graduacao_FederacaoId",
                table: "Graduacao",
                column: "FederacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioModalidade_GraduacaoId",
                table: "UsuarioModalidade",
                column: "GraduacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioModalidade_ModalidadeId",
                table: "UsuarioModalidade",
                column: "ModalidadeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "FichasTreino");

            //migrationBuilder.DropTable(
            //    name: "Treinadores");

            //migrationBuilder.DropTable(
            //    name: "Atletas");

            migrationBuilder.DropTable(
                name: "UsuarioModalidade");

            migrationBuilder.DropTable(
                name: "Graduacao");

            migrationBuilder.DropTable(
                name: "Modalidade");

            //migrationBuilder.DropTable(
            //    name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Federacao");
        }
    }
}
