using ADHD_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ADHD_App.Pages
{
    public class IndexModel : PageModel
    {

        private readonly JsonFilePeopleService _json;

        public IndexModel(JsonFilePeopleService json)
        {
            _json = json;
        }

        public void OnGet()
        {

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