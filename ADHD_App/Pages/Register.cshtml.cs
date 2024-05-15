using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ADHD_App.Models;
using System.Text.Json;
using ADHD_App.Services;

namespace ADHD_App.Pages
{
    public class RegisterModel : PageModel
    {
        private JsonFileHandler _json;

        public RegisterModel(JsonFileHandler json)
        {
            _json = json;
        }
        public void OnGet()
        {
            string role = Request.Query["role"];
        }

        public IActionResult OnPost()
        {
            
            string firstName = Request.Form["FirstName"];
            string lastName = Request.Form["LastName"];
            string gender = Request.Form["Gender"];
            string email = Request.Form["Email"];
            string phone = Request.Form["Phone"];
            string username = Request.Form["Username"];
            string password = Request.Form["Password"];
            
            Person newperson = new Person
            {
                First_Name = firstName,
                Last_Name = lastName,
                Gender = gender,
                Email = email,
                Phonenumber = phone,
                Username = username,
                Password = password
            };
            _json.AddPerson(newperson);
            return RedirectToPage("/Index");
            
    }
}
}
