using System.Text.Json;

namespace ADHD_App.Models
{
    public class Teacher : Person
    {
        public List<Child> Children { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize<Teacher>(this);
        }
    }
}
