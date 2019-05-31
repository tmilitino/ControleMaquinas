using Microsoft.EntityFrameworkCore.Migrations;

namespace Computador.Migrations
{
    public partial class Rel_setor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Setor",
                table: "Maquina");

            migrationBuilder.AddColumn<int>(
                name: "SetorId",
                table: "Maquina",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Maquina_SetorId",
                table: "Maquina",
                column: "SetorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Maquina_Setor_SetorId",
                table: "Maquina",
                column: "SetorId",
                principalTable: "Setor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Maquina_Setor_SetorId",
                table: "Maquina");

            migrationBuilder.DropIndex(
                name: "IX_Maquina_SetorId",
                table: "Maquina");

            migrationBuilder.DropColumn(
                name: "SetorId",
                table: "Maquina");

            migrationBuilder.AddColumn<string>(
                name: "Setor",
                table: "Maquina",
                nullable: true);
        }
    }
}
