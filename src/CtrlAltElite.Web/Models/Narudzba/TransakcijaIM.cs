using System.ComponentModel.DataAnnotations;

namespace CtrlAltElite.Web.Models
{
    public class TransakcijaIM
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Unesite ime kupca.")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [RegularExpression(@"^[A-ZŠĐČĆŽ][a-zšđčćž]+$", ErrorMessage = "Unesite važeće ime.\n" +
            "Ime mora početi velikim slovom i smije sadržavati samo abecedne znakove.")]
        [Display(Name = "Ime kupca", Prompt = "Ovdje unesite ime kupca")]
        public string ImeKupca { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Unesite prezime kupca.")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [RegularExpression(@"^[A-ZŠĐČĆŽ][a-zšđčćž]+$", ErrorMessage = "Unesite važeće prezime.\n" +
            "Prezime mora početi velikim slovom i smije sadržavati samo abecedne znakove.")]
        [Display(Name = "Prezime kupca", Prompt = "Ovdje unesite prezime kupca")]
        public string PrezimeKupca { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Unesite adresu kupca.")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [RegularExpression(@"^[A-ZŠĐČĆŽ][a-zšđčćž]+ ([A-ZŠĐČĆŽ]?[a-zšđčćž]+ )*[(X|V|I)* ]*[0-9]+[A-Z]?$",
            ErrorMessage = "Unesite važeću adresu .\n" +
                           "Adresa mora početi velikim slovom.\n" +
                           "Za broj odvojka ili ulice koristite rimske brojeve.\n" +
                           "Za kućni broj koristite arapski broj i veliko slovo po potrebi.")]
        [Display(Name = "Adresa kupca", Prompt = "Ovdje unesite adresu kupca")]
        public string AdresaKupca { get; set; }
        
        public int IdNarudzba { get; set; }
    }
}
