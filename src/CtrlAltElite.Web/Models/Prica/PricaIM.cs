using System.ComponentModel.DataAnnotations;

namespace CtrlAltElite.Web.Models
{
    public class PricaIM
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Unesite sadržaj priče.")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = "Sadržaj priče", Prompt = "Ovdje unesite sadržaj priče.")]
        public string Sadrzaj { get; set; }
        
        [Required(ErrorMessage = "Unesite URL slike.")]
        [DataType(DataType.ImageUrl, ErrorMessage = "Unesite važeći URL slike.")]
        [Display(Name = "URL slike", Prompt = "Ovdje unesite URL slike")]
        public string URL { get; set; }

        public int IdRoditelja { get; set; }
    }
}
