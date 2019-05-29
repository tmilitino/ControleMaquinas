using Microsoft.EntityFrameworkCore.Migrations;

namespace Computador.Migrations
{
    public partial class NovoModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Marca",
                table: "Maquina",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Marca",
                table: "Maquina");
        }
    }
}
