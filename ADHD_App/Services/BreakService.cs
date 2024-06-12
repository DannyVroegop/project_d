using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADHD_App.Services;
using ADHD_App.Models;

namespace ADHD_App.Services
{
    public class BreakService
    {
        public JsonFileHandler json;
        public BreakService(JsonFileHandler jsonhandler)
        {
            json = jsonhandler;
        }

        //Verwijdert de pauze gegevens van voorgaande dagen
        public void ClearBreaks(Person person)
        {
            Dictionary<DateTime, DateTime> breaks = person.Breaks;
            DateTime today = DateTime.Today;

            person.Breaks = person.Breaks.Where(x => x.Key.Date == today).ToDictionary(x => x.Key, x => x.Value);
            json.UpdatePerson(person);
        }
        
        //Checkt of het kind max pauzes op een dag heeft bereikt
        public bool ReachedMaxBreaks(Person person)
        {
            ClearBreaks(person);
            if (person.Breaks.Count >= 3 && BreakOngoing(person) == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Checkt of het kind afgelopen uur pauze heeft genomen (behalve evt pauze dat nog bezig is)
        public bool BreakInLastHour(Person person)
        {
            DateTime now = DateTime.Now;
            DateTime oneHourAgo = now.AddHours(-1);
            ClearBreaks(person);

            foreach (var _break in person.Breaks)
            {
                if (_break.Value >= oneHourAgo && BreakOngoing(person) == false)
                {
                    return true;
                }
            }
            return false;
        }

        //Checkt of pauze nog bezig is
        public bool BreakOngoing(Person person)
        {
            DateTime now = DateTime.Now;
            DateTime today = DateTime.Today;
            ClearBreaks(person);
    
            foreach (var _break in person.Breaks)
            {
                if (now >= _break.Key && now <= _break.Value)
                {
                    return true;
                }
            }
            return false;
        }

        //Start een pauze
        public void CreateBreak(Person person)
        {
            ClearBreaks(person);
            DateTime start = DateTime.Now;
            DateTime end = start.AddMinutes(15);
            person.Breaks[start] = end;
            json.UpdatePerson(person);
        }

        //Checkt of energieniveau laag is => pauze
        public bool EnergyLow(Person person)
        {
            if (person.EnergyOfTheDay != null && person.EnergyOfTheDay.Count > 0)
            {
                var currentEnergy = person.EnergyOfTheDay[person.EnergyOfTheDay.Count - 1];
                if (currentEnergy <= 30)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            return false; 
        }

        public List<string> BreakMessages(Person person)
        {
            List<string> errors = new List<string>();

            if (!EnergyLow(person))
            {
                errors.Add("Je energieniveau is te hoog om een pauze te nemen.");
            }

            if (ReachedMaxBreaks(person))
            {
                errors.Add("Je hebt al 3 keer pauze gehad vandaag. Dat is het limiet.");
            }

            if (BreakInLastHour(person))
            {
                errors.Add("Je moet een uur wachten tot de volgende pauze.");
            }

            return errors;
        }

        public int SecondsLeft(Person person)
        {
            if (person == null || person.Breaks == null || person.Breaks.Count == 0)
            {
                return 0;
            }

            DateTime start = DateTime.Now;
            DateTime end = DateTime.Now.AddMinutes(15);
            foreach (var _break in person.Breaks)
            {
                start = _break.Key;
                end = _break.Value;
            }

            // Check if the last break is currently in progress
            if (start <= DateTime.Now && end >= DateTime.Now)
            {
                // Calculate the difference in minutes between the start of the last break and the current moment
                int difference = (int)(end - DateTime.Now).TotalSeconds;
                return difference;
            }

            return 0;
        }
    }
}