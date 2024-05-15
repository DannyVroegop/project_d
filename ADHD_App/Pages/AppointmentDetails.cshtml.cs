using ADHD_App.Models;
using ADHD_App.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace ADHD_App.Pages
{
    public class AppointmentDetailsModel : PageModel
    {
        public DateTime SelectedDate()
        { return DateTime.Now; }
        public void RemoveApp()
        {
            List<Appointment> apps = JsonAppointments.Loadappointments();
            foreach (Appointment appointment in apps)
            {
                if (appointment != null)
                {
                    if (appointment.ID == app.ID)
                    {
                        apps.Remove(appointment);
                        break;
                    }
                }
            }
            JsonAppointments.WriteAll(apps);
        }
        public Appointment app{ get; set; }

        public void OnGet(string ID, bool del = false)
        {
            int id = Convert.ToInt32(ID);
            List<Appointment> apps = JsonAppointments.Loadappointments();
            foreach (Appointment a in apps)
            {
                if (a.ID == id)
                    app = a;
            }
            if(del)
            {
                RemoveApp();
                Response.Redirect("/Calendar");
            }
        }

        [BindProperty(SupportsGet = true)]
        int _ID { get; set; }

        public void OnPost()
        {

        }
    }
}
