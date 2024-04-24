﻿using ADHD_App.Models;
using ADHD_App.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace ADHD_App.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public JsonFilePeopleService PeopleService;
        public Person[] Products { get; private set; }

        public IndexModel(ILogger<IndexModel> logger,
            JsonFilePeopleService productService)
        {
            _logger = logger;
            PeopleService = productService;
        }

        public void OnGet()
        {
            if (PeopleService.GetProducts() != null)
            {
                Products = PeopleService.GetProducts();
            }
        }
    }
}