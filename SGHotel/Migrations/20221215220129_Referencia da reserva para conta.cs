using Microsoft.EntityFrameworkCore.Migrations;

namespace SGHotel.Migrations
{
    public partial class Referenciadareservaparaconta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "id_Conta",
                table: "Reservas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "id_Conta",
                table: "Reservas");
        }
    }
}
