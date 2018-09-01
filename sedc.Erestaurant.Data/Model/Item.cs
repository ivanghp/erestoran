using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sedc.Erestaurant.Data.Model
{
    class Item
    {
        public int Id { get; set; }
        public bool Availability { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Contents { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
    }
}
