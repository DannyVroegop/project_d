using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
namespace ADHD_App.Models
{
    public class Person
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Gebruikersnaam is verplicht")]
        [MinLength(8, ErrorMessage = "Gebruikersnaam moet minimaal 8 tekens bevatten")]
        public string Username { get; set; }
        //To do: wachtwoord prive en veilig maken
        [Required(ErrorMessage = "Wachtwoord is verplicht")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Voornaam is verplicht")]
        public string First_Name { get; set; }
        [Required(ErrorMessage = "Achternaam is verplicht")]
        public string Last_Name { get; set; }
        public string Gender { get; set; }
        [Required(ErrorMessage = "Geboortedatum is verplicht")]
        public DateTime Date_of_Birth { get; set; }
        
        [Required(ErrorMessage = "Email-adres is verplicht")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Telefoonnummer is verplicht")]
        public string Phonenumber { get; set; }
        [Required(ErrorMessage = "Groep is verplicht")]
        public string Group { get; set; }
        public List<int> EnergyOfTheDay { get; set; }

        public List<Appointment> Appointments { get; set; }

        public string ProfilePicture { get; set; }
        public string[] unlockedImages { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize<Person>(this);
        }
        public Person()
        {
            EnergyOfTheDay = new List<int>();
        }
    }
}
