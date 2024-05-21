using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Text.Json;
using ADHD_App.Models;
// using Newtonsoft.Json;

namespace ADHD_App.Services
{
    public class JsonFileHandler
    {
        public JsonFileHandler(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string FileName => Path.Combine(WebHostEnvironment.WebRootPath, "data", "people.json");

        public void AddPerson(Person person)
        {
            var people = GetAllPeople();
            person.Id = people.Count;
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

        public void UpdatePerson(Person updatedPerson)
        {
            var people = GetAllPeople();
            var personToUpdate = people.FirstOrDefault(p => p.Id == updatedPerson.Id);
            if (personToUpdate != null)
            {
                personToUpdate.EnergyOfTheDay = updatedPerson.EnergyOfTheDay;
                personToUpdate.Last_Name = updatedPerson.Last_Name;
                personToUpdate.First_Name = updatedPerson.First_Name;
                personToUpdate.Username = updatedPerson.Username;
                personToUpdate.Password = updatedPerson.Password;
                personToUpdate.Email = updatedPerson.Email;
                personToUpdate.Phonenumber = updatedPerson.Phonenumber;
                personToUpdate.Date_of_Birth = updatedPerson.Date_of_Birth;
                personToUpdate.Group = updatedPerson.Group;

                SavePeople(people);
            }
        }

        private void SavePeople(List<Person> people)
        {
            var jsonString = JsonSerializer.Serialize(people, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText(FileName, jsonString);
        }
    }
}