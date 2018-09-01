using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sedc.Erestaurant.Data.Model
{
    class Item
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public bool Availability { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [MaxLength(2000)]
        public string Contents { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
