using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exercicio09.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPerfil : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoCurso",
                table: "Cursos");

            migrationBuilder.RenameColumn(
                name: "Permissao",
                table: "Usuarios",
                newName: "PerfilId");

            migrationBuilder.AlterColumn<string>(
                name: "Turno",
                table: "Cursos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Perfis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioInclusao = table.Column<int>(type: "int", nullable: true),
                    DataInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioAlteracao = table.Column<int>(type: "int", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "Turno",
                table: "Cursos",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "TipoCurso",
                table: "Cursos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
