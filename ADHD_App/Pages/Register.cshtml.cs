using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ADHD_App.Models;
using System.Text.Json;

namespace ADHD_App.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly JsonFilePeopleService _json;

        public RegisterModel(JsonFilePeopleService json)
        {
            _json = json;
        }
        public void OnGet()
        {
            string role = Request.Query["role"];
        }

        public void OnPost()
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
            
    }
}
}

public class JsonFilePeopleService
    {
        public JsonFilePeopleService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string FileName => Path.Combine(WebHostEnvironment.WebRootPath, "data", "people.json");

        public void AddPerson(Person person)
        {
            var people = GetAllPeople();
            people.Add(person);
            var jsonString = JsonSerializer.Serialize(people);
            File.WriteAllText(FileName, jsonString);
        }

        private List<Person> GetAllPeople()
        {
            if (!File.Exists(FileName))
            {
                return new List<Person>();
            }

            var json = File.ReadAllText(FileName);
            var people = JsonSerializer.Deserialize<List<Person>>(json);
            return people;
        }
    }
