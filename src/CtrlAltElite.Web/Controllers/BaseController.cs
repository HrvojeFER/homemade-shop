using CtrlAltElite.BL;
using CtrlAltElite.Entities.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CtrlAltElite.Web.Controllers
{
    public class BaseController : Controller
    {
        private readonly IRepository _repository;
        private readonly UserManager<Microsoft.AspNetCore.Identity.IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;

        public BaseController(IRepository repository, UserManager<Microsoft.AspNetCore.Identity.IdentityUser> userManager, ApplicationDbContext context)
        {
            
            _repository = repository;
            _userManager = userManager;
            _context = context;
        }

        public override ViewResult View()
        {
            return IsBanned() ? BannedPage() : base.View();
        }
        public override ViewResult View(object model) 
        {
            return IsBanned() ? BannedPage() : base.View(model);
        }
        public bool IsBanned()
        {
            var user = _userManager.GetUserId(User);
            var korisnik = _repository.GetKorisnikVM(user);
            return (korisnik?.Rola ?? BL.Models.RoleModel.RegistriraniKorisnik) == BL.Models.RoleModel.BananiKorisnik;
            
        }
        public bool IsAdmin()
        {
            var user = _userManager.GetUserId(User);
            var korisnik = _repository.GetKorisnikVM(user);
            return korisnik != null && korisnik.Rola == BL.Models.RoleModel.Admin;
        }
        public bool IsRegistered()
        {
            var user = _userManager.GetUserId(User);
            var korisnik = _repository.GetKorisnik(user);
            return korisnik != null;
        }
        public string UserName()
        {
            var userName = _userManager.GetUserName(User);
            return userName;
        }
        public string UserName(string id)
        {
            var userName = _context.Users.FirstOrDefault(i => i.Id == id);
            return userName?.UserName;
        }
        public ViewResult BannedPage()
        {
            return base.View("~/Views/Shared/BannedPage.cshtml");
        }
    }
}
