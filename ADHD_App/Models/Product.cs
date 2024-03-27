using System.Text.Json;
using System.Text.Json.Serialization;

namespace ADHD_App.Models
{
    public class Product
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("id")]
        public int Id { get; set; }

        public Product(string name, string description, int id)
        {
            Name = name;
            Description = description;
            Id = id; 
        }

        public override string ToString() => JsonSerializer.Serialize<Product>(this);
    }
}
