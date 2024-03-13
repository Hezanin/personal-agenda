using PersonalAgenda.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace PersonalAgenda.Domain.Entities
{
    public class Meeting : IErrand, IMeeting
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string? Location { get; set; }

        public DateTime DateAndTime { get; set; }

        public string? City { get; set; }

        public string CompanyName { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
            {
                return false;
            }    

            var meeting = obj as Meeting;

            return this.Id == meeting.Id &&
                this.Name == meeting.Name &&
                this.Description == meeting.Description &&
                this.Location == meeting.Location &&
                this.DateAndTime == meeting.DateAndTime &&
                this.City == meeting.City &&
                this.CompanyName == meeting.CompanyName;
        }

        public override int GetHashCode()
        {
            HashCode hashCode = new();
            hashCode.Add(this.Id);
            hashCode.Add(this.Name);
            hashCode.Add(this.Description);
            hashCode.Add(this.Location);
            hashCode.Add(this.DateAndTime);
            hashCode.Add(this.City);
            hashCode.Add(this.CompanyName);
            return hashCode.ToHashCode();
        }
    }
}
