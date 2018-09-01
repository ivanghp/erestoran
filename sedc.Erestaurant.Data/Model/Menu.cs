using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sedc.Erestaurant.Data.Model
{
    class Menu
    {
        public int Id { get; set; }
        public MenuType MenuType { get; set; }
        public string RestaurantName { get; set; }
        public List<Category> Category { get; set; }
        //public Category Category { get; set; } (?)
    }
}
