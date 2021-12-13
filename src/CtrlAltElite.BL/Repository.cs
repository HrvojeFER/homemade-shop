using System.Collections.Generic;
using System.Linq;
using CtrlAltElite.BL.Models;
using CtrlAltElite.Entities.Data;
using CtrlAltElite.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Narudzba = CtrlAltElite.Entities.Models.Narudzba;
using TransakcijaVM = CtrlAltElite.BL.Models.TransakcijaVM;


namespace CtrlAltElite.BL
{
    //Main implementation of the interface for database access, IRepository.
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public Repository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //      Methods for Korisnik.

        public Korisnik GetKorisnik(string userName)
        {
            return _context.Korisnik
                .Where(i => i.UserName == userName)
                .Include(i => i.User)
                .Include(i => i.Vidljivost)
                .FirstOrDefault();
        }

        public KorisnikVM GetKorisnikVM(string userName)
        {
            var korisnik = _context.Korisnik.FirstOrDefault(i => i.UserName == userName);
            return _mapper.ToKorsnikVM(korisnik);
        }

        public IEnumerable<Korisnik> GetAllKorisnici()
        {
            return _context.Korisnik
                .Include(korisnik => korisnik.Price)
                .Include(korisnik => korisnik.Narudzbe)
                .Include(i => i.User)
                .ToList();
        }

        public void UpdateKorisnikRola(string idKorisnik, int rola)
        {
            var korisnik = _context.Korisnik.FirstOrDefault(i => i.UserName == idKorisnik);
            korisnik.IdRole = rola;
            _context.SaveChanges();

        }

        public void UpdateKorisnik(string user, string address, bool addressVisibility, string email, 
            bool emailVisibility, string name, bool nameVisibility, string password, string surname, bool surnameVisibility)
        {
            var korisnik = _context.Korisnik
                .Include(i => i.Vidljivost)
                .FirstOrDefault(i => i.UserName == user);
            korisnik.AdresaKorisnik = address;
            korisnik.EmailKorisnik = string.IsNullOrWhiteSpace(email) ? korisnik.EmailKorisnik : email;
            korisnik.ImeKorisnik = name;
            korisnik.PrezimeKorisnik = surname;
            korisnik.PwdKorisnik = string.IsNullOrWhiteSpace(password) ? korisnik.PwdKorisnik : password;
            korisnik.Vidljivost.VidljivostAdresaKorisnik = addressVisibility;
            korisnik.Vidljivost.VidljivostImeKorisnik = nameVisibility;
            korisnik.Vidljivost.VidljivostPrezimeKorisnik = surnameVisibility;
            korisnik.Vidljivost.VidljivostEmailKorisnik = emailVisibility;
            _context.SaveChanges();
        }

        //      Methods for Narudzba.

        public List<NarudzbaVM> GetNarudzbeKorisnik(string userName, int filter = -1)
        {
            int? userId = _context.Korisnik
                .Include(i => i.Narudzbe)
                .FirstOrDefault(kor => kor.UserName == userName)?.IdKorisnik;

            return _context.Narudzba.Where(nar => nar.IdKorisnik == userId)
                                    .Where(i => filter == -1 || i.IdStatus == filter)
                                    .Include(nar => nar.Ponuda)
                                    .Include(nar => nar.Ponuda.Predmet)
                                    .Include(nar => nar.Ponuda.Salveta)
                                    .Include(nar => nar.Ponuda.Stil)
                                    .Include(nar => nar.PosebnaPonuda)
                                    .Include(nar => nar.Status)
                                    .OrderByDescending(i => i.Datum)
                                    .Select(nar => _mapper.ToNarudzbaVM(nar))
                                    .ToList();
        }

        public List<NarudzbaVM> GetNarudzbeAdmin(int filter = -1)
        {
            return _context.Narudzba.Where(i => filter == -1 || i.IdStatus == filter)
                                    .Include(nar => nar.Ponuda)
                                    .Include(nar => nar.Ponuda.Predmet)
                                    .Include(nar => nar.Ponuda.Salveta)
                                    .Include(nar => nar.Ponuda.Stil)
                                    .Include(nar => nar.PosebnaPonuda)
                                    .Include(nar => nar.Status)
                                    .OrderByDescending(i => i.Datum)
                                    .Select(nar => _mapper.ToNarudzbaVM(nar))
                                    .ToList();
        }

        public void AddNarudzba(Narudzba narudzba)
        {
            _context.Narudzba.Add(narudzba);
            _context.SaveChanges();
        }

        public void UpdateStatusNarudzbaToPrihvaceno(int idNarudzba, decimal cijena)
        {
            UpdateStatusNarudzba(idNarudzba, "Odobreno");
            var narudzba = _context.Narudzba.FirstOrDefault(nar => nar.IdNarudzba == idNarudzba);
            narudzba.KonacnaCijena = cijena;
            _context.SaveChanges();
        }

        public void UpdateStatusNarudzbaToOdbijeno(int idNarudzba)
        {
            UpdateStatusNarudzba(idNarudzba, "Odbijeno");
        }

        public void UpdateStatusNarudzbaToIsporuceno(int idNarudzba)
        {
            UpdateStatusNarudzba(idNarudzba, "Isporučeno");
        }

        private void UpdateStatusNarudzba(int id, string vrijednost)
        {
            var narudzba = _context.Narudzba.FirstOrDefault(nar => nar.IdNarudzba == id);
            var oldStatus = _context.Status.FirstOrDefault(stat => stat.IdStatus == narudzba.IdStatus);
            var status = _context.Status.FirstOrDefault(stat => stat.Vrijednost == vrijednost);

            oldStatus.Narudzbe.Remove(narudzba);
            narudzba.Status = status;
            if (status.Narudzbe == null)
            {
                status.Narudzbe = new List<Narudzba>();
            }
            status.Narudzbe.Add(narudzba);
            _context.SaveChanges();
        }

        public void RemoveNarudzba(int idNarudzba)
        {
            var narudzba = _context.Narudzba.FirstOrDefault(nar => nar.IdNarudzba == idNarudzba);

            if (narudzba.IdPosebnaPonuda.HasValue)
            {
                _context.PosebnaPonuda.Remove(_context.PosebnaPonuda.FirstOrDefault(pp => pp.IdNarudzba == narudzba.IdNarudzba));
            }

            _context.Narudzba.Remove(narudzba);
            _context.SaveChanges();
        }

        //      Methods for Ponuda.

        public Ponuda GetPonuda(int ponudaId)
        {
            return GetAllPonuda()
                .FirstOrDefault(ponuda => ponuda.IdPonuda == ponudaId);
        }

        public IEnumerable<Ponuda> GetAllPonuda()
        {
            return _context.Ponuda
                .Include(ponuda => ponuda.Narudzbe)
                .Include(ponuda => ponuda.Predmet)
                .Include(predmet => predmet.Stil)
                .Include(predmet => predmet.Salveta)
                .ToList();
        }

        public void AddPonuda(int idSalvete, int idStil, int idPredmet, decimal cijena)
        {
            var salveta = _context.StilSalveta.FirstOrDefault(sal => sal.IdSalveta == idSalvete);
            var stil = _context.StilUkrasavanja.FirstOrDefault(s => s.IdStil == idStil);
            var predmet = _context.Predmet.FirstOrDefault(pred => pred.IdPredmet == idPredmet);

            var ponuda = new Ponuda
            {
                IdSalveta = salveta.IdSalveta,
                Salveta = salveta,
                IdPredmet = predmet.IdPredmet,
                Predmet = predmet,
                IdStil = stil.IdStil,
                Stil = stil,
                Cijena = cijena
            };

            salveta.Ponude.Add(ponuda);
            stil.Ponude.Add(ponuda);
            predmet.Ponude.Add(ponuda);
            _context.SaveChanges();
        }

        public void RemovePonuda(int ponudaId)
        {
            _context.Ponuda.Remove(GetPonuda(ponudaId));
            _context.SaveChanges();
        }

        //      Methods for Transakcija.

        public Transakcija GetTransakcijaByNarudzba(int idNarudzba)
        {
            return _context.Transakcija.FirstOrDefault(tran => tran.IdNarudzba == idNarudzba);
        }

        public List<TransakcijaVM> GetTransakcijeAdmin()
        {
            return _context.Transakcija
                .Select(i => _mapper.ToTransakcijaVM(i)).ToList();
        }

        public List<TransakcijaVM> GetTransakcijeKorisnik(string userName)
        {
            return _context.Transakcija
                .Include(i => i.Narudzba)
                .Include(i => i.Narudzba.Korisnik)
                .Where(i => i.Narudzba.Korisnik.ImeKorisnik == userName)
                .Select(i => _mapper.ToTransakcijaVM(i)).ToList();
        }

        public void AddTransakcija(int idNarudzba, string imeKupca, string prezimeKupca, string adresaKupca)
        {
            var narudzba = _context.Narudzba.FirstOrDefault(nar => nar.IdNarudzba == idNarudzba);

            var transakcija = new Transakcija
            {
                IdNarudzba = narudzba.IdNarudzba,
                Narudzba = narudzba,
                Datum = DateTime.Now,
                KonacnaCijena = (double)narudzba.KonacnaCijena,
                ImeKupca = imeKupca,
                PrezimeKupca = prezimeKupca,
                AdresaKupca = adresaKupca
            };

            narudzba.Tansakcija = transakcija;
            _context.Transakcija.Add(transakcija);
            UpdateStatusNarudzba(idNarudzba, "Kupljeno");
            _context.SaveChanges();
        }

        //      Methods for Prica.

        public Prica GetPrica(int pricaId)
        {
            return _context.Prica
                .Include(prica => prica.Djeca)
                .FirstOrDefault(prica => prica.IdPrica == pricaId);
        }

        public List<PricaVM> GetAllPrice()
        {
            var retPrice = _context.Prica
                .Where(i => i.RoditeljIdPrica == null)
                .OrderByDescending(i => i.VrijemeObjave)
                .Include(i => i.Djeca)
                .Include(i => i.Korisnik)
                .Select(i => new PricaVM
                {
                    IdKorisnika = i.Korisnik.UserName,
                    IdPrice = i.IdPrica,
                    ImeKorisnika = i.Korisnik.ImeKorisnik,
                    Sadrzaj = i.Sadrzaj,
                    UrlSlike = i.UrlSlike,
                    VrijemeObjave = i.VrijemeObjave,
                    Komentari = i.Djeca.Select(j => new PricaVM
                    {
                        IdKorisnika = j.Korisnik.UserName,
                        IdPrice = j.IdPrica,
                        ImeKorisnika = j.Korisnik.ImeKorisnik,
                        Sadrzaj = j.Sadrzaj,
                        UrlSlike = j.UrlSlike,
                        VrijemeObjave = j.VrijemeObjave,
                    }).ToList()
                }).ToList();
            return retPrice;
        }

        public List<PricaVM> GetPrihvacenePrice()
        {
            var retPrice = _context.Prica
                .Where(i => i.RoditeljIdPrica == null && i.IdStatus == 1)
                .OrderByDescending(i => i.VrijemeObjave)
                .Include(i => i.Djeca)
                .Include(i => i.Korisnik)
                .Select(i => new PricaVM
                {
                    IdKorisnika = i.Korisnik.UserName,
                    IdPrice = i.IdPrica,
                    ImeKorisnika = i.Korisnik.ImeKorisnik,
                    Sadrzaj = i.Sadrzaj,
                    UrlSlike = i.UrlSlike,
                    VrijemeObjave = i.VrijemeObjave,
                    Komentari = i.Djeca.Select(j => new PricaVM
                    {
                        IdKorisnika = j.Korisnik.UserName,
                        IdPrice = j.IdPrica,
                        ImeKorisnika = j.Korisnik.ImeKorisnik,
                        Sadrzaj = j.Sadrzaj,
                        UrlSlike = j.UrlSlike,
                        VrijemeObjave = j.VrijemeObjave,
                    })
                    .OrderBy(j => j.VrijemeObjave)
                    .ToList()
                }).ToList();
            return retPrice;
        }

        public List<PricaVM> GetPredlozenePrice()
        {
            var retPrice = _context.Prica
                .Where(i => i.RoditeljIdPrica == null && i.IdStatus == 3)
                .Include(i => i.Korisnik)
                .Select(i => new PricaVM
                {
                    IdKorisnika = i.Korisnik.UserName,
                    IdPrice = i.IdPrica,
                    ImeKorisnika = i.Korisnik.ImeKorisnik,
                    Sadrzaj = i.Sadrzaj,
                    UrlSlike = i.UrlSlike,
                    VrijemeObjave = i.VrijemeObjave,
                }).OrderByDescending(i => i.VrijemeObjave).ToList();
            return retPrice;
        }

        public List<PriceBezKomentara> PriceBezKomentara(int? roditelj = null)
        {
            var retPrice = _context.Prica
                    .Where(i => i.RoditeljIdPrica == roditelj && i.IdStatus == 1)
                    .OrderByDescending(i => i.VrijemeObjave)
                    .Include(i => i.Korisnik)
                    .Include(i => i.Djeca)
                    .Select(i => new PriceBezKomentara
                    {
                        IdKorisnika = i.Korisnik.UserName,
                        IdPrice = i.IdPrica,
                        ImeKorisnika = i.Korisnik.ImeKorisnik,
                        Sadrzaj = i.Sadrzaj,
                        UrlSlike = i.UrlSlike,
                        VrijemeObjave = i.VrijemeObjave,
                        BrojKomentara = i.Djeca == null ? 0 : i.Djeca.Count
                    }).ToList();
            return retPrice;
        }

        public void AddPrica(Prica newPrica)
        {
            _context.Prica.Add(newPrica);
            _context.SaveChanges();
        }

        public void AddKomentar(Prica komentar)
        {
            _context.Prica.Add(komentar);
        }

        public void UpdateStatusPricaToObjavljeno(int idPrice)
        {
            var prica = _context.Prica.First(i => i.IdPrica == idPrice);
            prica.IdStatus = 1;
            _context.SaveChanges();
        }

        public void UpdateStatusPricaToOdbijeno(int idPrice)
        {
            var prica = _context.Prica.First(i => i.IdPrica == idPrice);
            prica.IdStatus = 6;
            _context.SaveChanges();
        }

        public void RemovePrica(int id)
        {
            var prica = GetPrica(id);
            if (prica.Djeca.Any())
            {
                prica.Djeca.Select(i => i.IdPrica).ToList().ForEach(RemovePrica);
            }
            _context.Prica.Remove(prica);
            _context.SaveChanges();
        }

        //      Methods for Predmet.

        public Predmet GetPredmet(int predmetId)
        {
            return _context.Predmet
                .Include(predmet => predmet.Ponude)
                .FirstOrDefault(predmet => predmet.IdPredmet == predmetId);
        }

        public IEnumerable<Predmet> GetAllPredmeti()
        {
            return _context.Predmet
                .Include(predmet => predmet.Ponude);
        }

        public void AddPredmet(Predmet newPredmet)
        {
            _context.Predmet.Add(newPredmet);
            _context.SaveChanges();
        }

        public void RemovePredmet(int predmetId)
        {
            _context.Predmet.Remove(GetPredmet(predmetId));
            _context.SaveChanges();
        }

        //      Methods for StilSalveta.

        public StilSalveta GetStilSalveta(int stilId)
        {
            return _context.StilSalveta
                .Include(stil => stil.Ponude)
                .FirstOrDefault(stil => stil.IdSalveta == stilId);
        }

        public IEnumerable<StilSalveta> GetAllStilSalveta()
        {
            return _context.StilSalveta
                .Include(stil => stil.Ponude)
                .ToList();
        }

        public void AddStilSalveta(StilSalveta noviStil)
        {
            _context.StilSalveta.Add(noviStil);
            _context.SaveChanges();
        }

        public void RemoveStilSalveta(int stilId)
        {
            _context.StilSalveta.Remove(GetStilSalveta(stilId));
            _context.SaveChanges();
        }

        //      Methods for StilUkrasavanje.

        public StilUkrasavanja GetStilUkrasavanja(int stilId)
        {
            return _context.StilUkrasavanja
                .Include(stil => stil.Ponude)
                .FirstOrDefault(stil => stil.IdStil == stilId);
        }

        public IEnumerable<StilUkrasavanja> GetAllStilUkrasavanja()
        {
            return _context.StilUkrasavanja
                .Include(stil => stil.Ponude)
                .ToList();
        }

        public List<StilUkrasavanja> GetValidStiloviUkrasavanja(int idPredmet, int idSalveta)
        {
            var valid = _context.Ponuda
                .Include(i => i.Stil)
                .Where(i => i.IdPredmet == idPredmet && i.IdSalveta == idSalveta)
                .Select(i => i.Stil)
                .GroupBy(i => i.IdStil)
                .Select(i => i.First())
                .ToList();
            return valid;
        }

        public void AddStilUkrasavanja(StilUkrasavanja noviStil)
        {
            _context.StilUkrasavanja.Add(noviStil);
            _context.SaveChanges();
        }

        public void RemoveStilUkrasavanja(int stilId)
        {
            _context.StilUkrasavanja.Remove(GetStilUkrasavanja(stilId));
            _context.SaveChanges();
        }

        //      Other methods.

        public decimal GetFinalCijenaPonuda(int idPredmet, int idSalveta, int idUkras)
        {

            var valid = _context.Ponuda
                .Include(i => i.Stil)
                .Include(i => i.Predmet)
                .Include(i => i.Salveta)
                .FirstOrDefault(i => i.IdPredmet == idPredmet && i.IdSalveta == idSalveta && i.IdStil == idUkras);
            if (valid == null)
                return -1;
            var izracunata = valid.Predmet.BaznaCijena * (decimal)valid.Stil.FaktorMnozenja * (decimal)valid.Salveta.FaktorMnozenja;
            return valid.Cijena <= 0 ? izracunata : valid.Cijena;
        }

        public List<(int, string)> GetAllStatusValues()
        {
            return _context.Status
                .ToList()
                .Select(stat => (stat.IdStatus, stat.Vrijednost))
                .ToList();

        }

        public void AddPosebnaPonuda(string userName, string opis, string imePrimatelja, string prezimePrimatelja, string adresaPrimatelja)
        {
            var status = _context.Status.FirstOrDefault(stat => stat.Vrijednost == "Ponuđeno");
            var korisnik = _context.Korisnik.FirstOrDefault(kor => kor.UserName == userName);

            var narudzba = new Narudzba
            {
                Datum = DateTime.Now,
                Status = status,
                IdStatus = status.IdStatus,
                IdKorisnik = korisnik.IdKorisnik,
                Korisnik = korisnik,
                ImePrimatelja = imePrimatelja,
                PrezimePrimatelja = prezimePrimatelja,
                AdresaPrimatelja = adresaPrimatelja
            };
            var ponuda = new PosebnaPonuda
            {
                Opis = opis,
            };

            ponuda.Narudzba = narudzba;
            ponuda.IdNarudzba = narudzba.IdNarudzba;
            narudzba.PosebnaPonuda = ponuda;
            narudzba.IdPosebnaPonuda = ponuda.IdPosebnaPonuda;

            _context.PosebnaPonuda.Add(ponuda);
            _context.Narudzba.Add(narudzba);
            status.Narudzbe.Add(narudzba);
            _context.SaveChanges();
        }

        public PriceBezKomentara RoditeljPrice(int idPrice) {
            var roditelj = _context.Prica
                .Include(i => i.Korisnik)
                .Include(i => i.Djeca)
                .FirstOrDefault(i => i.Djeca.Any(j => j.IdPrica == idPrice));
            if (roditelj == null)
                return null;
            return new PriceBezKomentara
            {
                IdKorisnika = roditelj.Korisnik.UserName,
                IdPrice = roditelj.IdPrica,
                ImeKorisnika = roditelj.Korisnik.ImeKorisnik,
                Sadrzaj = roditelj.Sadrzaj,
                UrlSlike = roditelj.UrlSlike,
                VrijemeObjave = roditelj.VrijemeObjave,
                BrojKomentara = roditelj.Djeca == null ? 0 : roditelj.Djeca.Count
            };
        }

    }
}