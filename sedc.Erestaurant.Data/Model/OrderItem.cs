using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sedc.Erestaurant.Data.Model
{
    class OrderItem
    {
        public int OrderId { get; set; }
        public short Quantity { get; set; }
        public OrderStatus OrderStatus { get; set; }
        //public int ItemId { get; set; } (?)
        public Item Item { get; set; }
    }
}