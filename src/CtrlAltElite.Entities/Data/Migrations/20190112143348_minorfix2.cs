using Microsoft.EntityFrameworkCore.Migrations;

namespace CtrlAltElite.Entities.Data.Migrations
{
    public partial class minorfix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prica_Prica_IdRoditelj",
                table: "Prica");

            migrationBuilder.AddForeignKey(
                name: "FK_Prica_Prica_IdRoditelj",
                table: "Prica",
                column: "IdRoditelj",
                principalTable: "Prica",
                principalColumn: "IdPrica",
                onDelete: ReferentialAction.NoAction,
                onUpdate: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prica_Prica_IdRoditelj",
                table: "Prica");

            migrationBuilder.AddForeignKey(
                name: "FK_Prica_Prica_IdRoditelj",
                table: "Prica",
                column: "IdRoditelj",
                principalTable: "Prica",
                principalColumn: "IdPrica",
                onDelete: ReferentialAction.Restrict,
                onUpdate: ReferentialAction.Restrict);
        }
    }
}
