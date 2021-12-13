﻿// <auto-generated />
using System;
using CtrlAltElite.Entities.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CtrlAltElite.Entities.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CtrlAltElite.Entities.Models.Korisnik", b =>
                {
                    b.Property<int>("IdKorisnik")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdresaKorisnik");

                    b.Property<string>("EmailKorisnik");

                    b.Property<int>("IdRole");

                    b.Property<string>("ImeKorisnik");

                    b.Property<string>("PrezimeKorisnik");

                    b.Property<string>("PwdKorisnik");

                    b.Property<int?>("RolaIdRola");

                    b.Property<string>("UserName");

                    b.HasKey("IdKorisnik");

                    b.HasIndex("RolaIdRola");

                    b.HasIndex("UserName")
                        .IsUnique()
                        .HasFilter("[UserName] IS NOT NULL");

                    b.ToTable("Korisnik");
                });

            modelBuilder.Entity("CtrlAltElite.Entities.Models.Narudzba", b =>
                {
                    b.Property<int>("IdNarudzba")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdresaPrimatelja");

                    b.Property<DateTime>("Datum");

                    b.Property<int>("IdKorisnik");

                    b.Property<int?>("IdPonuda");

                    b.Property<int?>("IdPosebnaPonuda");

                    b.Property<int>("IdStatus");

                    b.Property<string>("ImePrimatelja");

                    b.Property<decimal>("KonacnaCijena")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("PrezimePrimatelja");

                    b.HasKey("IdNarudzba");

                    b.HasIndex("IdKorisnik");

                    b.HasIndex("IdPonuda");

                    b.HasIndex("IdStatus");

                    b.ToTable("Narudzba");
                });

            modelBuilder.Entity("CtrlAltElite.Entities.Models.Ponuda", b =>
                {
                    b.Property<int>("IdPonuda")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Cijena");

                    b.Property<int>("IdPredmet");

                    b.Property<int>("IdSalveta");

                    b.Property<int>("IdStil");

                    b.HasKey("IdPonuda");

                    b.HasIndex("IdPredmet");

                    b.HasIndex("IdSalveta");

                    b.HasIndex("IdStil");

                    b.ToTable("Ponuda");
                });

            modelBuilder.Entity("CtrlAltElite.Entities.Models.PosebnaPonuda", b =>
                {
                    b.Property<int>("IdPosebnaPonuda")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdNarudzba");

                    b.Property<string>("Opis");

                    b.HasKey("IdPosebnaPonuda");

                    b.HasIndex("IdNarudzba")
                        .IsUnique();

                    b.ToTable("PosebnaPonuda");
                });

            modelBuilder.Entity("CtrlAltElite.Entities.Models.Predmet", b =>
                {
                    b.Property<int>("IdPredmet")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("BaznaCijena")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<decimal>("Duzina");

                    b.Property<string>("NazivPredmet");

                    b.Property<string>("Opis");

                    b.Property<decimal>("Sirina");

                    b.Property<string>("SlikaUrl");

                    b.Property<decimal>("Visina");

                    b.HasKey("IdPredmet");

                    b.ToTable("Predmet");

                    b.HasData(
                        new { IdPredmet = 1, BaznaCijena = 24.99m, Duzina = 8m, NazivPredmet = "Teglica", Opis = "Jednostavna teglica za držanje biljki", Sirina = 8m, SlikaUrl = "/images/pot.png", Visina = 16.5m },
                        new { IdPredmet = 2, BaznaCijena = 4.99m, Duzina = 7m, NazivPredmet = "Kuglica", Opis = "Savršena kgulica za svaki bor!", Sirina = 7m, SlikaUrl = "/images/ball.jpg", Visina = 7m },
                        new { IdPredmet = 3, BaznaCijena = 149.99m, Duzina = 49m, NazivPredmet = "Stolica", Opis = "Neka vaša guza ima lijepi pogled", Sirina = 42m, SlikaUrl = "/images/chair.jpg", Visina = 90m }
                    );
                });

            modelBuilder.Entity("CtrlAltElite.Entities.Models.Prica", b =>
                {
                    b.Property<int>("IdPrica")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdKorisnik");

                    b.Property<int>("IdStatus");

                    b.Property<int?>("RoditeljIdPrica");

                    b.Property<string>("Sadrzaj");

                    b.Property<string>("UrlSlike");

                    b.Property<DateTime>("VrijemeObjave");

                    b.HasKey("IdPrica");

                    b.HasIndex("IdKorisnik");

                    b.HasIndex("IdStatus");

                    b.HasIndex("RoditeljIdPrica");

                    b.ToTable("Prica");

                    b.HasData(
                        new { IdPrica = 3, IdKorisnik = 1, IdStatus = 1, Sadrzaj = "Ova posuda je je baš kao i na stranici. Dizajn je prelijep, a isto tako mi se sviđa tekstura ukrašavanja. Ako želite dobiti komplimente od drugih prijateljica, naručite ovo za dnevnu sobu. Uvelike preporučam.", UrlSlike = "/images/bowl.jpg", VrijemeObjave = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { IdPrica = 4, IdKorisnik = 2, IdStatus = 1, Sadrzaj = "Posuda za cvijeće od gline je jako lijepa", UrlSlike = "/images/pot.png", VrijemeObjave = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { IdPrica = 5, IdKorisnik = 1, IdStatus = 1, RoditeljIdPrica = 4, Sadrzaj = "Potpuno se slažem, takvu sam ja isto kupila svojoj kćeri.", UrlSlike = "/images/pot.png", VrijemeObjave = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { IdPrica = 6, IdKorisnik = 2, IdStatus = 1, Sadrzaj = "Drvena kutijica u koju stavljam svoje dragocijene stvari, a mogućnost ukrašavanja joj i više doprinosi na osobnosti", UrlSlike = "/images/box.jpg", VrijemeObjave = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                        new { IdPrica = 7, IdKorisnik = 2, IdStatus = 1, RoditeljIdPrica = 6, Sadrzaj = "Stavio sam ukras koji se toliko svidio mojoj svekrvi, samo lijepe riječi za HandMadeShop.", UrlSlike = "/images/box.jpg", VrijemeObjave = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                    );
                });

            modelBuilder.Entity("CtrlAltElite.Entities.Models.Role", b =>
                {
                    b.Property<int>("IdRola")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Rola");

                    b.HasKey("IdRola");

                    b.HasIndex("Rola");

                    b.ToTable("Role");

                    b.HasData(
                        new { IdRola = 1, Rola = "BananiKorisnik" },
                        new { IdRola = 2, Rola = "RegistriraniKorisnik" },
                        new { IdRola = 3, Rola = "Admin" }
                    );
                });

            modelBuilder.Entity("CtrlAltElite.Entities.Models.Status", b =>
                {
                    b.Property<int>("IdStatus")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Vrijednost");

                    b.HasKey("IdStatus");

                    b.ToTable("Status");

                    b.HasData(
                        new { IdStatus = 1, Vrijednost = "Objavljeno" },
                        new { IdStatus = 2, Vrijednost = "Kupljeno" },
                        new { IdStatus = 3, Vrijednost = "Ponuđeno" },
                        new { IdStatus = 4, Vrijednost = "Isporučeno" },
                        new { IdStatus = 5, Vrijednost = "Odobreno" },
                        new { IdStatus = 6, Vrijednost = "Odbijeno" }
                    );
                });

            modelBuilder.Entity("CtrlAltElite.Entities.Models.StilSalveta", b =>
                {
                    b.Property<int>("IdSalveta")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("FaktorMnozenja");

                    b.Property<string>("NazivSalveta");

                    b.Property<string>("Opis");

                    b.HasKey("IdSalveta");

                    b.ToTable("StilSalveta");

                    b.HasData(
                        new { IdSalveta = 1, FaktorMnozenja = 2.5, NazivSalveta = "Bijela sa srcima", Opis = "Bijela salveta sa uzorcima srca. Dobro za Valentinovo!" },
                        new { IdSalveta = 2, FaktorMnozenja = 1.5, NazivSalveta = "Trokutići", Opis = "Lijepi stil salvete sa trokutićima!" },
                        new { IdSalveta = 3, FaktorMnozenja = 1.15, NazivSalveta = "Cvijetići", Opis = "Lijepi stil salvete sa cvijetićima!" }
                    );
                });

            modelBuilder.Entity("CtrlAltElite.Entities.Models.StilUkrasavanja", b =>
                {
                    b.Property<int>("IdStil")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("FaktorMnozenja");

                    b.Property<string>("NazivStil");

                    b.Property<string>("Opis");

                    b.HasKey("IdStil");

                    b.ToTable("StilUkrasavanja");

                    b.HasData(
                        new { IdStil = 1, FaktorMnozenja = 1.5f, NazivStil = "Romantičan", Opis = "Ukrašava se toplim bojama dobrim za srce i ljubav" },
                        new { IdStil = 2, FaktorMnozenja = 1.15f, NazivStil = "Tmuran", Opis = "Ukrašava se tmurnim bojama dobrim za pripremu druge osobe za loše vijesti" }
                    );
                });

            modelBuilder.Entity("CtrlAltElite.Entities.Models.Transakcija", b =>
                {
                    b.Property<int>("IdTransakcija")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdresaKupca");

                    b.Property<DateTime>("Datum");

                    b.Property<int>("IdNarudzba");

                    b.Property<string>("ImeKupca");

                    b.Property<decimal>("KonacnaCijena")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 38, scale: 17)))
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("PrezimeKupca");

                    b.HasKey("IdTransakcija");

                    b.HasIndex("IdNarudzba")
                        .IsUnique();

                    b.ToTable("Transakcija");
                });

            modelBuilder.Entity("CtrlAltElite.Entities.Models.Vidljivost", b =>
                {
                    b.Property<int>("IdVidljivost")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdKorisnik");

                    b.Property<bool>("VidljivostAdresaKorisnik");

                    b.Property<bool>("VidljivostEmailKorisnik");

                    b.Property<bool>("VidljivostImeKorisnik");

                    b.Property<bool>("VidljivostPrezimeKorisnik");

                    b.HasKey("IdVidljivost");

                    b.HasIndex("IdKorisnik")
                        .IsUnique();

                    b.ToTable("Vidljivost");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("CtrlAltElite.Entities.Models.Korisnik", b =>
                {
                    b.HasOne("CtrlAltElite.Entities.Models.Role", "Rola")
                        .WithMany("Korisnici")
                        .HasForeignKey("RolaIdRola");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithOne()
                        .HasForeignKey("CtrlAltElite.Entities.Models.Korisnik", "UserName");
                });

            modelBuilder.Entity("CtrlAltElite.Entities.Models.Narudzba", b =>
                {
                    b.HasOne("CtrlAltElite.Entities.Models.Korisnik", "Korisnik")
                        .WithMany("Narudzbe")
                        .HasForeignKey("IdKorisnik")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CtrlAltElite.Entities.Models.Ponuda", "Ponuda")
                        .WithMany("Narudzbe")
                        .HasForeignKey("IdPonuda");

                    b.HasOne("CtrlAltElite.Entities.Models.Status", "Status")
                        .WithMany("Narudzbe")
                        .HasForeignKey("IdStatus")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CtrlAltElite.Entities.Models.Ponuda", b =>
                {
                    b.HasOne("CtrlAltElite.Entities.Models.Predmet", "Predmet")
                        .WithMany("Ponude")
                        .HasForeignKey("IdPredmet")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CtrlAltElite.Entities.Models.StilSalveta", "Salveta")
                        .WithMany("Ponude")
                        .HasForeignKey("IdSalveta")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CtrlAltElite.Entities.Models.StilUkrasavanja", "Stil")
                        .WithMany("Ponude")
                        .HasForeignKey("IdStil")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CtrlAltElite.Entities.Models.PosebnaPonuda", b =>
                {
                    b.HasOne("CtrlAltElite.Entities.Models.Narudzba", "Narudzba")
                        .WithOne("PosebnaPonuda")
                        .HasForeignKey("CtrlAltElite.Entities.Models.PosebnaPonuda", "IdNarudzba")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CtrlAltElite.Entities.Models.Prica", b =>
                {
                    b.HasOne("CtrlAltElite.Entities.Models.Korisnik", "Korisnik")
                        .WithMany("Price")
                        .HasForeignKey("IdKorisnik")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CtrlAltElite.Entities.Models.Status", "Status")
                        .WithMany("Price")
                        .HasForeignKey("IdStatus")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CtrlAltElite.Entities.Models.Prica", "Roditelj")
                        .WithMany("Djeca")
                        .HasForeignKey("RoditeljIdPrica");
                });

            modelBuilder.Entity("CtrlAltElite.Entities.Models.Transakcija", b =>
                {
                    b.HasOne("CtrlAltElite.Entities.Models.Narudzba", "Narudzba")
                        .WithOne("Tansakcija")
                        .HasForeignKey("CtrlAltElite.Entities.Models.Transakcija", "IdNarudzba")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CtrlAltElite.Entities.Models.Vidljivost", b =>
                {
                    b.HasOne("CtrlAltElite.Entities.Models.Korisnik", "Korisnik")
                        .WithOne("Vidljivost")
                        .HasForeignKey("CtrlAltElite.Entities.Models.Vidljivost", "IdKorisnik")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
