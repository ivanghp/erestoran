using SEDC.PracticalAspNet.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PracticalAspNet.Data.Repository
{
    public class OrderRepository : BaseRepository, IRepository<Order>//, IRepository<OrderItem>
    {
        public Order Create(Order item)
        {
            throw new NotImplementedException();
            //item.Id = default(int);
            //item. = item.Name.Trim();
            //DbContext.Items.Add(item);
            //int rowsAffected = DbContext.SaveChanges();
            //return item;
        }

        public void Delete(Order item)
        {
            throw new NotImplementedException();
        }

        public Order Get(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Order item)
        {
            throw new NotImplementedException();
        }
    }
}
