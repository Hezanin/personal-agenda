using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAgenda.Domain.Dtos
{
    public class MeetingDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public string? Location { get; set; }

        [Required]
        public DateTime DateAndTime { get; set; }

        public string? City { get; set; }

        [Required]
        public string CompanyName { get; set; }
    }
}
