using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CtrlAltElite.BL;
using CtrlAltElite.Web.Models;
using CtrlAltElite.Web.Models.Ponuda;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using CtrlAltElite.Entities.Data;

namespace CtrlAltElite.Web.Controllers
{
    public class NarudzbeController : BaseController
    {
        private IRepository _repository;
        private UserManager<IdentityUser> _userManager;

        public NarudzbeController(IRepository repository, 
            UserManager<IdentityUser> userManager, ApplicationDbContext context) : base(repository, userManager, context)
        {
            _repository = repository;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var userName = _userManager.GetUserId(User);
            var user = _repository.GetKorisnikVM(userName);
            var vm = new Models.Narudzba.NarudzbeVM();
            if (user.Rola == BL.Models.RoleModel.RegistriraniKorisnik)
            {
                vm.IsRegisterd = true;
                vm.Narudzbe = _repository.GetNarudzbeKorisnik(userName);
            }
            else if (user.Rola == BL.Models.RoleModel.Admin)
            {
                vm.IsAdmin = true;
                vm.Narudzbe = _repository.GetNarudzbeAdmin();
            }
            
            ViewData["allStatus"] = _repository.GetAllStatusValues()
                                               .Where(stat => stat.Item2 != "Objavljeno")
                                               .ToList();
            return View(vm);
        }
        
        [HttpPost]
        public IActionResult AddTransakcija(TransakcijaIM transakcija)
        {
            _repository.AddTransakcija(transakcija.IdNarudzba,
                transakcija.ImeKupca, transakcija.PrezimeKupca, transakcija.AdresaKupca);
            return RedirectToActionPermanent("Index");
        }
        
        public IActionResult RemoveNarudzba(int id)
        {
            _repository.RemoveNarudzba(id);
            return RedirectToActionPermanent("Index");
        }
        
        public IActionResult UpdateStatusNarudzbaToPrihvaceno(CijenaIM transakcija)
        {
            _repository.UpdateStatusNarudzbaToPrihvaceno(transakcija.IdNarudzba, transakcija.Cijena);
            return RedirectToActionPermanent("Index");
        }
        
        public IActionResult UpdateStatusNarudzbaToOdbijeno(int id)
        {
            _repository.UpdateStatusNarudzbaToOdbijeno(id);
            return RedirectToActionPermanent("Index");
        }
        
        public IActionResult UpdateStatusNarudzbaToIsporuceno(int id)
        {
            _repository.UpdateStatusNarudzbaToIsporuceno(id);
            return RedirectToActionPermanent("Index");
        }

        [HttpPost]
        public IActionResult AddPosebnaPonuda(PonudaIndexModel ponuda)
        {
            _repository.AddPosebnaPonuda(_userManager.GetUserId(User), 
                ponuda.PosebnaPonudaInput.Opis, 
                ponuda.PosebnaPonudaInput.ImePrimatelja, 
                ponuda.PosebnaPonudaInput.ImePrimatelja, 
                ponuda.PosebnaPonudaInput.AdresaPrimatelja);
            return RedirectToActionPermanent("Index");
        }
        [HttpGet]
        public IActionResult FilterNarudzbe(int filter)
        {
            var userName = _userManager.GetUserId(User);
            var user = _repository.GetKorisnikVM(userName);
            var vm = new Models.Narudzba.NarudzbeVM();
            if (user.Rola == BL.Models.RoleModel.RegistriraniKorisnik)
            {
                vm.IsRegisterd = true;
                vm.Narudzbe = _repository.GetNarudzbeKorisnik(userName, filter);
            }
            else if (user.Rola == BL.Models.RoleModel.Admin)
            {
                vm.IsAdmin = true;
                vm.Narudzbe = _repository.GetNarudzbeAdmin(filter);
            }

            return PartialView("NarudzbePartial", vm);
        }
    }
}