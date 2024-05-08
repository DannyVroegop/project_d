using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ADHD_App.Pages
{
    public class Inlogpagina : PageModel
    {
        private readonly ILogger<Inlogpagina> _logger;

        public Inlogpagina(ILogger<Inlogpagina> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            
        }
    }
}