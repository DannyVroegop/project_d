using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using  ADHD_App.Models;

namespace ADHD_App.Pages
{
    public class CalendarModel : PageModel
    {

        public Appointment OnGet()
        {
            AgendaModel a = new AgendaModel();
            for (int i = 0; i < 10; i+=2) 
            {
                Appointment appointment = new Appointment(i, DateTime.Now.AddHours(1+i), DateTime.Now.AddHours(2+i), "Homework", "school", "Make your homework");
                a.AddAppointment(appointment);
            }
            Appointment appointment1 = new Appointment(0, DateTime.Now.AddHours(1), DateTime.Now.AddHours(2), "Homework", "school", "Make your homework");
            return appointment1;
        }
    }
}
