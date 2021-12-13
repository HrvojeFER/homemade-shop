using System;
using CtrlAltElite.BL.Models;
using CtrlAltElite.Entities.Models;
using TransakcijaVM = CtrlAltElite.BL.Models.TransakcijaVM;

namespace CtrlAltElite.BL
{
    //Main implementation of the interface for mapping database objects into models, IMapper.
    public class Mapper : IMapper
    {
        public KorisnikVM ToKorsnikVM(Korisnik korisnik)
        {
            if (korisnik == null)
                return null;
            return new KorisnikVM
            {
                Id = korisnik.IdKorisnik,
                Ime = korisnik.ImeKorisnik,
                Prezime = korisnik.PrezimeKorisnik,
                Rola = korisnik.IdRole == 1 ? RoleModel.BananiKorisnik :
                       korisnik.IdRole == 2 ? RoleModel.RegistriraniKorisnik :
                       korisnik.IdRole == 3 ? RoleModel.Admin : throw new ArgumentOutOfRangeException(nameof(korisnik.IdRole))
            };
        }

        public NarudzbaVM ToNarudzbaVM(Narudzba narudzba)
        {
            string opis = "";

            if (narudzba.IdPosebnaPonuda.HasValue)
            {
                opis = narudzba.PosebnaPonuda.Opis;
            }
            else if (narudzba.IdPonuda.HasValue)
            {
                opis = $"Opis predmeta \"{narudzba.Ponuda.Predmet.NazivPredmet}\":\n" +
                       $"{narudzba.Ponuda.Predmet.Opis}\n" +
                       $"Dimenzije predmeta: " +
                       $"{narudzba.Ponuda.Predmet.Duzina}x{narudzba.Ponuda.Predmet.Sirina}x{narudzba.Ponuda.Predmet.Visina} cm\n" +
                       $"URL Slike predmeta: \"{narudzba.Ponuda.Predmet.SlikaUrl}\"\n\n" +
                       $"Opis stila salvete \"{narudzba.Ponuda.Salveta.NazivSalveta}\":\n" +
                       $"{narudzba.Ponuda.Salveta.Opis}\n\n" +
                       $"Opis stila ukrašavanja \"{narudzba.Ponuda.Stil.NazivStil}\":\n" +
                       $"{narudzba.Ponuda.Stil.Opis}";
            }

            return new NarudzbaVM
            {
                IdNarudzba = narudzba.IdNarudzba,
                KonacnaCijena = narudzba.KonacnaCijena,
                Datum = narudzba.Datum,
                ImePrimatelja = narudzba.ImePrimatelja,
                PrezimePrimatelja = narudzba.PrezimePrimatelja,
                AdresaPrimatelja = narudzba.AdresaPrimatelja,
                Opis = opis,
                Status = narudzba.Status.Vrijednost,
                IsSpecial = narudzba.IdPosebnaPonuda.HasValue,
                URLSlike = narudzba?.Ponuda?.Predmet?.SlikaUrl
            };
        }

        public TransakcijaVM ToTransakcijaVM(Transakcija transakcija)
        {
            return new TransakcijaVM
            {
                AdresaKupca = transakcija.AdresaKupca,
                Cijena = (decimal) transakcija.KonacnaCijena,
                Datum = transakcija.Datum,
                ImeKupca = transakcija.ImeKupca,
                PrezimeKupca = transakcija.PrezimeKupca
            };
        }
    }
}
