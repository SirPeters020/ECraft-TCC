using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecraft.Api.Migrations
{
    public partial class ChangeGeneralContentNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Usuario",
                table: "TagProjeto");

            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "Receitas",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Descurtidas",
                table: "Receitas",
                newName: "Unlikes");

            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Receitas",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "Curtidas",
                table: "Receitas",
                newName: "Likes");

            migrationBuilder.RenameColumn(
                name: "Conteudo",
                table: "Receitas",
                newName: "MarkdownText");

            migrationBuilder.RenameColumn(
                name: "Acessos",
                table: "Receitas",
                newName: "Access");

            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "Projetos",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Descurtidas",
                table: "Projetos",
                newName: "Unlikes");

            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Projetos",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "Curtidas",
                table: "Projetos",
                newName: "Likes");

            migrationBuilder.RenameColumn(
                name: "Conteudo",
                table: "Projetos",
                newName: "MarkdownText");

            migrationBuilder.RenameColumn(
                name: "Acessos",
                table: "Projetos",
                newName: "Access");

            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "Perguntas",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Descurtidas",
                table: "Perguntas",
                newName: "Unlikes");

            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Perguntas",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "Curtidas",
                table: "Perguntas",
                newName: "Likes");

            migrationBuilder.RenameColumn(
                name: "Conteudo",
                table: "Perguntas",
                newName: "MarkdownText");

            migrationBuilder.RenameColumn(
                name: "Acessos",
                table: "Perguntas",
                newName: "Access");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Unlikes",
                table: "Receitas",
                newName: "Descurtidas");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Receitas",
                newName: "Titulo");

            migrationBuilder.RenameColumn(
                name: "MarkdownText",
                table: "Receitas",
                newName: "Conteudo");

            migrationBuilder.RenameColumn(
                name: "Likes",
                table: "Receitas",
                newName: "Curtidas");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Receitas",
                newName: "Data");

            migrationBuilder.RenameColumn(
                name: "Access",
                table: "Receitas",
                newName: "Acessos");

            migrationBuilder.RenameColumn(
                name: "Unlikes",
                table: "Projetos",
                newName: "Descurtidas");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Projetos",
                newName: "Titulo");

            migrationBuilder.RenameColumn(
                name: "MarkdownText",
                table: "Projetos",
                newName: "Conteudo");

            migrationBuilder.RenameColumn(
                name: "Likes",
                table: "Projetos",
                newName: "Curtidas");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Projetos",
                newName: "Data");

            migrationBuilder.RenameColumn(
                name: "Access",
                table: "Projetos",
                newName: "Acessos");

            migrationBuilder.RenameColumn(
                name: "Unlikes",
                table: "Perguntas",
                newName: "Descurtidas");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Perguntas",
                newName: "Titulo");

            migrationBuilder.RenameColumn(
                name: "MarkdownText",
                table: "Perguntas",
                newName: "Conteudo");

            migrationBuilder.RenameColumn(
                name: "Likes",
                table: "Perguntas",
                newName: "Curtidas");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Perguntas",
                newName: "Data");

            migrationBuilder.RenameColumn(
                name: "Access",
                table: "Perguntas",
                newName: "Acessos");

            migrationBuilder.AddColumn<int>(
                name: "Usuario",
                table: "TagProjeto",
                type: "int",
                nullable: true);
        }
    }
}
