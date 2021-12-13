using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using CtrlAltElite.BL;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CtrlAltElite.Web.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly IRepository _repository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IEmailSender _emailSender;

        public IndexModel(IRepository repository,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IEmailSender emailSender)
        {
            _repository = repository;
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }

        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required(AllowEmptyStrings = false, ErrorMessage = "Unesite svoje ime.")]
            [DisplayFormat(ConvertEmptyStringToNull = false)]
            [RegularExpression(@"^[A-ZŠĐČĆŽ][a-zšđčćž]+$", ErrorMessage = "Unesite važeće ime. " +
                "Ime mora početi velikim slovom i smije sadržavati samo abecedne znakove.")]
            [Display(Name = "Ime", Prompt = "Ovdje unesite svoje ime")]
            public string Name { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Unesite svoje prezime.")]
            [DisplayFormat(ConvertEmptyStringToNull = false)]
            [RegularExpression(@"^[A-ZŠĐČĆŽ][a-zšđčćž]+$", ErrorMessage = "Unesite važeće prezime. " +
                "Prezime mora početi velikim slovom i smije sadržavati samo abecedne znakove.")]
            [Display(Name = "Prezime", Prompt = "Ovdje unesite svoje prezime")]
            public string Surname { get; set; }
            
            [DisplayFormat(ConvertEmptyStringToNull = false)]
            [RegularExpression(
                @"^[A-ZŠĐČĆŽ][a-zšđčćž]+ ([A-ZŠĐČĆŽ]?[a-zšđčćž]+ )*[(X|V|I)* ]*[0-9]+[A-Z]?$",
            ErrorMessage = "Unesite važeću adresu .\n" +
                           "Adresa mora početi velikim slovom.\n" +
                           "Za broj odvojka ili ulice koristite rimske brojeve.\n" +
                           "Za kućni broj koristite arapski broj i veliko slovo po potrebi.")]
            [Display(Name = "Adresa", Prompt = "Ovdje unesite svoju adresu")]
            public string Address { get; set; }


            [Required(ErrorMessage = "Unesite svoj email.")]
            [EmailAddress(ErrorMessage = "Unesite važeći email.")]
            [Display(Name = "Email", Prompt = "Ovdje unesite svoj email.")]
            public string Email { get; set; }

            [DataType(DataType.Password, ErrorMessage = "Unesite važeću lozinku.")]
            [Display(Name = "Stara lozinka", Prompt = "Ovdje unesite staru lozinku")]
            public string OldPassword { get; set; }
            
            [StringLength(100, ErrorMessage = "{0} mora biti barem {2} znakova i maksimalno {1}.", 
                MinimumLength = 6)]
            [DataType(DataType.Password, ErrorMessage = "Unesite važeću lozinku.")]
            [Display(Name = "Nova lozinka", Prompt = "Ovdje unesite novu lozinku")]
            public string NewPassword { get; set; }


            [Display(Name = "Vidljivost")]
            public bool UsernameVisibility { get; set; } = true;
            [Display(Name = "Vidljivost")]
            public bool NameVisibility { get; set; }
            [Display(Name = "Vidljivost")]
            public bool SurnameVisibility { get; set; }
            [Display(Name = "Vidljivost")]
            public bool EmailVisibility { get; set; }
            [Display(Name = "Vidljivost")]
            public bool AddressVisibility { get; set; }

        }

        public  IActionResult OnGet()
        {
            var user = _userManager.GetUserId(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var korisnik = _repository.GetKorisnik(user);
            Username = korisnik.User.UserName;
            Input = new InputModel
            {
                Email = korisnik.EmailKorisnik,
                Address = korisnik.AdresaKorisnik,
                AddressVisibility = korisnik.Vidljivost.VidljivostAdresaKorisnik,
                EmailVisibility = korisnik.Vidljivost.VidljivostEmailKorisnik,
                Name = korisnik.ImeKorisnik,
                NameVisibility = korisnik.Vidljivost.VidljivostImeKorisnik,
                NewPassword = korisnik.PwdKorisnik,
                Surname = korisnik.PrezimeKorisnik,
                SurnameVisibility = korisnik.Vidljivost.VidljivostPrezimeKorisnik,
                UsernameVisibility = true
            };

            IsEmailConfirmed = true;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
            {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var curUser = await _userManager.GetUserAsync(User);
            var user = _userManager.GetUserId(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            var passOk = false;
            var mailOk = false;
            if (!string.IsNullOrWhiteSpace(Input.NewPassword))
            {
                var res = await _userManager.ChangePasswordAsync(curUser, Input.OldPassword, Input.NewPassword);
                passOk = res.Succeeded;
            }
            var email = await _userManager.GetEmailAsync(curUser);
            if (Input.Email != email)
            {
                var setEmailResult = await _userManager.SetEmailAsync(curUser, Input.Email);
                mailOk = setEmailResult.Succeeded;
            }
            _repository.UpdateKorisnik(user, Input.Address, Input.AddressVisibility, mailOk ? Input.Email : default, Input.EmailVisibility, Input.Name, Input.NameVisibility, passOk ? Input.NewPassword : default, Input.Surname, Input.SurnameVisibility);
            
            await _signInManager.RefreshSignInAsync(curUser);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostSendVerificationEmailAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }


            var userId = await _userManager.GetUserIdAsync(user);
            var email = await _userManager.GetEmailAsync(user);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var callbackUrl = Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new { userId = userId, code = code },
                protocol: Request.Scheme);
            await _emailSender.SendEmailAsync(
                email,
                "Confirm your email",
                $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

            StatusMessage = "Verification email sent. Please check your email.";
            return RedirectToPage();
        }
    }
}
