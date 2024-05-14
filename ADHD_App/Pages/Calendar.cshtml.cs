using ADHD_App.Models;
using ADHD_App.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace ADHD_App.Pages
{
    public class CalendarModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public JsonFilePeopleService PeopleService;
        public List<Appointment> Appointments { get; private set; }
        public CalendarModel()
        {
        }
        public DateTime SelectedDate {  get; set; }
        public int I {  get; set; }
        public void OnGet(int i = 0)
        {
            I = i;
            Appointments = JsonAppointments.Loadappointments();
            SelectedDate = DateTime.Now.AddDays(i);
        }
        public string ToJson(Appointment app)
        {
            return JsonAppointments.AppToString(app);
        }
        public void OnPost() 
        {

        }
    }
}
