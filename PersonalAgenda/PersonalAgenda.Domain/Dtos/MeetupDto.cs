using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAgenda.Domain.Dtos
{
    public class MeetupDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime DateAndTime { get; set; }

        public string? City { get; set; }

        public string? Location { get; set; }
    }
}
