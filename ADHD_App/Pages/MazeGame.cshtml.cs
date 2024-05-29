using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ADHD_App.Pages
{
    public class MazeGame : PageModel
    {
        private readonly ILogger<MazeGame> _logger;

        public MazeGame(ILogger<MazeGame> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}