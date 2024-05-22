using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADHD_App.Models;
using ADHD_App.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ADHD_App.Pages
{
    public class EnergieHistory : PageModel
    {
        private readonly ILogger<EnergieHistory> _logger;
        public JsonFilePeopleService PeopleService;
        public Person User { get; set; }

        public EnergieHistory(ILogger<EnergieHistory> logger, JsonFilePeopleService productService)
        {
            PeopleService = productService;
            _logger = logger;
        }

        public void OnGet()
        {
            int id = int.Parse(Request.Cookies["id"]);
            if (PeopleService.getUserById(id) != null)
                User = PeopleService.getUserById(id);
        }
    }
}