using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sedc.Erestaurant.Data.Model
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }

        [Required]
        public short Quantity { get; set; }

        //public OrderStatus OrderStatus { get; set; }

        public int ItemId { get; set; }

        public Item Item { get; set; }
    }
}