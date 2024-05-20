using ADHD_App.Models;
using ADHD_App.Services;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ADHD_App.Pages
{
    public class AddAppointmentModel : PageModel
    {
        public JsonFilePeopleService PeopleService;
        public List<Appointment> Appointments { get; private set; }
        public void OnGet()
        {
            Appointments = JsonAppointments.Loadappointments();
        }

        public IActionResult OnPost()
        {
            Appointments = JsonAppointments.Loadappointments();
            string start = Request.Form["Start"];
            string duration = Request.Form["Duration"];
            string name = Request.Form["Name"];
            string type = Request.Form["Type"];
            string description = Request.Form["Description"];
            string energycost = Request.Form["EnergyCost"];
            int id = 0;
            Appointment last = Appointments.LastOrDefault();
            if (last != null) { id = last.ID +1; }
            DateTime startDateTime = DateTime.Parse(start);
            DateTime endDateTime = startDateTime.AddMinutes(Convert.ToInt32(duration));
            int energyCost = Convert.ToInt32(energycost);
            int uid = int.Parse(Request.Cookies["id"]);
            Appointment newappointment = new Appointment(
                id, 
                startDateTime, 
                endDateTime, 
                name, 
                type, 
                description, 
                energyCost, 
                uid);
            Appointments.Add(newappointment);
            JsonAppointments.WriteAll(Appointments);
            return RedirectToPage("/Calendar");
            }
        }
    }
