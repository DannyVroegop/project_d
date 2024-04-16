using Microsoft.AspNetCore.Hosting;

namespace ADHD_App.Services
{
    public class JsonFilePeopleService
    {
        public JsonFilePeopleService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string FileName => Path.Combine(WebHostEnvironment.WebRootPath, "data", "people.json");


    }
}
