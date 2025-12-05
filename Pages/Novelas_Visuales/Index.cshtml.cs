using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VNpage.Data;
using VNpage.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VNpage.Pages.Novelas_Visuales
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // Lista de novelas visuales que se mostrará en el .cshtml
        public IList<NovelaVisual> Novelas { get; set; } = new List<NovelaVisual>();

        public async Task OnGetAsync()
        {
            Novelas = await _context.NovelasVisuales
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
