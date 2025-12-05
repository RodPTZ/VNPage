using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VNpage.Data;
using VNpage.Models;

namespace VNpage.Pages.Admin
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public NovelaVisual Novela { get; set; } = new();

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int id)
        {
            var novela = _context.NovelasVisuales.Find(id);
            if (novela == null)
                return RedirectToPage("Index");

            Novela = novela;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var novela = _context.NovelasVisuales.Find(id);
            if (novela != null)
            {
                _context.NovelasVisuales.Remove(novela);
                await _context.SaveChangesAsync();
            }

            // Sarcasmo post-eliminación
            TempData["MensajeSistema"] = $"Has eliminado '{novela?.Titulo}'. Espero que valiera la pena.";
            return RedirectToPage("Index");
        }
    }
}
