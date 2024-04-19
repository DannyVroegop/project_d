using ADHD_App.Models;
using System.Text.Json;
namespace ADHD_App.Services
{
    public static class JsonAppointments
    {
        static string path = System.IO.Path.GetFullPath(System.IO.Path.Combine(Environment.CurrentDirectory, @"wwwroot/data/Appointments.json"));
        public static List<Appointment> Loadappointments()
        {
            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<Appointment>>(json);
        }
        public static string AppToString(Appointment app)
        {
            return JsonSerializer.Serialize(app);
        }
    }
}
