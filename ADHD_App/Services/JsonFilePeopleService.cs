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
    }
}
