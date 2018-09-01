using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sedc.Erestaurant.Data.Model
{
    class Order
    {
        [Key]
        public int Id { get; set; }
        //public OrderStatus Status { get; set; } nepotrebno, zameneto so dolunavedenoto
        [Required]
        public byte StatusId { get; set; }

        public string Comment { get; set; }

        [Required]
        [MaxLength(3)]
        public string Table { get; set; }

        //public byte TableNumber { get; set; } nepotrebno, zameneto so gorenavedenoto

        [Required]
        public DateTime WhenCreated { get; set; }

        //public List<Item> Items { get; set; }

        public List<OrderItem> ListOrderItems { get; set; }

        public int? TotalQuantity => ListOrderItems?.Sum(loi => loi.Quantity);

        public double? TotalCost => ListOrderItems?.Sum(loi => loi.Quantity * loi.Item.Price);
    }
}
