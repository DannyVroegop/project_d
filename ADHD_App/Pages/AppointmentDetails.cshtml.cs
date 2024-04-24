using ADHD_App.Models;
using ADHD_App.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace ADHD_App.Pages
{
    public class AppointmentDetailsModel : PageModel
    {
        public void RemoveApp()
        {
            List<Appointment> apps = JsonAppointments.Loadappointments();
            foreach (Appointment appointment in apps)
            {
                if (appointment != null)
                {
                    if (appointment.ID == app.ID)
                        apps.Remove(appointment);
                }
            }
            JsonAppointments.WriteAll(apps);
        }
        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            RemoveApp();
            Response.Redirect("/Calendar.cshtml/OnGet");
        }

        public Appointment app{ get; set; }

        public void OnGet(string ID)
        {
            int id = Convert.ToInt32(ID);
            List<Appointment> apps = JsonAppointments.Loadappointments();
            foreach (Appointment a in apps)
            {
                if (a.ID == id)
                    app = a;
            }
        }

        [BindProperty(SupportsGet = true)]
        int _ID { get; set; }

        public void OnPost()
        {

            RemoveApp();
        }
    }
}
