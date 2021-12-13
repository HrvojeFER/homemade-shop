using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CtrlAltElite.BL;
using CtrlAltElite.Entities.Data;
using CtrlAltElite.Entities.Models;
using CtrlAltElite.Web.Models;
using CtrlAltElite.Web.Models.Price;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CtrlAltElite.Web.Controllers
{
    public class PriceController : BaseController
    {
        private readonly IRepository _repository;
        private readonly UserManager<IdentityUser> _userManager;
        public PriceController(IRepository repository, UserManager<IdentityUser> userManager, ApplicationDbContext context) : base(repository, userManager, context)
        {
            _repository = repository;
            _userManager = userManager;
        }
        public IActionResult Index(int? idRoditelja)
        {
            var price = _repository.PriceBezKomentara(idRoditelja);
            if (price.Count == 0 && idRoditelja != null) {
                var roditeljPrica = _repository.RoditeljPrice(idRoditelja ?? 0);
                price = _repository.PriceBezKomentara(roditeljPrica.IdPrice);
            }
            var isAdmin = IsAdmin();
            var vm = new IndexVM
            {
                IsAdmin = isAdmin,
                IsRegistered = IsRegistered(),
                Price = price.Select(i => new PricaBezKomentaraVM
                {
                    IsAdmin = isAdmin,
                    IdKoriknika = i.IdKorisnika,
                    IdPrice = i.IdPrice,
                    UserName = i.IdKorisnika,
                    ImeKorisnika = UserName(i.IdKorisnika),
                    Sadrzaj = i.Sadrzaj,
                    UrlSlike = i.UrlSlike,
                    Vrijeme = $"{i.VrijemeObjave.ToShortDateString()}",
                    BrojKomentara = i.BrojKomentara
                }).ToList()
            };
            return View(vm);
        }
        public IActionResult GetComments(int roditelj)
        {
            var price = _repository.PriceBezKomentara(roditelj);
            var isAdmin = IsAdmin();
            var vm = new IndexVM
            {
                IsAdmin = isAdmin,
                IsRegistered = IsRegistered(),
                Price = price.Select(i => new PricaBezKomentaraVM
                {
                    IsAdmin = isAdmin,
                    IdKoriknika = i.IdKorisnika,
                    IdPrice = i.IdPrice,
                    UserName = i.IdKorisnika,
                    ImeKorisnika = UserName(i.IdKorisnika),
                    Sadrzaj = i.Sadrzaj,
                    UrlSlike = i.UrlSlike,
                    Vrijeme = $"{i.VrijemeObjave.ToShortDateString()}",
                    BrojKomentara = i.BrojKomentara
                }).ToList()
            };
            return PartialView("PricePartial", vm);
        }

        public IActionResult GetRoditelj(int idPrice)
        {
            var roditelj = _repository.RoditeljPrice(idPrice);
            if (roditelj == null)
                return null;
            var isAdmin = IsAdmin();
            var vm = new IndexVM
            {
                IsAdmin = isAdmin,
                IsRegistered = IsRegistered(),
                Price = new List<PricaBezKomentaraVM> {  new PricaBezKomentaraVM
                {
                    IsAdmin = isAdmin,
                    IdKoriknika = roditelj.IdKorisnika,
                    IdPrice = roditelj.IdPrice,
                    UserName = roditelj.IdKorisnika,
                    ImeKorisnika = UserName(roditelj.IdKorisnika),
                    Sadrzaj = roditelj.Sadrzaj,
                    UrlSlike = roditelj.UrlSlike,
                    Vrijeme = $"{roditelj.VrijemeObjave.ToShortDateString()}",
                    BrojKomentara = roditelj.BrojKomentara
                } }
            };
            return PartialView("PricePartial", vm);
        }

        [HttpGet]
        public IActionResult PredloziPricu()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PredloziPricu(PricaIM input)
        {
            var userId = _userManager.GetUserId(User);
            var korisnik = _repository.GetKorisnik(userId);
            _repository.AddPrica(new Prica
            {
                Sadrzaj = input.Sadrzaj,
                UrlSlike = input.URL,
                VrijemeObjave = DateTime.Now,
                IdKorisnik = korisnik.IdKorisnik,
                IdStatus = 3
            });
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult DodajKomentar(string sadrzaj, int idPrice, string URL)
        {
            var userId = _userManager.GetUserId(User);
            var korisnik = _repository.GetKorisnik(userId);

            var idAnonymous = _repository.GetAllKorisnici()
                .FirstOrDefault(k => k.ImeKorisnik == "Anonymous")?.IdKorisnik;

            _repository.AddPrica(new Prica
            {
                Sadrzaj = sadrzaj,
                VrijemeObjave = DateTime.Now,
                IdKorisnik = korisnik?.IdKorisnik ?? idAnonymous ?? -1,
                IdStatus = 1,
                RoditeljIdPrica = idPrice,
                UrlSlike = URL ?? "/images/Default.png",

            });
            return Redirect($"/Price/Index?idRoditelja={idPrice}");
        }
        public IActionResult UkloniPricu(int id)
        {
            var parent = _repository.RoditeljPrice(id);
            if (IsAdmin())
                _repository.RemovePrica(id);
            return Redirect($"/Price/Index?idRoditelja={parent.IdPrice}");
        }
    }
}