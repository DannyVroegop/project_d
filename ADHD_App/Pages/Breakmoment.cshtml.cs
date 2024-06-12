using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ADHD_App.Pages
{
    public class Breakmoment : PageModel
    {
        private readonly ILogger<Breakmoment> _logger;

        public Breakmoment(ILogger<Breakmoment> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}