﻿using System.Text.Json;

namespace ADHD_App.Models
{
    public class Appointment
    {
        public int ID {  get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public int EnergyCost { get; set; }
        public int UID { get; set; }

        public Appointment(int id, DateTime start, DateTime end,string name, string type, string description, int energyCost = 0, int uid = 0)
        {
            ID = id;
            Start = start;
            End = end;
            Name = name;
            Type = type;
            Description = description;
            EnergyCost = energyCost;
            UID = uid;
        }
        public override string ToString()
        {
            return JsonSerializer.Serialize<Appointment>(this);
        }
    }
}
