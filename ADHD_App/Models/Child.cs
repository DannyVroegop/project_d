using System.Text.Json;

namespace ADHD_App.Models
{
    public class Child : Person
    {
        public string Class_Year { get; set; }
        public int Level { get; set; }
        public int XP { get; set; }
        public int Stars { get; set; }
        public List<Item> Inventory { get; set; }
        public Teacher _Teacher { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize<Child>(this);
        }

    }
}
