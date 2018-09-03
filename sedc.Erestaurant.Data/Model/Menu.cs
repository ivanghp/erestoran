using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sedc.Erestaurant.Data.Model
{
    public class Menu
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public byte TypeId { get; set; }

        //public MenuType MenuType { get; set; } (redundant, using "TypeId" instead of enum)

        [Required]
        [MaxLength(150)]
        public string RestaurantName { get; set; }

        public List<Category> ListCategories { get; set; }
        //public Category Category { get; set; } (?)
    }
}
