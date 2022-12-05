using Microsoft.EntityFrameworkCore.Migrations;

namespace SGHotel.Migrations
{
    public partial class atualizacaotabelaquartos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Disponivel",
                table: "Quartos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Disponivel",
                table: "Quartos");
        }
    }
}
