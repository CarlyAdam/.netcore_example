using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lot.Repo.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Evento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    TarjetaWin = table.Column<string>(nullable: true),
                    Fechainicio = table.Column<DateTime>(nullable: false),
                    Fechafin = table.Column<DateTime>(nullable: false),
                    Cerrado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tarjeta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Numero = table.Column<int>(nullable: false),
                    Reservada = table.Column<bool>(nullable: false),
                    EventoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarjeta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tarjeta_Evento_EventoId",
                        column: x => x.EventoId,
                        principalTable: "Evento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tarjeta_EventoId",
                table: "Tarjeta",
                column: "EventoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tarjeta");

            migrationBuilder.DropTable(
                name: "Evento");
        }
    }
}
