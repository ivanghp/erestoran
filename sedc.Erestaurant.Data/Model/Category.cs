using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace sedc.Erestaurant.Data.Model
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        public int MenuId { get; set; }

        public Menu Menu { get; set; }

        public List<Item> ListItems { get; set; }
    }
}
