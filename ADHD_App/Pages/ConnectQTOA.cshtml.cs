using ADHD_App.Models;
using ADHD_App.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace ADHD_App.Pages
{
    public class VragenModel : PageModel
    {
        private readonly JsonFileHandler _json;
        private readonly ILogger<IndexModel> _logger;
        public JsonFilePeopleService PeopleService;

        public Person People { get; private set; }

        public Exercise Exercise { get; private set; }

        public VragenModel(JsonFileHandler json, ILogger<IndexModel> logger,
            JsonFilePeopleService productService)
        {
            _json = json;
            _logger = logger;
            PeopleService = productService;
        }

        [BindProperty]
        public string Vraag { get; set; }


    }

    public class ButtonOrderModel
    {
        public List<string> Order { get; set; }
    }


}
