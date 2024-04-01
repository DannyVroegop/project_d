using System.Text.Json;
using System.Text.Json.Serialization;
namespace ADHD_App.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Username { get; set; }
        //To do: wachtwoord prive en veilig maken
        public string Password { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Gender { get; set; }
        public DateTime Date_of_Birth { get; set; }
        public string Adress { get; set; }

        public string Email { get; set; }
        public string Phonenumber { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize<Person>(this);
        }
    }
}
