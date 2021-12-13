using CtrlAltElite.BL;
using CtrlAltElite.Entities.Data;
using CtrlAltElite.Entities.Data.Migrations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CtrlAltElite.Web.Controllers
{
    public class UserController: BaseController
    {
        private readonly IRepository _repository;
        private readonly UserManager<Microsoft.AspNetCore.Identity.IdentityUser> _userManager;

        public UserController(IRepository repository, UserManager<Microsoft.AspNetCore.Identity.IdentityUser> userManager, ApplicationDbContext context) : 
            base(repository, userManager, context)
        {
            _repository = repository;
            _userManager = userManager;
        }
        public IActionResult About([FromQuery]string UserName)
        {
            bool isAdmin = false;
            var userReq = _userManager.GetUserId(User);
            if (userReq != null)
            {
                isAdmin = _repository.GetKorisnikVM(userReq).Rola == BL.Models.RoleModel.Admin;
            }

            var user = _repository.GetKorisnik(UserName);

            var vm = new Dictionary<string, string>() { { "Korisničko ime", user.User.UserName} };
            if (user.Vidljivost.VidljivostAdresaKorisnik || isAdmin)
            {
                vm.Add("Adresa", user.AdresaKorisnik);
            }
            if (user.Vidljivost.VidljivostEmailKorisnik || isAdmin)
            {
                vm.Add("Mail", user.EmailKorisnik);
            }
            if (user.Vidljivost.VidljivostImeKorisnik || isAdmin)
            {
                vm.Add("Ime", user.ImeKorisnik);
            }
            if (user.Vidljivost.VidljivostImeKorisnik || isAdmin)
            {
                vm.Add("Prezime", user.PrezimeKorisnik);
            }
            if (isAdmin)
            {
                vm.Add("Status", ((BL.Models.RoleModel)user.IdRole).ToString());
            }

            return View((vm, isAdmin, user.UserName));
        }
        
        public IActionResult UpdateKorisnikRola(string id, int rola)
        {
            _repository.UpdateKorisnikRola(id, rola);
            return RedirectToActionPermanent(nameof(About), new { UserName = id });
        }

        public IActionResult ChangeStatus(BL.Models.RoleModel Rola, string idKorisnik)
        {
            _repository.UpdateKorisnikRola(idKorisnik, (int)Rola);
            return RedirectToActionPermanent(nameof(About), new { UserName = idKorisnik });
        }
    }
}
