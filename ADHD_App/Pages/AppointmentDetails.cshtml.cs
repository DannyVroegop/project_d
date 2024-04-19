using ADHD_App.Models;
using ADHD_App.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace ADHD_App.Pages
{
    public class AppointmentDetailsModel : PageModel
    {

        public Appointment app
        {
            get
            {
                List<Appointment> apps = JsonAppointments.Loadappointments();
                foreach (Appointment app in apps)
                {
                    if (app.ID == ID)
                        return app;
                }
                return default;
            }
        }
        public void OnGet()
        {

        }
        [BindProperty(SupportsGet = true)]
        int ID { get; set; }
    }
}
