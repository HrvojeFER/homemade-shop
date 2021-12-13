using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CtrlAltElite.Web.Models;
using Microsoft.AspNetCore.Identity;
using CtrlAltElite.BL;
using CtrlAltElite.Entities.Models;
using CtrlAltElite.Web.Models.Admin;
using CtrlAltElite.Web.Models.Ponuda;
using MoreLinq;
using CtrlAltElite.Entities.Data;

namespace CtrlAltElite.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IRepository _repository;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(IRepository repository, UserManager<IdentityUser> userManager, 
            Entities.Data.ApplicationDbContext context) : 
            base(repository, userManager, context)
        {
            _repository = repository;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return RedirectPermanent("/Price/Index");
        }
        public IActionResult Price()
        {
            return RedirectPermanent("/Price/Index");
        }

        public IActionResult Ponuda()
        {
            var allPonuda = _repository.GetAllPonuda().ToList();

            var listingResult = allPonuda.Select(ponuda => new PredmetListingModel
            {
                PonudaId = ponuda.IdPonuda,
                PredmetId = ponuda.IdPredmet,
                ImePredmetaNaPonudi = ponuda.Predmet.NazivPredmet,
                SlikaUrl = ponuda.Predmet.SlikaUrl,
                OpisPredmeta = ponuda.Predmet.Opis,
                BaznaCijenaPredmeta = ponuda.Predmet.BaznaCijena,
                MoguciStiloviSalveta = allPonuda.Where(i => i.IdPredmet == ponuda.IdPredmet)
                .GroupBy(i => i.IdSalveta)
                .Select(i => i.First())
                .Select(i => new StilVM
                {
                    FaktorMnozenja = i.Salveta.FaktorMnozenja,
                    IdStil = i.IdSalveta,
                    NazivStil = i.Salveta.NazivSalveta,
                    OpisStila = i.Salveta.Opis
                }).ToList(),
                MoguciStiloviUkrasavanja = allPonuda.Where(i => i.IdPredmet == ponuda.IdPredmet)
                .GroupBy(i => i.IdStil)
                .Select(i => i.First())
                .Select(i => new StilVM
                {
                    FaktorMnozenja = i.Stil.FaktorMnozenja,
                    IdStil = i.IdStil,
                    NazivStil = i.Stil.NazivStil,
                    OpisStila = i.Stil.Opis
                }).ToList(),
            }).DistinctBy(p => p.PredmetId);

            var model = new PonudaIndexModel()
            {
                PredmetiNaPonudi = listingResult
            };

            return View(model);
        }
        
        public IActionResult UkloniPonudu(int id)
        {
            _repository.RemovePonuda(id);
            return RedirectToAction("Ponuda");
        }
        
       
        
        public IActionResult Placanje(PlacanjeIM input)
        {
            input.Cijena = _repository.GetFinalCijenaPonuda(input.PredmetId, input.IdSalveta, input.IdStil);
            
            return View(input);
        }

        [HttpPost]
        public IActionResult Kupi(PlacanjeIM input)
        {
            var ponuda = _repository.GetAllPonuda().FirstOrDefault(i =>
                i.IdSalveta == input.IdSalveta && i.IdPredmet == input.PredmetId && i.IdStil == input.IdStil);
            var korisnikId = _userManager.GetUserId(User);
            var korisnik = _repository.GetKorisnikVM(korisnikId);
            var anonId = _repository.GetAllKorisnici().FirstOrDefault(i => i.ImeKorisnik == "Anonymous")?.IdKorisnik; 
            var konacna = _repository.GetFinalCijenaPonuda(input.PredmetId, input.IdSalveta, input.IdStil);
            var narudzba = new Narudzba
            {
                AdresaPrimatelja = input.AdresaPrimatelja,
                Datum = DateTime.Now,
                ImePrimatelja = input.ImePrimatelja,
                PrezimePrimatelja = input.PrezimePrimatelja,
                IdStatus = 4,
                IdPonuda = ponuda.IdPonuda,
                IdKorisnik = korisnik?.Id ?? anonId ?? -1,
                KonacnaCijena = konacna,
            };

            _repository.AddNarudzba(narudzba);
            _repository.AddTransakcija(narudzba.IdNarudzba, input.ImeKupca,input.PrezimeKupca,input.AdresaKupca);
            return RedirectToAction("Index", "Home");
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}