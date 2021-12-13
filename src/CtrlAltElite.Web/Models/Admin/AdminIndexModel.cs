using System.Collections.Generic;
using CtrlAltElite.Web.Models.Admin;
using Microsoft.AspNetCore.Mvc;

namespace CtrlAltElite.BL.Models.Admin
{
    public class AdminIndexModel
    {
        [BindProperty]
        public PredmetIM PredmetInput { get; set; }
        [BindProperty]
        public DodajPonuduInput PonudaInput { get; set; }
        [BindProperty]
        public StilIM StilInput { get; set; }

        public IEnumerable<KorisnikAdminVM> Korisnik { get; set; }
        public IEnumerable<PredmetVM> Predmeti { get; set; }

        public IEnumerable<StilVM> StiloviSalveta { get; set; }
        public IEnumerable<StilVM> StiloviUkrasavanja { get; set; }
    }
}