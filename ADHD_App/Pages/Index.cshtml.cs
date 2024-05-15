using ADHD_App.Models;
using ADHD_App.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace ADHD_App.Pages
{
    public class IndexModel : PageModel
    {
        public JsonFileHandler _json;

        public IndexModel(JsonFileHandler json)
        {
            _json = json;
        }

    

        public IActionResult OnPost()
        {
            string username = Request.Form["username"];
            string password = Request.Form["password"];
            Person user =  _json.GetPerson(username, password);
            if (user == null)
            {
                ViewData["Error"] = "Gebruikersnaam en/of wachtwoord is onjuist.";
                return Page();
            }
            else
            {
                return RedirectToPage("/Home", user);
            }
        }
    }
}