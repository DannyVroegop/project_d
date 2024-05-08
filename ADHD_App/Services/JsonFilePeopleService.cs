using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Text.Json;
using ADHD_App.Models;
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
            var jsonString = JsonSerializer.Serialize(people, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText(FileName, jsonString);
        }

        public List<Person> GetAllPeople()
        {
            if (!File.Exists(FileName))
            {
                return new List<Person>();
            }

            var json = File.ReadAllText(FileName);
            var people = JsonSerializer.Deserialize<List<Person>>(json);
            return people;
        }

        public Person GetPerson(string username, string password)
        {
            var people = GetAllPeople();
            
            foreach (Person person in people)
            {
                if (person.Username == username && person.Password == password)
                {
                    return person;

                }
            }
            return null;
        }



    }