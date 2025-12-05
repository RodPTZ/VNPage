using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VNpage.Data;
using VNpage.Models;

namespace VNpage.Pages.Admin
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        [BindProperty]
        public NovelaVisual Novela { get; set; } = new();

        [BindProperty]
        public IFormFile? ImagenArchivo { get; set; }

        public EditModel(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult OnGet(int id)
        {
            var novela = _context.NovelasVisuales.Find(id);
            if (novela == null)
                return RedirectToPage("Index");

            Novela = novela;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var existente = _context.NovelasVisuales.Find(Novela.Id);
            if (existente == null)
                return RedirectToPage("Index");

            existente.Titulo = Novela.Titulo;
            existente.Desarrollador = Novela.Desarrollador;
            existente.Descripcion = Novela.Descripcion;
            existente.FechaLanzamiento = Novela.FechaLanzamiento;
            existente.Genero = Novela.Genero;

            if (ImagenArchivo != null)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImagenArchivo.FileName);
                var filePath = Path.Combine(_env.WebRootPath, "images/novelas", fileName);
                using (var stream = System.IO.File.Create(filePath))
                {
                    await ImagenArchivo.CopyToAsync(stream);
                }

                existente.ImagenRuta = "/images/novelas/" + fileName;
            }

            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
