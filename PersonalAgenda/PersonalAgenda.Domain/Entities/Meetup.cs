using PersonalAgenda.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalAgenda.Domain.Entities
{
    public class Meetup : IEntity, IErrand
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime DateAndTime { get; set; }

        public string? City { get; set; }

        public string? Location { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
            {
                return false;
            }

            var meetup = obj as Meetup;

            return this.Id == meetup.Id &&
                this.Name == meetup.Name &&
                this.Description == meetup.Description &&
                this.DateAndTime == meetup.DateAndTime &&
                this.City == meetup.City &&
                this.Location == meetup.Location;
        }

        public override int GetHashCode()
        {
            HashCode hashCode = new();
            hashCode.Add(this.Id);
            hashCode.Add(this.Name);
            hashCode.Add(this.Description);
            hashCode.Add(this.DateAndTime);
            hashCode.Add(this.City);
            hashCode.Add(this.Location);
            return hashCode.ToHashCode();
        }
    }
}
