using System.Collections.Generic;
using CtrlAltElite.Web.Models.Admin;

namespace CtrlAltElite.Web.Models.Ponuda
{
    public class PredmetListingModel
    {
        public int PonudaId { get; set; }
        public int PredmetId { get; set; }
        public string ImePredmetaNaPonudi { get; set; }
        public string OpisPredmeta { get; set; }
        public string SlikaUrl { get; set; }
        public decimal BaznaCijenaPredmeta { get; set; }
        public List<StilVM> MoguciStiloviUkrasavanja { get; set; }
        public List<StilVM> MoguciStiloviSalveta { get; set; }
    }
}
