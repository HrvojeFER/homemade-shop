using System.ComponentModel.DataAnnotations;

namespace CtrlAltElite.Web.Models
{
    public class PosebnaPonudaIM
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Unesite opis.")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name ="Opiši ponudu", Prompt ="Ovdje unesite opis ponude")]
        public string Opis { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Unesite ime primatelja.")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [RegularExpression(@"^[A-ZŠĐČĆŽ][a-zšđčćž]+$", ErrorMessage = "Unesite važeće ime.\n" +
            "Ime mora početi velikim slovom i smije sadržavati samo abecedne znakove.")]
        [Display(Name ="Ime primatelja", Prompt ="Ovdje unesite ime primatelja")]
        public string ImePrimatelja { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Unesite prezime primatelja.")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [RegularExpression(@"^[A-ZŠĐČĆŽ][a-zšđčćž]+$", ErrorMessage = "Unesite važeće prezime.\n" +
            "Prezime mora početi velikim slovom i smije sadržavati samo abecedne znakove.")]
        [Display(Name ="Prezime primatelja", Prompt ="Ovdje unesite prezime primatelja")]
        public string PrezimePrimatelja { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Unesite adresu primatelja.")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [RegularExpression(@"^[A-ZŠĐČĆŽ][a-zšđčćž]+ ([A-ZŠĐČĆŽ]?[a-zšđčćž]+ )*[(X|V|I)* ]*[0-9]+[A-Z]?$",
            ErrorMessage = "Unesite važeću adresu .\n" +
                           "Adresa mora početi velikim slovom.\n" +
                           "Za broj odvojka ili ulice koristite rimske brojeve.\n" +
                           "Za kućni broj koristite arapski broj i veliko slovo po potrebi.")]
        [Display(Name ="Adresa primatelja", Prompt ="Ovdje unesite adresu primatelja")]
        public string AdresaPrimatelja { get; set; }
    }
}
