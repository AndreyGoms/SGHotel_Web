using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SGHotel.Migrations
{
    public partial class TabelaContas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contas",
                columns: table => new
                {
                    IdConta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valor_Conta = table.Column<double>(type: "float", nullable: false),
                    dt_lancamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dt_vencimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tp_conta = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contas", x => x.IdConta);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contas");
        }
    }
}
