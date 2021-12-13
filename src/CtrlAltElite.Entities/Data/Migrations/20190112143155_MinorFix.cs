using Microsoft.EntityFrameworkCore.Migrations;

namespace CtrlAltElite.Entities.Data.Migrations
{
    public partial class MinorFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Narudzba_Ponuda_IdPonuda",
                table: "Narudzba");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "IdRola",
                keyValue: 4);

            migrationBuilder.AlterColumn<int>(
                name: "IdPosebnaPonuda",
                table: "Narudzba",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "IdPonuda",
                table: "Narudzba",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "IdStatus", "Vrijednost" },
                values: new object[,]
                {
                    { 1, "Objavljeno" },
                    { 2, "Kupljeno" },
                    { 3, "Ponuđeno" },
                    { 4, "Isporučeno" },
                    { 5, "Odobreno" },
                    { 6, "Odbijeno" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Narudzba_Ponuda_IdPonuda",
                table: "Narudzba",
                column: "IdPonuda",
                principalTable: "Ponuda",
                principalColumn: "IdPonuda",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Narudzba_Ponuda_IdPonuda",
                table: "Narudzba");

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "IdStatus",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "IdStatus",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "IdStatus",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "IdStatus",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "IdStatus",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Status",
                keyColumn: "IdStatus",
                keyValue: 6);

            migrationBuilder.AlterColumn<int>(
                name: "IdPosebnaPonuda",
                table: "Narudzba",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdPonuda",
                table: "Narudzba",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "IdRola", "Rola" },
                values: new object[] { 4, "SuperAdmin" });

            migrationBuilder.AddForeignKey(
                name: "FK_Narudzba_Ponuda_IdPonuda",
                table: "Narudzba",
                column: "IdPonuda",
                principalTable: "Ponuda",
                principalColumn: "IdPonuda",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
