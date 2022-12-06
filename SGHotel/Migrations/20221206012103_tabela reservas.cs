using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SGHotel.Migrations
{
    public partial class tabelareservas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    id_Reserva = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dt_inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dt_fim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    id_cliente = table.Column<int>(type: "int", nullable: false),
                    id_quarto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.id_Reserva);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservas");
        }
    }
}
