using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using VNpage.Models;

namespace VNpage.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public LoginModel(SignInManager<ApplicationUser> signInManager,
                          UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [BindProperty]
        public string Username { get; set; } = "";

        [BindProperty]
        public string Password { get; set; } = "";

        public string? ErrorMessage { get; set; }

        public void OnGet()
        {
            // nothing
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            // Buscar usuario por nombre o email
            ApplicationUser? user = null;
            if (Username.Contains("@"))
                user = await _userManager.FindByEmailAsync(Username);
            else
                user = await _userManager.FindByNameAsync(Username);

            if (user == null)
            {
                ErrorMessage = "Usuario o contraseña incorrectos.";
                return Page();
            }

            var result = await _signInManager.PasswordSignInAsync(
                user.UserName,
                Password,
                isPersistent: false,
                lockoutOnFailure: false
            );

            if (result.Succeeded)
            {
                // Redirigir a panel admin si tiene rol
                if (await _userManager.IsInRoleAsync(user, "Admin"))
                    return RedirectToPage("/Admin/Index");

                return RedirectToPage("/Index");
            }

            ErrorMessage = "Usuario o contraseña incorrectos.";
            return Page();
        }
    }
}
