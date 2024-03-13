using System;

namespace PersonalAgenda.Interfaces
{
    public interface IMeeting
    {
        public string? City { get; set; }

        public string CompanyName { get; set; }

        public DateTime DateAndTime { get; set; }

        public string Name { get; set; }
    }
}