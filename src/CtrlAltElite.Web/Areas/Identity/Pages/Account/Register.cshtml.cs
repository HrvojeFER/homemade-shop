using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using CtrlAltElite.Entities.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CtrlAltElite.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly ApplicationDbContext _context;

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required(AllowEmptyStrings = false, ErrorMessage = "Unesite svoje ime.")]
            [DisplayFormat(ConvertEmptyStringToNull = false)]
            [RegularExpression(@"^[A-ZŠĐČĆŽ][a-zšđčćž]+$", ErrorMessage = "Unesite važeće ime. " +
                "Ime mora početi velikim slovom i smije sadržavati samo abecedne znakove.")]
            [Display(Name = "Ime", Prompt = "Ovdje unesite svoje ime")]
            public string Ime { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Unesite svoje prezime.")]
            [DisplayFormat(ConvertEmptyStringToNull = false)]
            [RegularExpression(@"^[A-ZŠĐČĆŽ][a-zšđčćž]+$", ErrorMessage = "Unesite važeće prezime. " +
                "Prezime mora početi velikim slovom i smije sadržavati samo abecedne znakove.")]
            [Display(Name = "Prezime", Prompt = "Ovdje unesite svoje prezime")]
            public string Prezime { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Unesite korisničko ime." +
                "Korisničko ime ne smije sadržavati praznine.")]
            [DisplayFormat(ConvertEmptyStringToNull = false)]
            [Display(Name = "Korisničko ime", Prompt = "Ovdje unesite korisničko ime")]
            public string Username { get; set; }

            [Required(ErrorMessage = "Unesite svoj email.")]
            [EmailAddress(ErrorMessage = "Unesite važeći email.")]
            [Display(Name = "Email", Prompt ="Ovdje unesite svoj email.")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Unesite lozinku.")]
            [StringLength(100, ErrorMessage = "{0} mora biti barem {2} znakova i maksimalno {1}.", 
                MinimumLength = 6)]
            [DataType(DataType.Password, ErrorMessage = "Unesite važeću lozinku.")]
            [Display(Name = "Lozinka", Prompt = "Ovdje unesite lozinku")]
            public string Password { get; set; }
            
            [DataType(DataType.Password, ErrorMessage = "Unesite važeću lozinku.")]
            [Display(Name = "Potvrdi lozinku", Prompt = "Ovdje potvrdi lozinku")]
            [Compare("Password", ErrorMessage = "Lozinke se ne podudaraju.")]
            public string ConfirmPassword { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = Input.Username, Email = Input.Email };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _context.Korisnik.Add(new Entities.Models.Korisnik
                    {
                        AdresaKorisnik = null,
                        EmailKorisnik = Input.Email,
                        ImeKorisnik = Input.Ime,
                        PrezimeKorisnik = Input.Prezime,
                        PwdKorisnik = Input.Password,
                        User = user,
                        UserName = Input.Username,
                        IdRole = 2,
                        Vidljivost = new Entities.Models.Vidljivost
                        {
                            VidljivostAdresaKorisnik = false,
                            VidljivostEmailKorisnik = false,
                            VidljivostImeKorisnik = false,
                            VidljivostPrezimeKorisnik = false
                        }

                    });
                    _context.SaveChanges();
                    _logger.LogInformation("Uspješno otvoren korisnički račun.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Potvrdi svoj email",
                        $"Potvrdite svoj email klikom <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>ovdje</a>.");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
