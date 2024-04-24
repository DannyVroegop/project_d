using System.Diagnostics;
using System.Linq.Expressions;
using System.Text.Json;
using ADHD_App.Models;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System.IO;

namespace ADHD_App.Services
{
    public class JsonFileUserInfoService
    {
        public JsonFileUserInfoService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "extra_userinfo.json"); }
        }

        public Extra_userinfo LoadInfo(Person person)
        {
            try
            {
                using (var jsonFileReader = File.OpenText(JsonFileName))
                {

                    string json = jsonFileReader.ReadToEnd();
                    Debug.WriteLine("JSON read from file:");
                    Debug.WriteLine(json);
                    Extra_userinfo[] users = JsonConvert.DeserializeObject<Extra_userinfo[]>(json);
                    foreach(var user in users)
                    {
                        if (user.Id == person.Id)
                        {
                            Debug.WriteLine("User has been found!");
                            Debug.WriteLine(user);
                            return user;
                        }
                    }
                    return default;

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error during deserialization of Person: ");
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

    }
}
