using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ADHD_App.Pages
{
    public class Snakegame : PageModel
    {
        private readonly ILogger<Snakegame> _logger;

        public Snakegame(ILogger<Snakegame> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}