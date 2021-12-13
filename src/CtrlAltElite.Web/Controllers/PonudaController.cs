using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CtrlAltElite.BL;
using CtrlAltElite.Entities.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CtrlAltElite.Web.Controllers
{
    public class PonudaController : BaseController
    {
        private readonly IRepository _repository;
        private readonly UserManager<IdentityUser> _userManager;
        public PonudaController(IRepository repository, UserManager<IdentityUser> userManager, ApplicationDbContext context) : base(repository, userManager, context)
        {
            _repository = repository;
            _userManager = userManager;
        }

        [HttpGet]
        public string GetUkrasavanjeInfo(string idUkras)
        {
            int.TryParse(idUkras, out int id);
            var strilUkr = _repository.GetStilUkrasavanja(id);
            
            return strilUkr.Opis;
        }

        [HttpGet]
        public IActionResult GetValidStiloviUkrasavanja(string idPredmet, string idSalveta)
        {
            int.TryParse(idPredmet, out int idP);
            int.TryParse(idSalveta, out int idS);
            var stiloviUkrasavanja = _repository.GetValidStiloviUkrasavanja(idP, idS)
                .Select(i => (i.IdStil, i.NazivStil))
                .ToList();
            return PartialView("GetValid", (stiloviUkrasavanja, idPredmet));
        }

        [HttpGet]
        public string GetSalvetaInfo(string idSalveta)
        {
            int.TryParse(idSalveta, out int id);
            var salveta = _repository.GetStilSalveta(id);
            var description = salveta.Opis;
            return description;
        }

        [HttpGet]
        public string DobiCijenu(int idPredmet, int idSalveta, int idUkras)
        {
            try
            {
                var cijena = _repository.GetFinalCijenaPonuda(idPredmet, idSalveta, idUkras);
                return cijena != -1 ? $"{cijena:N2} HRK" : "";
            }
            catch (Exception ex)
            {

                return "";
            }
        }
    }
}