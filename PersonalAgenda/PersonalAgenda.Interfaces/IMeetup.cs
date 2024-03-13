using System;

namespace PersonalAgenda.Interfaces
{
    public interface IMeetup
    {
        public string? City { get; set; }

        public DateTime DateAndTime { get; set; }

        public string Name { get; set; }
    }
}