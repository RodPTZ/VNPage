/*using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VNpage.Data;
using VNpage.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using BCrypt.Net;

namespace VNpage.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        [BindProperty] public string Nombre { get; set; } = "";
        [BindProperty] public string Contraseña { get; set; } = "";
        public string Mensaje { get; set; } = "";

        public LoginModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Nombre == Nombre);

            if (usuario == null || !BCrypt.Net.BCrypt.Verify(Contraseña, usuario.PasswordHash))
            {
                Mensaje = "Error: tus credenciales son tan falsas como un final feliz en Doki Doki.";
                return Page();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuario.Nombre)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            TempData["MensajeSistema"] = $"Bienvenido, {usuario.Nombre}. El panel te esperaba...";
            return RedirectToPage("/Admin/Index");
        }
    }
}
*/