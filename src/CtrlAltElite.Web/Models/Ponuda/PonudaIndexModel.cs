using System.Collections.Generic;

namespace CtrlAltElite.Web.Models.Ponuda
{
    public class PonudaIndexModel
    {
        public IEnumerable<PredmetListingModel> PredmetiNaPonudi { get; set; }
        
        public PosebnaPonudaIM PosebnaPonudaInput { get; set; }
    }
}
