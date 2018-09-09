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
            
            item.Id = default(int);
            item.Table = item.Table.Trim();
            DbContext.Orders.Add(item);
            int rowsaffected = DbContext.SaveChanges();
            return item;
        }

        public void Delete(Order item)
        {
            var dbOrder = DbContext.Orders.Single(o =>
                o.Id == item.Id);
            DbContext.Orders.Remove(dbOrder);
            DbContext.SaveChanges();
        }

        public Order Get(int id)
        {
            return DbContext.Orders.SingleOrDefault(o => o.Id == id);
        }

        public IList<Order> GetAll()
        {
            return DbContext.Orders.ToList();
        }

        public void Update(Order item)
        {
            var dbOrder = DbContext.Orders.Single(o => o.Id == item.Id);
            dbOrder.Table = item.Table;
            dbOrder.StatusId = item.StatusId;
            dbOrder.WhenCreated = item.WhenCreated;
            dbOrder.ListOrderItems = item.ListOrderItems;
            DbContext.Entry<Order>(dbOrder).State = System.Data.Entity.EntityState.Modified;
            DbContext.SaveChanges();
        }
    }
}
