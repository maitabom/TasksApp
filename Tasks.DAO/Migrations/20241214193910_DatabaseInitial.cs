using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tasks.DAO.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tarefas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false),
                    DataPrevisao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Concluido = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subtarefas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Concluido = table.Column<bool>(type: "INTEGER", nullable: false),
                    TarefaId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subtarefas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subtarefas_Tarefas_TarefaId",
                        column: x => x.TarefaId,
                        principalTable: "Tarefas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subtarefas_TarefaId",
                table: "Subtarefas",
                column: "TarefaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subtarefas");

            migrationBuilder.DropTable(
                name: "Tarefas");
        }
    }
}
