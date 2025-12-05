using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;

namespace VNpage.Pages
{
    public class LogoutModel : PageModel
    {
        public async Task OnGetAsync()
        {
            await HttpContext.SignOutAsync();
        }
    }
}
