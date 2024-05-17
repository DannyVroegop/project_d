using System.Text.Json;

namespace ADHD_App.Models
{
    public class AgendaModel
    {
        public List<Appointment> Appointments { get; set; }
        public AgendaModel()
        {
            Appointments = new();
        }
        public void AddAppointment(Appointment app)
        {
            if (app is not null)
                Appointments.Add(app);
        }

        public bool RemoveAppointment(Appointment app)
        {
            if (app is not null)
                return Appointments.Remove(app);
            return false;
        }
        public override string ToString()
        {
            return JsonSerializer.Serialize<AgendaModel>(this);
        }
    }
}
