using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using VNpage.Data;
using VNpage.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace VNpage.Pages.Novelas_Visuales
{
    public class Detalles : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public Detalles(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;

            NuevoComentario = new Comentario();
        }

        // Modelo principal
        public NovelaVisual NovelaVisual { get; set; }

        // Para escribir comentario nuevo
        public Comentario NuevoComentario { get; set; }

        // Lista de comentarios
        public IList<Comentario> Comentarios { get; set; }

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

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
                return Page();

            NuevoComentario.NovelaVisualId = id;
            NuevoComentario.UserId = _userManager.GetUserId(User);

            _context.Comentarios.Add(NuevoComentario);
            await _context.SaveChangesAsync();

            return RedirectToPage(new { id });
        }
    }
}
