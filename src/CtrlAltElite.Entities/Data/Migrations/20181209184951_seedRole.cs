using Microsoft.EntityFrameworkCore.Migrations;

namespace CtrlAltElite.Entities.Data.Migrations
{
    public partial class seedRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Rola",
                table: "Role",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "IdRola", "Rola" },
                values: new object[,]
                {
                    { 1, "BananiKorisnik" },
                    { 2, "RegistriraniKorisnik" },
                    { 3, "Admin" },
                    { 4, "SuperAdmin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Role_Rola",
                table: "Role",
                column: "Rola");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Role_Rola",
                table: "Role");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "IdRola",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "IdRola",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "IdRola",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "IdRola",
                keyValue: 4);

            migrationBuilder.AlterColumn<string>(
                name: "Rola",
                table: "Role",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
