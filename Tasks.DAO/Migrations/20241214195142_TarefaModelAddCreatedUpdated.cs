using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tasks.DAO.Migrations
{
    /// <inheritdoc />
    public partial class TarefaModelAddCreatedUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Atualizado",
                table: "Tarefas",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Criado",
                table: "Tarefas",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Atualizado",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "Criado",
                table: "Tarefas");
        }
    }
}
