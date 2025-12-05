using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace VNpage.Pages.Shared
{
    public class _AdminLayout : PageModel
    {
        private readonly ILogger<_AdminLayout> _logger;

        public _AdminLayout(ILogger<_AdminLayout> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}