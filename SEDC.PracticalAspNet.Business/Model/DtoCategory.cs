using SEDC.PracticalAspNet.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PracticalAspNet.Business.Model
{
   public class DtoCategory
    {
        public int Id { get; set; }
        public int MenuId { get; set; }
        public string CategoryName { get; set; }
        public DtoCategory()
        {

        }

        public DtoCategory(Category category)
        {
            Id = category.Id;
            CategoryName = category.Name;
            MenuId = category.MenuId;
        }
    }
}
