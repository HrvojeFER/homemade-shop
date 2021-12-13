using Microsoft.EntityFrameworkCore.Migrations;

namespace CtrlAltElite.Entities.Data.Migrations
{
    public partial class DodanUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prica_Prica_RoditeljIdPrica",
                table: "Prica");

            migrationBuilder.DropIndex(
                name: "IX_Prica_RoditeljIdPrica",
                table: "Prica");

            migrationBuilder.DropColumn(
                name: "RoditeljIdPrica",
                table: "Prica");

            migrationBuilder.AddColumn<string>(
                name: "UrlSlike",
                table: "Prica",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prica_IdRoditelj",
                table: "Prica",
                column: "IdRoditelj");

            migrationBuilder.AddForeignKey(
                name: "FK_Prica_Prica_IdRoditelj",
                table: "Prica",
                column: "IdRoditelj",
                principalTable: "Prica",
                principalColumn: "IdPrica",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prica_Prica_IdRoditelj",
                table: "Prica");

            migrationBuilder.DropIndex(
                name: "IX_Prica_IdRoditelj",
                table: "Prica");

            migrationBuilder.DropColumn(
                name: "UrlSlike",
                table: "Prica");

            migrationBuilder.AddColumn<int>(
                name: "RoditeljIdPrica",
                table: "Prica",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prica_RoditeljIdPrica",
                table: "Prica",
                column: "RoditeljIdPrica");

            migrationBuilder.AddForeignKey(
                name: "FK_Prica_Prica_RoditeljIdPrica",
                table: "Prica",
                column: "RoditeljIdPrica",
                principalTable: "Prica",
                principalColumn: "IdPrica",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
