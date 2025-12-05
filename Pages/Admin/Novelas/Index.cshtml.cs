using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using VNpage.Models;

namespace VNpage.Pages.Admin.Novelas
{
    [Authorize(Policy = "AdminOnly")]
    public class IndexModel : PageModel
    {
        public List<Resena> Novelas { get; set; } = new();
        private readonly string novelasPath = Path.Combine("wwwroot", "data", "novelas.json");

        public void OnGet()
        {
            Load();
        }

        public IActionResult OnPostDelete(int id)
        {
            Load();
            var toRemove = Novelas.FirstOrDefault(n => n.Id == id);
            if (toRemove != null)
            {
                Novelas.Remove(toRemove);
                System.IO.File.WriteAllText(novelasPath, JsonSerializer.Serialize(Novelas, new JsonSerializerOptions { WriteIndented = true }));
            }

            return RedirectToPage();
        }

        private void Load()
        {
            if (System.IO.File.Exists(novelasPath))
            {
                var j = System.IO.File.ReadAllText(novelasPath);
                var list = JsonSerializer.Deserialize<List<Resena>>(j);
                if (list != null) Novelas = list;
            }
        }
    }
}