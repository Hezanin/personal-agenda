using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAgenda.Domain.Dtos
{
    public class ShoppingDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string? Location { get; set; }

        public decimal Budget { get; set; }
    }
}
