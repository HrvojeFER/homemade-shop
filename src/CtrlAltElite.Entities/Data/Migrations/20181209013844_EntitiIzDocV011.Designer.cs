﻿// <auto-generated />
using System;
using CtrlAltElite.Entities.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CtrlAltElite.Entities.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20181209013844_EntitiIzDocV011")]
    partial class EntitiIzDocV011
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("IdPonuda");

                    b.Property<int>("IdPosebnaPonuda");

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
                });

            modelBuilder.Entity("CtrlAltElite.Entities.Models.Prica", b =>
                {
                    b.Property<int>("IdPrica")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdKorisnik");

                    b.Property<int>("IdRoditelj");

                    b.Property<int>("IdStatus");

                    b.Property<int?>("RoditeljIdPrica");

                    b.Property<string>("Sadrzaj");

                    b.Property<DateTime>("VrijemeObjave");

                    b.HasKey("IdPrica");

                    b.HasIndex("IdKorisnik");

                    b.HasIndex("IdStatus");

                    b.HasIndex("RoditeljIdPrica");

                    b.ToTable("Prica");
                });

            modelBuilder.Entity("CtrlAltElite.Entities.Models.Role", b =>
                {
                    b.Property<int>("IdRola")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Rola");

                    b.HasKey("IdRola");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("CtrlAltElite.Entities.Models.Status", b =>
                {
                    b.Property<int>("IdStatus")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Vrijednost");

                    b.HasKey("IdStatus");

                    b.ToTable("Status");
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
                });

            modelBuilder.Entity("CtrlAltElite.Entities.Models.Narudzba", b =>
                {
                    b.HasOne("CtrlAltElite.Entities.Models.Korisnik", "Korisnik")
                        .WithMany("Narudzbe")
                        .HasForeignKey("IdKorisnik")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CtrlAltElite.Entities.Models.Ponuda", "Ponuda")
                        .WithMany("Narudzbe")
                        .HasForeignKey("IdPonuda")
                        .OnDelete(DeleteBehavior.Cascade);

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
