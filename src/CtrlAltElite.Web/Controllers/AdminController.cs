using System;
using System.Linq;
using CtrlAltElite.BL;
using CtrlAltElite.BL.Models.Admin;
using CtrlAltElite.Entities.Data;
using CtrlAltElite.Entities.Models;
using CtrlAltElite.Web.Models;
using CtrlAltElite.Web.Models.Admin;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CtrlAltElite.Web.Controllers
{
    public class AdminController : BaseController
    {
        private readonly IRepository _repository;
        private readonly UserManager<IdentityUser> _userManager;

        public AdminController(IRepository repository, UserManager<IdentityUser> userManager, ApplicationDbContext context) : base(repository, userManager, context)
        {
            _repository = repository;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            if (!IsAdmin())
                return Redirect("/");
            var allKorisnici = _repository.GetAllKorisnici();
            var allPredmeti = _repository.GetAllPredmeti();
            var allStilSalveta = _repository.GetAllStilSalveta();
            var allStilUkrasavanja = _repository.GetAllStilUkrasavanja();

            var modelPredmeti = allPredmeti.Select(predmet => new PredmetVM()
            {
                BaznaCijena = predmet.BaznaCijena,
                SlikaUrl = predmet.SlikaUrl,
                Visina = predmet.Visina,
                Duzina = predmet.Duzina,
                IdPredmet = predmet.IdPredmet,
                Opis = predmet.Opis,
                NazivPredmet = predmet.NazivPredmet,
                Sirina = predmet.Sirina
            }).ToList();

            var modelKorisnika = allKorisnici.Select(korisnik => new KorisnikAdminVM
            {
                ImeKorisnik = korisnik.ImeKorisnik,
                PrezimeKorisnik = korisnik.PrezimeKorisnik,
                Rola = korisnik.IdRole == 1 ? "Banani korisnik" :
                    korisnik.IdRole == 2 ? "Registrirani korisnik" :
                    korisnik.IdRole == 3 ? "Admin" : "ništa",
                PwdKorisnik = korisnik.PwdKorisnik,
                AdresaKorisnik = korisnik.AdresaKorisnik,
                EmailKorisnik = korisnik.EmailKorisnik,
                UserName = korisnik.User.UserName,
                IdKorisnik = korisnik.UserName
            }).ToList();

            var stiloviSalvetaModel = allStilSalveta.Select(stil => new StilVM()
            {
                FaktorMnozenja = stil.FaktorMnozenja,
                OpisStila = stil.Opis,
                NazivStil = stil.NazivSalveta,
                IdStil = stil.IdSalveta
            }).ToList();

            var stiloviUkrasavanjaModel = allStilUkrasavanja.Select(stil => new StilVM()
            {
                FaktorMnozenja = stil.FaktorMnozenja,
                OpisStila = stil.Opis,
                NazivStil = stil.NazivStil,
                IdStil = stil.IdStil
            }).ToList();

            return View(new AdminIndexModel
            {
                Korisnik = modelKorisnika,
                PredmetInput = new PredmetIM(),
                StilInput = new StilIM(),
                Predmeti = modelPredmeti,
                StiloviSalveta = stiloviSalvetaModel,
                StiloviUkrasavanja = stiloviUkrasavanjaModel
            });
        }

        [HttpPost]
        public IActionResult DodajPredmet(PredmetIM predmetInput)
        {
            if (!IsAdmin())
                return Redirect("/");
            _repository.AddPredmet(new Predmet
            {
                BaznaCijena = predmetInput.BaznaCijena,
                Duzina = predmetInput.Dužina,
                NazivPredmet = predmetInput.NazivPredmeta,
                Opis = predmetInput.OpisPredmeta,
                Sirina = predmetInput.Širina,
                SlikaUrl = predmetInput.SlikaURL,
                Visina = predmetInput.Visina,
            });
            TempData["Success"] = "Added Successfully!";
            return RedirectToAction("Index");
        }

        public IActionResult UkloniPredmet(int id)
        {
            if (!IsAdmin())
                return Redirect("/");
            _repository.RemovePredmet(id);
            return RedirectToAction("Index");
        }

        public IActionResult UkloniStilUkrasavanja(int id)
        {
            if (!IsAdmin())
                return Redirect("/");
            _repository.RemoveStilUkrasavanja(id);
            return RedirectToAction("Index");
        }

        public IActionResult UkloniStilSalveta(int id)
        {
            if (!IsAdmin())
                return Redirect("/");
            _repository.RemoveStilSalveta(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DodajPricu(PricaIM input)
        {
            if (!IsAdmin())
                return Redirect("/");
            var userId = _userManager.GetUserId(User);
            var korisnik = _repository.GetKorisnikVM(userId);
            _repository.AddPrica(new Prica
            {
                Sadrzaj = input.Sadrzaj,
                UrlSlike = input.URL,
                VrijemeObjave = DateTime.Now,
                IdKorisnik = korisnik.Id,
                IdStatus = 1
            });
            return RedirectToAction("Index", "Home");
        }

        public IActionResult PrihvatiPricu(int idPrice)
        {
            if (!IsAdmin())
                return Redirect("/");
            _repository.UpdateStatusPricaToObjavljeno(idPrice);
            return RedirectToActionPermanent(nameof(PredlozenePrice));
        }

        public IActionResult OdbijPricu(int idPrice)
        {
            if (!IsAdmin())
                return Redirect("/");
            _repository.UpdateStatusPricaToOdbijeno(idPrice);
            return RedirectToActionPermanent(nameof(PredlozenePrice));
        }

        [HttpPost]
        public IActionResult DodajStilSalvete(StilIM stilInput)
        {
            if (!IsAdmin())
                return Redirect("/");
            _repository.AddStilSalveta(new StilSalveta()
            {
                FaktorMnozenja = stilInput.FaktorMnozenja,
                NazivSalveta = stilInput.NazivStila,
                Opis = stilInput.OpisStila,
            });
            TempData["StilSalvetaSuccess"] = "Added Successfully!";
            return RedirectToAction("Index", "Admin");
        }

        [HttpPost]
        public IActionResult DodajStilUkrasavanja(StilIM stilInput)
        {
            if (!IsAdmin())
                return Redirect("/");
            _repository.AddStilUkrasavanja(new StilUkrasavanja()
            {
                FaktorMnozenja = stilInput.FaktorMnozenja,
                NazivStil = stilInput.NazivStila,
                Opis = stilInput.OpisStila,
            });
            TempData["StilUkrasavanjaSuccess"] = "Added Successfully!";
            return RedirectToAction("Index", "Admin");
        }

        [HttpPost]
        public IActionResult DodajPonudu(DodajPonuduInput ponudaInput)
        {
            if (!IsAdmin())
                return Redirect("/");
            var predmet = _repository.GetPredmet(ponudaInput.PredmetId);
            var stilSalvete = _repository.GetStilSalveta(ponudaInput.SalvetaId);
            var stilUkrasavanja = _repository.GetStilUkrasavanja(ponudaInput.StilUkrasavanjaId);

            var cijena = predmet.BaznaCijena * (decimal) stilSalvete.FaktorMnozenja *
                         (decimal) stilUkrasavanja.FaktorMnozenja;

            _repository.AddPonuda(ponudaInput.SalvetaId, ponudaInput.StilUkrasavanjaId, ponudaInput.PredmetId, cijena);
            TempData["PonudaSuccess"] = "Added Successfully!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult PredlozenePrice()
        {
            if (!IsAdmin())
                return Redirect("/");
            var model = _repository.GetPredlozenePrice();
            var vm = model.Select(i => new PricaAdminVM
            {
                IdKoriknika = i.IdKorisnika,
                IdPrice = i.IdPrice,
                ImeKorisnika = i.ImeKorisnika,
                MozeSeKomentirati = true,
                Sadrzaj = i.Sadrzaj,
                UrlSlike = i.UrlSlike,
                Vrijeme = $"{i.VrijemeObjave.ToShortDateString()}"
            }).ToList();
            return View(vm);
        }
    }
}