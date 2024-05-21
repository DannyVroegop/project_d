using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
namespace ADHD_App.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Voornaam is verplicht")]
        public string First_Name { get; set; }

        [Required(ErrorMessage = "Achternaam is verplicht")]
        public string Last_Name { get; set; }

        [Required(ErrorMessage = "Geslacht is verplicht")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Geboortedatum is verplicht")]
        [DataType(DataType.Date)]
        public DateTime Date_of_Birth { get; set; }

        [Required(ErrorMessage = "Groep is verplicht")]
        public string Group { get; set; }

        [Required(ErrorMessage = "Email-adres is verplicht")]
        [EmailAddress(ErrorMessage = "Ongeldig email-adres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefoonnummer is verplicht")]
        [Phone(ErrorMessage = "Ongeldig telefoonnummer")]
        public string Phonenumber { get; set; }

        [Required(ErrorMessage = "Gebruikersnaam is verplicht")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Wachtwoord is verplicht")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Wachtwoord moet minimaal 8 tekens lang zijn")]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[!@#$%^&*])[a-zA-Z0-9!@#$%^&*]+$", ErrorMessage = "Wachtwoord moet minimaal één cijfer en één speciaal karakter bevatten")]
        public string Password { get; set; }
        public List<int>? EnergyOfTheDay { get; set; }

        public List<Appointment>? Appointments { get; set; }

        public string? ProfilePicture { get; set; }
        public string[]? unlockedImages { get; set; }

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
