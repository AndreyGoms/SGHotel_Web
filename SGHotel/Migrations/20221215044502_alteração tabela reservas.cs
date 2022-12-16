using Microsoft.EntityFrameworkCore.Migrations;

namespace SGHotel.Migrations
{
    public partial class alteraçãotabelareservas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome_Cliente",
                table: "Reservas",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome_Cliente",
                table: "Reservas");
        }
    }
}
