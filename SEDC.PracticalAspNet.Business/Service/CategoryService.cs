using SEDC.PracticalAspNet.Business.Model;
using SEDC.PracticalAspNet.Data.Model;
using SEDC.PracticalAspNet.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.PracticalAspNet.Business.Service
{
    public class CategoryService : BaseService<CategoryRepository>, IService<DtoCategory>
    {
        public ServiceResult<DtoCategory> Add(DtoCategory item)
        {
            //Repository.DbContext.Set<>
            var menuExists = Repository.DbContext.Menus.Any(x => x.Id == item.MenuId);
            if (!menuExists)
                return new ServiceResult<DtoCategory>
                {
                    Success = false,
                    ErrorMessage = "2404"
                };
            var newCategory = new Category
            {
                Id = 0,
                Name = item.CategoryName,
                MenuId = item.MenuId
            };
            var result = Repository.Create(newCategory);
            return new ServiceResult<DtoCategory>()
            {
                Item = new DtoCategory(result)
            };
        }

        public ServiceResult<DtoCategory> Edit(DtoCategory item)
        {
            throw new NotImplementedException();
        }

        public ServiceResult<DtoCategory> Load(DtoCategory item)
        {
            throw new NotImplementedException();
        }

        public ServiceResult<DtoCategory> LoadAll()
        {
            throw new NotImplementedException();
        }

        public ServiceResult<DtoCategory> Remove(DtoCategory item)
        {
            throw new NotImplementedException();
        }
    }
}
