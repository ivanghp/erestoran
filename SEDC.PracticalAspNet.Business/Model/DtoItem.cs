using SEDC.PracticalAspNet.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PracticalAspNet.Business.Model
{
    public class DtoItem
    {
        public DtoItem()
        {

        }

        public DtoItem(Item item)
        {
            Id = item.Id;
            Name = item.Name;
            CategoryId = item.CategoryId;
            Description = item.Description;
            Contents = item.Contents;
            Price = item.Price;
            Availability = item.Availability;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Contents { get; set; }

        public double Price { get; set; }

        public bool Availability { get; set; }

        public int CategoryId { get; set; }
    }
}
