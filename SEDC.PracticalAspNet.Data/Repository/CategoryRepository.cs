using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEDC.PracticalAspNet.Data.Model;

namespace SEDC.PracticalAspNet.Data.Repository
{
    public class CategoryRepository : BaseRepository, IRepository<Model.Category>
    {
        public Category Create(Category item)
        {
            DbContext.Categories.Add(item);
            DbContext.SaveChanges();
            return item;
        }

        public void Delete(Category item)
        {
            var dbItem = DbContext.Categories.Single(c =>
                c.Id == item.Id);
            DbContext.Categories.Remove(dbItem);
            DbContext.SaveChanges();
        }

        public Category Get(int id)
        {
            return DbContext.Categories.SingleOrDefault(c => c.Id == id);
        }

        public IList<Category> GetAll()
        {
            return DbContext.Categories.ToList();
        }

        public void Update(Category item)
        {
            var dbItem = DbContext.Categories.Single(c => c.Id == item.Id);
            dbItem.Id = item.Id;
            dbItem.ListItems = item.ListItems;
            dbItem.Menu = item.Menu;
            dbItem.MenuId = item.MenuId;
            dbItem.Name = item.Name;
            DbContext.Entry<Category>(dbItem).State = System.Data.Entity.EntityState.Modified;
            DbContext.SaveChanges();

        }
    }
}
