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

        public VragenModel(JsonFileHandler json)
        {
            _json = json;
        }

        [BindProperty]
        public string Vraag { get; set; }

        public IActionResult OnPost()
        {
            Console.WriteLine("Hello");


            return RedirectToPage("/Home");
        }

        // [HttpPost]
        // public IActionResult SubmitOrder([FromBody] ButtonOrderModel model) //IActionResult
        // {
        // Process the order of button clicks here
        // For example, you can save it to a database or perform some logic
        // Return a response indicating success or failure
        //      return "{\"vraag\":\"1\"}";
        // }
    }

    public class ButtonOrderModel
    {
        public List<string> Order { get; set; }
    }
}
