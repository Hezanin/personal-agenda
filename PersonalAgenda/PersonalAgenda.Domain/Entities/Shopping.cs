using PersonalAgenda.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalAgenda.Domain.Entities
{
    public class Shopping : IErrand, IShopping
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public string? Location { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Budget { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
            {
                return false;
            }

            var shopping = obj as Shopping;

            return this.Id == shopping.Id &&
                this.Name == shopping.Name &&
                this.Description == shopping.Description &&
                this.Location == shopping.Location &&
                this.Budget == shopping.Budget;
        }

        public override int GetHashCode() 
        {
            HashCode hashCode = new();
            hashCode.Add(this.Id);
            hashCode.Add(this.Name);
            hashCode.Add(this.Description);
            hashCode.Add(this.Location);
            hashCode.Add(this.Budget);
            return hashCode.ToHashCode();
        }
    }
}
