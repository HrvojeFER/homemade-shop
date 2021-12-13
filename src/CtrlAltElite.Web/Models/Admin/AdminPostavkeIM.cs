using System.ComponentModel.DataAnnotations;

namespace CtrlAltElite.Web.Models.Admin
{
    public class PredmetIM
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Unesite naziv predmeta.")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = "Naziv predmeta", Prompt = "Ovdje unesite naziv predmeta")]
        public string NazivPredmeta { get; set; }

        [Required(ErrorMessage = "Unesite URL slike.")]
        [DataType(DataType.ImageUrl, ErrorMessage = "Unesite važeći URL slike.")]
        [Display(Name = "URL slike predmeta", Prompt = "Ovdje unesite URL slike predmeta")]
        public string SlikaURL { get; set; }

        [Required(ErrorMessage = "Unesite baznu cijenu.")]
        [Range(0, (double)decimal.MaxValue, ErrorMessage = "Bazna cijena mora biti pozitivan broj.")]
        [Display(Name = "Bazna cijena predmeta (u HRK)", Prompt = "Ovdje unesite baznu cijenu predmeta u HRK")]
        public decimal BaznaCijena { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Unesite opis predmeta.")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = "Opis predmeta", Prompt = "Ovdje unesite opis predmeta")]
        public string OpisPredmeta { get; set; }

        [Required(ErrorMessage = "Unesite visinu predmeta.")]
        [Range(0, (double)decimal.MaxValue, ErrorMessage = "Visina mora biti pozitivan broj.")]
        [Display(Name = "Visina predmeta (u cm)", Prompt = "Ovdje unesite visinu predmeta u cm")]
        public decimal Visina { get; set; }

        [Required(ErrorMessage = "Unesite širinu predmeta.")]
        [Range(0, (double)decimal.MaxValue, ErrorMessage = "Širina mora biti pozitivan broj.")]
        [Display(Name = "Širina predmeta (u cm)", Prompt = "Ovdje unesite širinu predmeta u cm")]
        public decimal Širina { get; set; }

        [Required(ErrorMessage = "Unesite dužinu predmeta.")]
        [Range(0, (double)decimal.MaxValue, ErrorMessage = "Dužina mora biti pozitivan broj.")]
        [Display(Name = "Dužina predmeta (u cm)", Prompt = "Ovdje unesite dužinu predmeta u cm")]
        public decimal Dužina { get; set; }
    }

    public class StilIM
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Unesite naziv stila.")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = "Naziv stila", Prompt = "Ovdje unesite naziv stila")]
        public string NazivStila { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Unesite opis stila.")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = "Opis stila", Prompt = "Ovdje unesite opis stila.")]
        public string OpisStila { get; set; }

        [Required(ErrorMessage = "Unesite faktor množenja.")]
        [Range(0, (double)decimal.MaxValue, ErrorMessage ="Faktor množenja mora biti pozitivan broj.")]
        [Display(Name = "Unesite faktor množenja", Prompt = "Ovdje unesite faktor množenja")]
        public float FaktorMnozenja { get; set; }
    }

    public class DodajPonuduInput
    {
        [Required]
        [Display(Name = "Odaberi predmet za ponudu")]
        public int PredmetId { get; set; }

        [Required]
        [Display(Name = "Odaberi stil salvete za predmet")]
        public int SalvetaId { get; set; }

        [Required]
        [Display(Name = "Odaberi stil ukrašavanja za predmet")]
        public int StilUkrasavanjaId { get; set; }

    }
}