using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Text.Json;
using ADHD_App.Models;
using System.Linq;
using System.Diagnostics;
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

        private string ExerciseFile => Path.Combine(WebHostEnvironment.WebRootPath, "data", "exercises.json");

        public void AddPerson(Person person)
        {
            var people = GetAllPeople();
            person.Id = people.Count;
            person.unlockedImages = new string[] { "images/stickFigure.png", "images/kind.jpg" };
            person.ProfilePicture = "images/kind.jpg";
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

        public List<Exercise> GetAllExercises()
        {
            if (!File.Exists(ExerciseFile))
            {
                return new List<Exercise>();
            }

            var json = File.ReadAllText(ExerciseFile);
            var exercises = JsonSerializer.Deserialize<List<Exercise>>(json);
            return exercises;
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
                personToUpdate.Breaks = updatedPerson.Breaks;

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
        public async void UpdateSubjectProgress(int id, string subject, int newProgressLevel)
        {
            var people = GetAllPeople();
            Person person = people.FirstOrDefault(x => x.Id == id);
            foreach (var progress in person.SubjectProgress)
            {
                if (progress.Subject.Equals(subject, StringComparison.OrdinalIgnoreCase))
                {
                    progress.Progresslevel = newProgressLevel;
                }
            }
            // Thread.Sleep(10000);
            var cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSource.CancelAfter(10000);
            await Task.Delay(2000, cancellationTokenSource.Token);
            SavePeople(people);
        }
    }

    
}
