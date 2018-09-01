using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sedc.Erestaurant.Data.Model
{
    class Order
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; }
        public string Comment { get; set; }
        public byte TableNumber { get; set; }
        public DateTime Created { get; set; }
        public List<Item> Items { get; set; }
    }
}
