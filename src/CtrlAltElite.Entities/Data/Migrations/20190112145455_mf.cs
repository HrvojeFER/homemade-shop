using Microsoft.EntityFrameworkCore.Migrations;

namespace CtrlAltElite.Entities.Data.Migrations
{
    public partial class mf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prica_Prica_IdRoditelj",
                table: "Prica");

            migrationBuilder.RenameColumn(
                name: "IdRoditelj",
                table: "Prica",
                newName: "RoditeljIdPrica");

            migrationBuilder.RenameIndex(
                name: "IX_Prica_IdRoditelj",
                table: "Prica",
                newName: "IX_Prica_RoditeljIdPrica");

            migrationBuilder.AddForeignKey(
                name: "FK_Prica_Prica_RoditeljIdPrica",
                table: "Prica",
                column: "RoditeljIdPrica",
                principalTable: "Prica",
                principalColumn: "IdPrica",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prica_Prica_RoditeljIdPrica",
                table: "Prica");

            migrationBuilder.RenameColumn(
                name: "RoditeljIdPrica",
                table: "Prica",
                newName: "IdRoditelj");

            migrationBuilder.RenameIndex(
                name: "IX_Prica_RoditeljIdPrica",
                table: "Prica",
                newName: "IX_Prica_IdRoditelj");

            migrationBuilder.AddForeignKey(
                name: "FK_Prica_Prica_IdRoditelj",
                table: "Prica",
                column: "IdRoditelj",
                principalTable: "Prica",
                principalColumn: "IdPrica",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
