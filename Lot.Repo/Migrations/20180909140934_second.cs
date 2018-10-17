using Microsoft.EntityFrameworkCore.Migrations;

namespace Lot.Repo.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarjeta_Evento_EventoId",
                table: "Tarjeta");

            migrationBuilder.AlterColumn<int>(
                name: "EventoId",
                table: "Tarjeta",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarjeta_Evento_EventoId",
                table: "Tarjeta",
                column: "EventoId",
                principalTable: "Evento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarjeta_Evento_EventoId",
                table: "Tarjeta");

            migrationBuilder.AlterColumn<int>(
                name: "EventoId",
                table: "Tarjeta",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Tarjeta_Evento_EventoId",
                table: "Tarjeta",
                column: "EventoId",
                principalTable: "Evento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
