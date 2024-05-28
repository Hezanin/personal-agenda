using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAgenda.Domain.Dtos
{
    public class ShoppingDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public string? Location { get; set; }

        [Required]
        public decimal Budget { get; set; }
    }
}
