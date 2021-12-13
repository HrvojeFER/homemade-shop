using System.ComponentModel.DataAnnotations;

namespace CtrlAltElite.Web.Models
{
    public class CijenaIM
    {
        [Required(ErrorMessage = "Unesite cijenu.")]
        [Range(0, (double)decimal.MaxValue, ErrorMessage = "Cijena mora biti pozitivan broj.")]
        [Display(Name = "Cijena (u HRK)", Prompt = "Ovdje unesite cijenu u HRK")]
        public decimal Cijena { get; set; }

        public int IdNarudzba { get; set; }
    }
}
