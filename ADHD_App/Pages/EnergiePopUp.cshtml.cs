using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ADHD_App.Pages
{
    public class EnergiePopUp : PageModel
    {
        private readonly ILogger<EnergiePopUp> _logger;
        public string Message { get; set; }
        public Person User { get; set; }

        public EnergiePopUp(ILogger<EnergiePopUp> logger)
        {
            _logger = logger;
        }

        public void OnGet(Person user)
        {
            User = user;
        }


        public IActionResult OnPost(int energyOfTheDay)
        {
            // Get the energy of the day from the submitted form data
            // var energyFormData = Request.Form["energyOfTheDay"];
            User.EnergyOfTheDay.Add(energyOfTheDay);
            // Update the message
            Message = "Bedankt voor het updaten van de energie van de dag!";
            ViewData["Message"] = Message;
            // Redirect to another page after 3 seconds
            // System.Threading.Thread.Sleep(3000);
            return Page();
        }

    }
}