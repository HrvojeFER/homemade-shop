using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CtrlAltElite.Entities.Data.Migrations
{
    public partial class seedPrica_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Prica",
                keyColumn: "IdPrica",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Prica",
                keyColumn: "IdPrica",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "Prica",
                columns: new[] { "IdPrica", "IdKorisnik", "IdStatus", "RoditeljIdPrica", "Sadrzaj", "UrlSlike", "VrijemeObjave" },
                values: new object[] { 3, 1, 1, null, "Ova posuda je je baš kao i na stranici. Dizajn je prelijep, a isto tako mi se sviđa tekstura ukrašavanja. Ako želite dobiti komplimente od drugih prijateljica, naručite ovo za dnevnu sobu. Uvelike preporučam.", "/images/bowl.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Prica",
                columns: new[] { "IdPrica", "IdKorisnik", "IdStatus", "RoditeljIdPrica", "Sadrzaj", "UrlSlike", "VrijemeObjave" },
                values: new object[] { 4, 2, 1, null, "Posuda za cvijeće od gline je jako lijepa", "/images/pot.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Prica",
                columns: new[] { "IdPrica", "IdKorisnik", "IdStatus", "RoditeljIdPrica", "Sadrzaj", "UrlSlike", "VrijemeObjave" },
                values: new object[] { 6, 2, 1, null, "Drvena kutijica u koju stavljam svoje dragocijene stvari, a mogućnost ukrašavanja joj i više doprinosi na osobnosti", "/images/box.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Prica",
                columns: new[] { "IdPrica", "IdKorisnik", "IdStatus", "RoditeljIdPrica", "Sadrzaj", "UrlSlike", "VrijemeObjave" },
                values: new object[] { 5, 1, 1, 4, "Potpuno se slažem, takvu sam ja isto kupila svojoj kćeri.", "/images/pot.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Prica",
                columns: new[] { "IdPrica", "IdKorisnik", "IdStatus", "RoditeljIdPrica", "Sadrzaj", "UrlSlike", "VrijemeObjave" },
                values: new object[] { 7, 2, 1, 6, "Stavio sam ukras koji se toliko svidio mojoj svekrvi, samo lijepe riječi za HandMadeShop.", "/images/box.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Prica",
                keyColumn: "IdPrica",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Prica",
                keyColumn: "IdPrica",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Prica",
                keyColumn: "IdPrica",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Prica",
                keyColumn: "IdPrica",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Prica",
                keyColumn: "IdPrica",
                keyValue: 6);

            migrationBuilder.InsertData(
                table: "Prica",
                columns: new[] { "IdPrica", "IdKorisnik", "IdStatus", "RoditeljIdPrica", "Sadrzaj", "UrlSlike", "VrijemeObjave" },
                values: new object[] { 1, 1, 1, null, "Ova posuda je je baš kao i na stranici. Dizajn je prelijep, a isto tako mi se sviđa tekstura ukrašavanja. Ako želite dobiti komplimente od drugih prijateljica, naručite ovo za dnevnu sobu. Uvelike preporučam.", "/images/bowl.jpg", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Prica",
                columns: new[] { "IdPrica", "IdKorisnik", "IdStatus", "RoditeljIdPrica", "Sadrzaj", "UrlSlike", "VrijemeObjave" },
                values: new object[] { 2, 2, 1, null, "Posuda za cvijeće od gline je jako lijepa", "/images/pot.png", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
