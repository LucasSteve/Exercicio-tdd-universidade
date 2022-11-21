using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exercicio09.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Atualizando : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Perfis_PerfilId",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "Perfis");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_PerfilId",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "PerfilId",
                table: "Usuarios",
                newName: "Permissao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Permissao",
                table: "Usuarios",
                newName: "PerfilId");

            migrationBuilder.CreateTable(
                name: "Perfis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Permissao = table.Column<int>(type: "int", nullable: false),
                    UsuarioAlteracao = table.Column<int>(type: "int", nullable: true),
                    UsuarioInclusao = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfis", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_PerfilId",
                table: "Usuarios",
                column: "PerfilId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Perfis_PerfilId",
                table: "Usuarios",
                column: "PerfilId",
                principalTable: "Perfis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
