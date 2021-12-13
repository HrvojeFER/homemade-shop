using Microsoft.EntityFrameworkCore.Migrations;

namespace CtrlAltElite.Entities.Data.Migrations
{
    public partial class seeddata_updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Predmet",
                columns: new[] { "IdPredmet", "BaznaCijena", "Duzina", "NazivPredmet", "Opis", "Sirina", "SlikaUrl", "Visina" },
                values: new object[,]
                {
                    { 1, 24.99m, 8m, "Teglica", "Jednostavna teglica za držanje biljki", 8m, "/images/pot.png", 16.5m },
                    { 2, 4.99m, 7m, "Kuglica", "Savršena kgulica za svaki bor!", 7m, "/images/ball.jpg", 7m },
                    { 3, 149.99m, 49m, "Stolica", "Neka vaša guza ima lijepi pogled", 42m, "/images/chair.jpg", 90m }
                });

            migrationBuilder.InsertData(
                table: "StilSalveta",
                columns: new[] { "IdSalveta", "FaktorMnozenja", "NazivSalveta", "Opis" },
                values: new object[,]
                {
                    { 1, 2.5, "Bijela sa srcima", "Bijela salveta sa uzorcima srca. Dobro za Valentinovo!" },
                    { 2, 1.5, "Trokutići", "Lijepi stil salvete sa trokutićima!" },
                    { 3, 1.15, "Cvijetići", "Lijepi stil salvete sa cvijetićima!" }
                });

            migrationBuilder.InsertData(
                table: "StilUkrasavanja",
                columns: new[] { "IdStil", "FaktorMnozenja", "NazivStil", "Opis" },
                values: new object[,]
                {
                    { 1, 1.5f, "Romantičan", "Ukrašava se toplim bojama dobrim za srce i ljubav" },
                    { 2, 1.15f, "Tmuran", "Ukrašava se tmurnim bojama dobrim za pripremu druge osobe za loše vijesti" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Predmet",
                keyColumn: "IdPredmet",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Predmet",
                keyColumn: "IdPredmet",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Predmet",
                keyColumn: "IdPredmet",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "StilSalveta",
                keyColumn: "IdSalveta",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StilSalveta",
                keyColumn: "IdSalveta",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StilSalveta",
                keyColumn: "IdSalveta",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "StilUkrasavanja",
                keyColumn: "IdStil",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StilUkrasavanja",
                keyColumn: "IdStil",
                keyValue: 2);
        }
    }
}
