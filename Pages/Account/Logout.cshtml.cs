using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace VNpage.Pages
{
    public class LogoutModel : PageModel
    {
        public async Task<IActionResult> OnGetAsync()
        {
            // En lugar de CookieAuthenticationDefaults.AuthenticationScheme,
            // usamos el nombre exacto que el error nos mostró.
            await HttpContext.SignOutAsync("Identity.Application");

            // Opcional: Limpiar otras cookies de Identity si las usas
            await HttpContext.SignOutAsync("Identity.External");
            await HttpContext.SignOutAsync("Identity.TwoFactorUserId");

            return RedirectToPage("/Account/Login");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await HttpContext.SignOutAsync("Identity.Application");
            return RedirectToPage("/Account/Login");
        }
    }
}