using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Threading.Tasks;
using ADHD_App.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ADHD_App.Services;
using ADHD_App.Models;
using System.Collections.ObjectModel;

namespace ADHD_App.Pages
{
    public class EnergiePopUp : PageModel
    {
        private readonly ILogger<EnergiePopUp> _logger;
        public JsonFilePeopleService PeopleService;
        public string Message { get; set; }
        public Person User { get; set; }
        private JsonFileHandler _json;

        public EnergiePopUp(ILogger<EnergiePopUp> logger, JsonFilePeopleService productService, JsonFileHandler json)
        {
            PeopleService = productService;
            _logger = logger;
            _json = json;
        }

        public void OnGet()
        {
            int id = int.Parse(Request.Cookies["id"]);
            if (PeopleService.getUserById(id) != null)
                User = PeopleService.getUserById(id);
        }


        public IActionResult OnPost(int energyOfTheDay)
        {
            int id = int.Parse(Request.Cookies["id"]);
            if (PeopleService.getUserById(id) != null)
                User = PeopleService.getUserById(id);
            // Get the energy of the day from the submitted form data
            // var energyFormData = Request.Form["energyOfTheDay"];
            User.EnergyOfTheDay.Add(energyOfTheDay);
            _json.UpdatePerson(User);
            // Update the message
            Message = "Bedankt voor het updaten van de energie van de dag!";
            ViewData["Message"] = Message;
            // Redirect to another page after 3 seconds
            // System.Threading.Thread.Sleep(3000);
            return RedirectToPage("/Home");
        }

    }
}