using Microsoft.EntityFrameworkCore.Migrations;

namespace CtrlAltElite.Entities.Data.Migrations
{
    public partial class IdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Korisnik",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_UserName",
                table: "Korisnik",
                column: "UserName",
                unique: true,
                filter: "[UserName] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Korisnik_AspNetUsers_UserName",
                table: "Korisnik",
                column: "UserName",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Korisnik_AspNetUsers_UserName",
                table: "Korisnik");

            migrationBuilder.DropIndex(
                name: "IX_Korisnik_UserName",
                table: "Korisnik");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Korisnik",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
