using Microsoft.AspNetCore.Mvc.RazorPages;
using VNpage.Data;
using VNpage.Models;

namespace VNpage.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public List<NovelaVisual> Novelas { get; set; } = new();

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Novelas = _context.NovelasVisuales.ToList();
        }
    }
}
