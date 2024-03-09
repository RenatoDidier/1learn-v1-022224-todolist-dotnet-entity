using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Core.Migrations
{
    /// <inheritdoc />
    public partial class PrimeiraVersao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atividade",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "NVARCHAR(300)", maxLength: 300, nullable: false),
                    Conclusao = table.Column<bool>(type: "BIT", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DataUltimaModificacao = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atividade", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atividade");
        }
    }
}
