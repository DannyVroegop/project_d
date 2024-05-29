using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ADHD_App.Pages
{
    public class Break : PageModel
    {
        private readonly ILogger<Break> _logger;

        public Break(ILogger<Break> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}