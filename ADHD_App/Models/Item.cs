using System.Text.Json;

namespace ADHD_App.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Path { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize<Item>(this);
        }
    }
}
