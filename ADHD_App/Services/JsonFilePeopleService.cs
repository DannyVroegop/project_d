using System.Diagnostics;
using System.Linq.Expressions;
using System.Text.Json;
using ADHD_App.Models;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System.IO;


namespace ADHD_App.Services
{
    public class JsonFilePeopleService
    {
        public JsonFilePeopleService(IWebHostEnvironment webHostEnvironment) 
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "people.json"); }
        }

        public Person[] GetProducts()
        {
            try
            {
                using (var jsonFileReader = File.OpenText(JsonFileName))
                {

                    string json = jsonFileReader.ReadToEnd();
                    Debug.WriteLine("JSON read from file:");
                    Debug.WriteLine(json);
                    Person[] person = JsonConvert.DeserializeObject<Person[]>(json);
                    return person;

                }
            } catch (Exception ex)
            {
                Debug.WriteLine("Error during deserialization of Person: ");
                Debug.WriteLine(ex.Message);
                return null;
            }
        }
        public Person? getUserById(int id)
        {
            try
            {
                using (var jsonFileReader = File.OpenText(JsonFileName))
                {

                    string json = jsonFileReader.ReadToEnd();
                    Debug.WriteLine("JSON read from file:");
                    Debug.WriteLine(json);
                    Person[] person = JsonConvert.DeserializeObject<Person[]>(json);
                    foreach(Person p in person)
                    {
                        if (p.Id == id)
                           return p;
                    }
                    return default;

                }
            } catch (Exception ex)
            {
                Debug.WriteLine("Error during deserialization of Person: ");
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public List<QuestionAnswerPair> GetQuestions(string subject)
        {
            try
            {
                using (var jsonFileReader = File.OpenText(JsonFileName))
                {

                    string json = jsonFileReader.ReadToEnd();
                    Console.WriteLine("JSON read from file:");
                    Console.WriteLine(json);
                    Exercise[] exercises = JsonConvert.DeserializeObject<Exercise[]>(json);
                    foreach (Exercise e in exercises)
                    {
                        if (e.Subject == subject)
                            Console.WriteLine(e.QuestionsAndAnswers[0].Question);
                            return e.QuestionsAndAnswers;
                    }
                    return null;

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error during deserialization of Exercise: ");
                Debug.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
