using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VNpage.Data;
using VNpage.Models;

namespace VNpage.Pages.Novelas
{
    public class DetallesModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DetallesModel(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public string NuevoComentario { get; set; } = string.Empty;

        public NovelaVisual? NovelaVisual { get; set; }
        public List<Comentario> Comentarios { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            NovelaVisual = await _context.NovelasVisuales
                .Include(n => n.Comentarios)
                .ThenInclude(c => c.Usuario)
                .FirstOrDefaultAsync(n => n.Id == id);

            if (NovelaVisual == null)
                return NotFound();

            Comentarios = NovelaVisual.Comentarios
                .OrderByDescending(c => c.Fecha)
                .ToList();

            return Page();
        }

        [Authorize]
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (string.IsNullOrWhiteSpace(NuevoComentario))
                return await OnGetAsync(id);

            var user = await _userManager.GetUserAsync(User);

            var comentario = new Comentario
            {
                Contenido = NuevoComentario.Trim(),
                Fecha = DateTime.Now,
                UserId = user?.Id,
                NovelaVisualId = id
            };

            _context.Comentarios.Add(comentario);
            await _context.SaveChangesAsync();

            return RedirectToPage(new { id });
        }
    }
}
