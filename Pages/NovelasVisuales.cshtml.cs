using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace VNpage.Pages
{
    public class NovelasVisuales : PageModel
    {


        private readonly ILogger<NovelasVisuales> _logger;

        public NovelasVisuales(ILogger<NovelasVisuales> logger)
        {
            _logger = logger;
        }

        public string ?EstadoContenido { get; set; }
        public void OnGet(string Estado)
        {
            EstadoContenido = string.IsNullOrEmpty(Estado)  ? "indice" : Estado;
        }

    }
}