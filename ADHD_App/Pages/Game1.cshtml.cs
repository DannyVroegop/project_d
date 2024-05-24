using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ADHD_App.Pages
{
    public class Game1 : PageModel
    {
        private readonly ILogger<Game1> _logger;

        public Game1(ILogger<Game1> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}