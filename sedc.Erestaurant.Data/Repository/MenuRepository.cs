using sedc.Erestaurant.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sedc.Erestaurant.Data.Repository
{
    public class MenuRepository : BaseRepository, IRepository<Menu>
    {
        public Menu Create(Menu item)
        {
            DbContext.Menus.Add(item);
            DbContext.SaveChanges();
            return item;
        }

        public void Delete(Menu item)
        {
            var dbItem = DbContext.Menus.Single(m => m.Id == item.Id);
            DbContext.Menus.Remove(dbItem);
            DbContext.SaveChanges();
        }

        public Menu Get(int id)
        {
            return DbContext.Menus.SingleOrDefault(m => m.Id == id);
        }

        public IList<Menu> GetAll()
        {
            return DbContext.Menus.ToList();
        }

        public void Update(Menu item)
        {
            var dbItem = DbContext.Menus.Single(m => m.Id == item.Id);
            dbItem.TypeId = item.TypeId;
            dbItem.RestaurantName = item.RestaurantName;
            DbContext.Entry<Menu>(dbItem).State = System.Data.Entity.EntityState.Modified;
            DbContext.SaveChanges();
        }
    }
}
