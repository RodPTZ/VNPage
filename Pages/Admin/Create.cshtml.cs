using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VNpage.Data;
using VNpage.Models;
using Microsoft.AspNetCore.Authorization;

namespace VNpage.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        [BindProperty]
        public NovelaVisual Novela { get; set; } = new();

        [BindProperty]
        public IFormFile? ImagenArchivo { get; set; }

        public CreateModel(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            if (ImagenArchivo != null)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImagenArchivo.FileName);
                var filePath = Path.Combine(_env.WebRootPath, "Images/novelas", fileName);

                using (var stream = System.IO.File.Create(filePath))
                {
                    await ImagenArchivo.CopyToAsync(stream);
                }

                Novela.ImagenRuta = "/Images/novelas/" + fileName;
            }

            _context.NovelasVisuales.Add(Novela);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
