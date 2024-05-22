using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ADHD_App.Models;
using System.Text.Json;
using System.Linq;
using ADHD_App.Services;

namespace ADHD_App.Pages
{
    public class RegisterModel : PageModel
    {
        private JsonFileHandler _json;

        [BindProperty]
        public Person person {get; set;}
        public RegisterModel(JsonFileHandler json)
        {
            _json = json;
            person = new Person();
        }
        public void OnGet()
        {
            string role = Request.Query["role"];
        }

        public IActionResult OnPost()
        {
            
            if (!ModelState.IsValid)
            {
                return Page();
            }

            
            if (ExistingUsername(person.Username) == true)
            {
                ModelState.AddModelError("person.Username", "Gebruikersnaam bestaat al");
                return Page();
            }

                
            _json.AddPerson(person);
            return RedirectToPage("/Index");
            
        }

        public bool ExistingUsername(string username)
        {
            var usernames = _json.GetAllPeople().Select(x => x.Username);
            if (usernames.Contains(username))
            {
                return true;
            }
            return false;
        }
}
}