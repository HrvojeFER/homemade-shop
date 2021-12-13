using CtrlAltElite.BL.Models;
using CtrlAltElite.Entities.Models;
using System.Collections.Generic;

namespace CtrlAltElite.BL
{
    //Interface for database access.
    public interface IRepository
    {
        //Methods for Korisnik.
        Korisnik GetKorisnik(string id);
        Models.KorisnikVM GetKorisnikVM(string id);
        IEnumerable<Korisnik> GetAllKorisnici();
        void UpdateKorisnikRola(string id, int rola);
        void UpdateKorisnik(string id, string address, bool addressVisibility, string email, 
            bool emailVisibility, string name, bool nameVisibility, string password, string surname, bool surnameVisibility);

        //Methods for Narudzba.
        List<Models.NarudzbaVM> GetNarudzbeKorisnik(string id, int filter = -1);
        List<Models.NarudzbaVM> GetNarudzbeAdmin(int filter = -1);
        void RemoveNarudzba(int id);
        void UpdateStatusNarudzbaToPrihvaceno(int id, decimal cijena);
        void UpdateStatusNarudzbaToOdbijeno(int id);
        void UpdateStatusNarudzbaToIsporuceno(int id);
        void AddNarudzba(Narudzba narudzba);

        //Methods for Ponuda.
        Ponuda GetPonuda(int id);
        IEnumerable<Ponuda> GetAllPonuda();
        void AddPonuda(int idSalvete, int idStil, int idPredmet, decimal cijena);
        void RemovePonuda(int id);

        //Methods for Transakcija.
        Transakcija GetTransakcijaByNarudzba(int idNarudzba);
        List<Models.TransakcijaVM> GetTransakcijeAdmin();
        List<Models.TransakcijaVM> GetTransakcijeKorisnik(string id);
        void AddTransakcija(int idNarudzba, string imeKupca, string prezimeKupca, string adresaKupca);

        //Methods for Prica.
        Prica GetPrica(int id);
        List<Models.PricaVM> GetAllPrice();
        List<Models.PricaVM> GetPredlozenePrice();
        List<Models.PricaVM> GetPrihvacenePrice();
        List<BL.Models.PriceBezKomentara> PriceBezKomentara(int? roditelj = null);
        BL.Models.PriceBezKomentara RoditeljPrice(int idPrice);
        void AddPrica(Prica prica);
        void AddKomentar(Prica komentar);
        void UpdateStatusPricaToObjavljeno(int id);
        void UpdateStatusPricaToOdbijeno(int id);
        void RemovePrica(int id);

        //Methods for Predmet.
        Predmet GetPredmet(int id);
        IEnumerable<Predmet> GetAllPredmeti();
        void AddPredmet(Predmet predmet);
        void RemovePredmet(int id);

        //Methods for StilSalveta.
        StilSalveta GetStilSalveta(int id);
        IEnumerable<StilSalveta> GetAllStilSalveta();
        void AddStilSalveta(StilSalveta stilSalveta);
        void RemoveStilSalveta(int id);

        //Methods for StilUkrasavanja.
        StilUkrasavanja GetStilUkrasavanja(int id);
        IEnumerable<StilUkrasavanja> GetAllStilUkrasavanja();
        List<StilUkrasavanja> GetValidStiloviUkrasavanja(int idPredmet, int idSalveta);
        void AddStilUkrasavanja(StilUkrasavanja stilUkrasavanja);
        void RemoveStilUkrasavanja(int id);

        //Other methods.
        List<(int, string)> GetAllStatusValues();
        decimal GetFinalCijenaPonuda(int idPredmet, int idSalveta, int idUkras);
        void AddPosebnaPonuda(string userName, string opis, string imePrimatelja, 
            string prezimePrimatelja, string adresaPrimatelja);
    }
}