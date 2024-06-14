using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ADHD_App.Pages
{
    public class PixelartGame : PageModel
    {
        private readonly ILogger<PixelartGame> _logger;

        public PixelartGame(ILogger<PixelartGame> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }

    public class Pixel
    {
        public string Colorname { get; set; }
        public string Colorcode { get; set; }
        public (int num1, int num2, int result) multiplication {get; set;}
        public Pixel(string colorname)
        {
            Colorname = colorname;
        }

        public void GenerateMultiplication()
        {
            
        }

    }
}