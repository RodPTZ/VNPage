using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace VisualNovelReviews.Pages
{
    public class IndexModel : PageModel
    {
        public List<Reseña> Reseñas { get; set; } = new();

        public void OnGet()
        {
            // Simulación de datos (en un futuro podrías conectar una base de datos o API)
            Reseñas = new List<Reseña>
            {
                new Reseña
                {
                    Título = "Milk Inside A Bag of milk...",
                    Descripción = "la historia de una chica con problemas de salud mental y ansiedad social que lucha por realizar una tarea cotidiana como comprar leche."
                },
                new Reseña
                {
                    Título = "Milk Outside A Bag of milk...",
                    Descripción = "Secuela de «Milk inside a bag of milk inside a bag of milk» . Sumérgete de nuevo en un mundo demencial y bizarro y ayuda a la niña a ser un poco más feliz."
                },
                new Reseña
                {
                    Título = "HatofulBoyfriend",
                    Descripción = "Recorre los pasillos y encuentra el amor entre clases como estudiante de segundo año en la mejor escuela secundaria para palomas del mundo."
                }
            };
        }

        public class Reseña
        {
            public string Título { get; set; } = "";
            public string Descripción { get; set; } = "";
        }
    }
}