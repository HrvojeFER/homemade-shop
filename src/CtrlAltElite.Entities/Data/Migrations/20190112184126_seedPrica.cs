using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CtrlAltElite.Entities.Data.Migrations
{
    public partial class seedPrica : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prica_Prica_RoditeljIdPrica",
                table: "Prica");

            migrationBuilder.AlterColumn<int>(
                name: "RoditeljIdPrica",
                table: "Prica",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.InsertData(
                table: "Prica",
                columns: new[] { "IdPrica", "IdKorisnik", "IdStatus", "RoditeljIdPrica", "Sadrzaj", "UrlSlike", "VrijemeObjave" },
                values: new object[] { 1, 1, 1, null, "Ova posuda je je baš kao i na stranici. Dizajn je prelijep, a isto tako mi se sviđa tekstura ukrašavanja. Ako želite dobiti komplimente od drugih prijateljica, naručite ovo za dnevnu sobu. Uvelike preporučam.", "/images/bowl.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Prica",
                columns: new[] { "IdPrica", "IdKorisnik", "IdStatus", "RoditeljIdPrica", "Sadrzaj", "UrlSlike", "VrijemeObjave" },
                values: new object[] { 2, 2, 1, null, "Posuda za cvijeće od gline je jako lijepa", "/images/pot.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

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

            migrationBuilder.DeleteData(
                table: "Prica",
                keyColumn: "IdPrica",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Prica",
                keyColumn: "IdPrica",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "RoditeljIdPrica",
                table: "Prica",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Prica_Prica_RoditeljIdPrica",
                table: "Prica",
                column: "RoditeljIdPrica",
                principalTable: "Prica",
                principalColumn: "IdPrica",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
