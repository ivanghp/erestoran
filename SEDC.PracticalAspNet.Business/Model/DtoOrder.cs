using SEDC.PracticalAspNet.Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PracticalAspNet.Business.Model
{
    public class DtoOrder
    {
        public int Id { get; set; }
        public List<DtoOrderItem> OrderItems { get; set; }
        public double TotalCost { get; set; }
        public int TotalQuantity { get; set; }
        public string Table { get; set; }

        public DtoOrder()
        {

        }

        public DtoOrder(Order order)
        {
            Id = order.Id;
            Table = order.Table;
            TotalCost = order.TotalCost ?? 0;
            TotalQuantity = order.TotalQuantity ?? 0;
            OrderItems = order.ListOrderItems.Select(oi => new DtoOrderItem(oi)).ToList();
        }
    }

    public class DtoOrderItem
    {
        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public short Quantity { get; set; }

        public DtoOrderItem()
        {

        }

        public DtoOrderItem(OrderItem oi)
        {
            OrderId = oi.OrderId;
            ItemId = oi.ItemId;
            Quantity = oi.Quantity;
        }
    }
}
