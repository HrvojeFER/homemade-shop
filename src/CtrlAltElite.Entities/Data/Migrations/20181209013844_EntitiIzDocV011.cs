using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CtrlAltElite.Entities.Data.Migrations
{
    public partial class EntitiIzDocV011 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Predmet",
                columns: table => new
                {
                    IdPredmet = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NazivPredmet = table.Column<string>(nullable: true),
                    BaznaCijena = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    Opis = table.Column<string>(nullable: true),
                    SlikaUrl = table.Column<string>(nullable: true),
                    Visina = table.Column<decimal>(nullable: false),
                    Duzina = table.Column<decimal>(nullable: false),
                    Sirina = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predmet", x => x.IdPredmet);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    IdRola = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Rola = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.IdRola);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    IdStatus = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Vrijednost = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.IdStatus);
                });

            migrationBuilder.CreateTable(
                name: "StilSalveta",
                columns: table => new
                {
                    IdSalveta = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NazivSalveta = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true),
                    FaktorMnozenja = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StilSalveta", x => x.IdSalveta);
                });

            migrationBuilder.CreateTable(
                name: "StilUkrasavanja",
                columns: table => new
                {
                    IdStil = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NazivStil = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true),
                    FaktorMnozenja = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StilUkrasavanja", x => x.IdStil);
                });

            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    IdKorisnik = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ImeKorisnik = table.Column<string>(nullable: true),
                    PrezimeKorisnik = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    EmailKorisnik = table.Column<string>(nullable: true),
                    PwdKorisnik = table.Column<string>(nullable: true),
                    AdresaKorisnik = table.Column<string>(nullable: true),
                    IdRole = table.Column<int>(nullable: false),
                    RolaIdRola = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.IdKorisnik);
                    table.ForeignKey(
                        name: "FK_Korisnik_Role_RolaIdRola",
                        column: x => x.RolaIdRola,
                        principalTable: "Role",
                        principalColumn: "IdRola",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ponuda",
                columns: table => new
                {
                    IdPonuda = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdPredmet = table.Column<int>(nullable: false),
                    IdStil = table.Column<int>(nullable: false),
                    IdSalveta = table.Column<int>(nullable: false),
                    Cijena = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ponuda", x => x.IdPonuda);
                    table.ForeignKey(
                        name: "FK_Ponuda_Predmet_IdPredmet",
                        column: x => x.IdPredmet,
                        principalTable: "Predmet",
                        principalColumn: "IdPredmet",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ponuda_StilSalveta_IdSalveta",
                        column: x => x.IdSalveta,
                        principalTable: "StilSalveta",
                        principalColumn: "IdSalveta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ponuda_StilUkrasavanja_IdStil",
                        column: x => x.IdStil,
                        principalTable: "StilUkrasavanja",
                        principalColumn: "IdStil",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prica",
                columns: table => new
                {
                    IdPrica = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdKorisnik = table.Column<int>(nullable: false),
                    IdRoditelj = table.Column<int>(nullable: false),
                    IdStatus = table.Column<int>(nullable: false),
                    Sadrzaj = table.Column<string>(nullable: true),
                    VrijemeObjave = table.Column<DateTime>(nullable: false),
                    RoditeljIdPrica = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prica", x => x.IdPrica);
                    table.ForeignKey(
                        name: "FK_Prica_Korisnik_IdKorisnik",
                        column: x => x.IdKorisnik,
                        principalTable: "Korisnik",
                        principalColumn: "IdKorisnik",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prica_Status_IdStatus",
                        column: x => x.IdStatus,
                        principalTable: "Status",
                        principalColumn: "IdStatus",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prica_Prica_RoditeljIdPrica",
                        column: x => x.RoditeljIdPrica,
                        principalTable: "Prica",
                        principalColumn: "IdPrica",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vidljivost",
                columns: table => new
                {
                    IdVidljivost = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdKorisnik = table.Column<int>(nullable: false),
                    VidljivostImeKorisnik = table.Column<bool>(nullable: false),
                    VidljivostPrezimeKorisnik = table.Column<bool>(nullable: false),
                    VidljivostEmailKorisnik = table.Column<bool>(nullable: false),
                    VidljivostAdresaKorisnik = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vidljivost", x => x.IdVidljivost);
                    table.ForeignKey(
                        name: "FK_Vidljivost_Korisnik_IdKorisnik",
                        column: x => x.IdKorisnik,
                        principalTable: "Korisnik",
                        principalColumn: "IdKorisnik",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Narudzba",
                columns: table => new
                {
                    IdNarudzba = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdPonuda = table.Column<int>(nullable: false),
                    IdPosebnaPonuda = table.Column<int>(nullable: false),
                    IdStatus = table.Column<int>(nullable: false),
                    IdKorisnik = table.Column<int>(nullable: false),
                    KonacnaCijena = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    Datum = table.Column<DateTime>(nullable: false),
                    ImePrimatelja = table.Column<string>(nullable: true),
                    PrezimePrimatelja = table.Column<string>(nullable: true),
                    AdresaPrimatelja = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Narudzba", x => x.IdNarudzba);
                    table.ForeignKey(
                        name: "FK_Narudzba_Korisnik_IdKorisnik",
                        column: x => x.IdKorisnik,
                        principalTable: "Korisnik",
                        principalColumn: "IdKorisnik",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Narudzba_Ponuda_IdPonuda",
                        column: x => x.IdPonuda,
                        principalTable: "Ponuda",
                        principalColumn: "IdPonuda",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Narudzba_Status_IdStatus",
                        column: x => x.IdStatus,
                        principalTable: "Status",
                        principalColumn: "IdStatus",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PosebnaPonuda",
                columns: table => new
                {
                    IdPosebnaPonuda = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdNarudzba = table.Column<int>(nullable: false),
                    Opis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PosebnaPonuda", x => x.IdPosebnaPonuda);
                    table.ForeignKey(
                        name: "FK_PosebnaPonuda_Narudzba_IdNarudzba",
                        column: x => x.IdNarudzba,
                        principalTable: "Narudzba",
                        principalColumn: "IdNarudzba",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transakcija",
                columns: table => new
                {
                    IdTransakcija = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdNarudzba = table.Column<int>(nullable: false),
                    KonacnaCijena = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    Datum = table.Column<DateTime>(nullable: false),
                    ImeKupca = table.Column<string>(nullable: true),
                    PrezimeKupca = table.Column<string>(nullable: true),
                    AdresaKupca = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transakcija", x => x.IdTransakcija);
                    table.ForeignKey(
                        name: "FK_Transakcija_Narudzba_IdNarudzba",
                        column: x => x.IdNarudzba,
                        principalTable: "Narudzba",
                        principalColumn: "IdNarudzba",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_RolaIdRola",
                table: "Korisnik",
                column: "RolaIdRola");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_IdKorisnik",
                table: "Narudzba",
                column: "IdKorisnik");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_IdPonuda",
                table: "Narudzba",
                column: "IdPonuda");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_IdStatus",
                table: "Narudzba",
                column: "IdStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Ponuda_IdPredmet",
                table: "Ponuda",
                column: "IdPredmet");

            migrationBuilder.CreateIndex(
                name: "IX_Ponuda_IdSalveta",
                table: "Ponuda",
                column: "IdSalveta");

            migrationBuilder.CreateIndex(
                name: "IX_Ponuda_IdStil",
                table: "Ponuda",
                column: "IdStil");

            migrationBuilder.CreateIndex(
                name: "IX_PosebnaPonuda_IdNarudzba",
                table: "PosebnaPonuda",
                column: "IdNarudzba",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prica_IdKorisnik",
                table: "Prica",
                column: "IdKorisnik");

            migrationBuilder.CreateIndex(
                name: "IX_Prica_IdStatus",
                table: "Prica",
                column: "IdStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Prica_RoditeljIdPrica",
                table: "Prica",
                column: "RoditeljIdPrica");

            migrationBuilder.CreateIndex(
                name: "IX_Transakcija_IdNarudzba",
                table: "Transakcija",
                column: "IdNarudzba",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vidljivost_IdKorisnik",
                table: "Vidljivost",
                column: "IdKorisnik",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PosebnaPonuda");

            migrationBuilder.DropTable(
                name: "Prica");

            migrationBuilder.DropTable(
                name: "Transakcija");

            migrationBuilder.DropTable(
                name: "Vidljivost");

            migrationBuilder.DropTable(
                name: "Narudzba");

            migrationBuilder.DropTable(
                name: "Korisnik");

            migrationBuilder.DropTable(
                name: "Ponuda");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Predmet");

            migrationBuilder.DropTable(
                name: "StilSalveta");

            migrationBuilder.DropTable(
                name: "StilUkrasavanja");
        }
    }
}
