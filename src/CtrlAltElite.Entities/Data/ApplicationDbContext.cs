using System.Collections.Generic;
using CtrlAltElite.Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CtrlAltElite.Entities.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Korisnik> Korisnik { get; set; }
        public DbSet<Vidljivost> Vidljivost { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Narudzba> Narudzba { get; set; }
        public DbSet<Prica> Prica { get; set; }
        public DbSet<PosebnaPonuda> PosebnaPonuda { get; set; }
        public DbSet<Ponuda> Ponuda { get; set; }
        public DbSet<Transakcija> Transakcija { get; set; }
        public DbSet<StilSalveta> StilSalveta { get; set; }
        public DbSet<StilUkrasavanja> StilUkrasavanja { get; set; }
        public DbSet<Predmet> Predmet { get; set; }
        public DbSet<Status> Status { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Korisnik>().HasMany(i => i.Price).WithOne(i => i.Korisnik);
            builder.Entity<Korisnik>().HasMany(i => i.Narudzbe).WithOne(i => i.Korisnik);
            builder.Entity<Korisnik>().HasOne(i => i.Vidljivost).WithOne(i => i.Korisnik).HasForeignKey<Vidljivost>(i => i.IdKorisnik);
            builder.Entity<Korisnik>().HasOne(i => i.Rola).WithMany(i => i.Korisnici);
            builder.Entity<Korisnik>().HasOne(i => i.User).WithOne().HasForeignKey<Korisnik>(i => i.UserName);
            builder.Entity<Prica>().HasOne(i => i.Roditelj).WithMany(i => i.Djeca);
            builder.Entity<Prica>().HasOne(i => i.Status).WithMany(i => i.Price);

            builder.Entity<Narudzba>().HasOne(i => i.Status).WithMany(i => i.Narudzbe);
            builder.Entity<Narudzba>().HasOne(i => i.Tansakcija).WithOne(i => i.Narudzba).HasForeignKey<Transakcija>(i => i.IdNarudzba);
            builder.Entity<Narudzba>().HasOne(i => i.PosebnaPonuda).WithOne(i => i.Narudzba).HasForeignKey<PosebnaPonuda>(i => i.IdNarudzba);
            builder.Entity<Narudzba>().HasOne(i => i.Ponuda).WithMany(i => i.Narudzbe);
            builder.Entity<Narudzba>().Property(i => i.KonacnaCijena).HasColumnType("decimal(10, 2)");

            builder.Entity<Ponuda>().HasOne(i => i.Predmet).WithMany(i => i.Ponude);
            builder.Entity<Ponuda>().HasOne(i => i.Stil).WithMany(i => i.Ponude);
            builder.Entity<Ponuda>().HasOne(i => i.Salveta).WithMany(i => i.Ponude);

            builder.Entity<Transakcija>().Property(i => i.KonacnaCijena).HasColumnType("decimal(10, 2)");

            builder.Entity<Predmet>().Property(i => i.BaznaCijena).HasColumnType("decimal(10, 2)");
            builder.Entity<Role>().HasIndex(i => i.Rola);
            builder.Entity<Role>().HasData(
                new Role { IdRola = 1, Korisnici = new List<Korisnik>(), Rola = "BananiKorisnik" },
                new Role { IdRola=2, Korisnici = new List<Korisnik>(), Rola = "RegistriraniKorisnik" },
                new Role { IdRola = 3, Korisnici = new List<Korisnik>(), Rola = "Admin" }
                );
            builder.Entity<Status>().HasData(
                new Status { IdStatus = 1, Narudzbe = new List<Narudzba>(), Price = new List<Prica>(), Vrijednost = "Objavljeno" },
                new Status { IdStatus = 2, Narudzbe = new List<Narudzba>(), Price = new List<Prica>(), Vrijednost = "Kupljeno" },
                new Status { IdStatus = 3, Narudzbe = new List<Narudzba>(), Price = new List<Prica>(), Vrijednost = "Ponuđeno" },
                new Status { IdStatus = 4, Narudzbe = new List<Narudzba>(), Price = new List<Prica>(), Vrijednost = "Isporučeno" },
                new Status { IdStatus = 5, Narudzbe = new List<Narudzba>(), Price = new List<Prica>(), Vrijednost = "Odobreno" },
                new Status { IdStatus = 6, Narudzbe = new List<Narudzba>(), Price = new List<Prica>(), Vrijednost = "Odbijeno" }
                );
            builder.Entity<Prica>().HasData(
                new Prica { IdPrica = 3, IdKorisnik = 1, RoditeljIdPrica = null, IdStatus = 1, Sadrzaj = "Ova posuda je je baš kao i na stranici. Dizajn je prelijep, a isto tako mi se sviđa tekstura ukrašavanja. Ako želite dobiti komplimente od drugih prijateljica, naručite ovo za dnevnu sobu. Uvelike preporučam.", UrlSlike = "/images/bowl.jpg" },
                new Prica { IdPrica = 4, IdKorisnik = 2, RoditeljIdPrica = null, IdStatus = 1, Sadrzaj = "Posuda za cvijeće od gline je jako lijepa", UrlSlike = "/images/pot.png" },
                new Prica { IdPrica = 5, IdKorisnik = 1, RoditeljIdPrica = 4, IdStatus = 1, Sadrzaj = "Potpuno se slažem, takvu sam ja isto kupila svojoj kćeri.", UrlSlike = "/images/pot.png" },
                new Prica { IdPrica = 6, IdKorisnik = 2, RoditeljIdPrica = null, IdStatus = 1, Sadrzaj = "Drvena kutijica u koju stavljam svoje dragocijene stvari, a mogućnost ukrašavanja joj i više doprinosi na osobnosti", UrlSlike = "/images/box.jpg" },
                new Prica { IdPrica = 7, IdKorisnik = 2, RoditeljIdPrica = 6, IdStatus = 1, Sadrzaj = "Stavio sam ukras koji se toliko svidio mojoj svekrvi, samo lijepe riječi za HandMadeShop.", UrlSlike = "/images/box.jpg" }
                );
            builder.Entity<Predmet>().HasData(
                new Predmet { IdPredmet = 45, NazivPredmet = "Teglica", BaznaCijena = 24.99M, Opis = "Jednostavna teglica za držanje biljki", SlikaUrl = "/images/pot.png", Visina = 16.5M, Duzina = 8, Sirina = 8},
                new Predmet { IdPredmet = 23, NazivPredmet = "Kuglica", BaznaCijena = 4.99M, Opis = "Savršena kgulica za svaki bor!", SlikaUrl = "/images/ball.jpg", Visina = 7, Duzina = 7, Sirina = 7},
                new Predmet { IdPredmet = 33, NazivPredmet = "Stolica", BaznaCijena = 149.99M, Opis = "Neka vaša guza ima lijepi pogled", SlikaUrl = "/images/chair.jpg", Visina = 90, Duzina =49, Sirina = 42}
                );
            builder.Entity<StilSalveta>().HasData(
                new StilSalveta { IdSalveta = 1, NazivSalveta = "Bijela sa srcima", Opis = "Bijela salveta sa uzorcima srca. Dobro za Valentinovo!", FaktorMnozenja = 2.5},
                new StilSalveta { IdSalveta = 2, NazivSalveta = "Trokutići", Opis = "Lijepi stil salvete sa trokutićima!", FaktorMnozenja = 1.5 },
                new StilSalveta { IdSalveta = 3, NazivSalveta = "Cvijetići", Opis = "Lijepi stil salvete sa cvijetićima!", FaktorMnozenja = 1.15 }
                );
            builder.Entity<StilUkrasavanja>().HasData(
                new StilUkrasavanja {IdStil = 1, NazivStil = "Romantičan", Opis = "Ukrašava se toplim bojama dobrim za srce i ljubav", FaktorMnozenja = 1.5F},
                new StilUkrasavanja { IdStil = 2, NazivStil = "Tmuran", Opis = "Ukrašava se tmurnim bojama dobrim za pripremu druge osobe za loše vijesti", FaktorMnozenja = 1.15F }
                );
        }
    }
}
