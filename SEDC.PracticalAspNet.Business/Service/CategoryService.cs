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
            try
            {
                var editItem = Repository.DbContext.Categories.Single(i => i.Id == item.Id);
                Repository.Update(editItem);
                //DbContext.SaveChanges();
                return new ServiceResult<DtoCategory>
                {
                    Item = item,
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult<DtoCategory>
                {
                    Success = false,
                    Exception = ex,
                    ErrorMessage = ex.Message
                };
            }
        }

        public ServiceResult<DtoCategory> Load(DtoCategory item)
        {
            try
            {
                return new ServiceResult<DtoCategory>
                {
                    Item = item,
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult<DtoCategory>
                {
                    Success = false,
                    Exception = ex,
                    ErrorMessage = ex.Message
                };
            }
        }

        public ServiceResult<DtoCategory> LoadAll()
        {
            try
            {
                var categories = Repository.GetAll().ToList();
                var resultList = new List<DtoCategory>();
                categories.ForEach(c => resultList.Add(new DtoCategory(c)));
                return new ServiceResult<DtoCategory>
                {
                    ListItems = resultList,
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult<DtoCategory>
                {
                    Success = false,
                    Exception = ex,
                    ErrorMessage = ex.Message
                };
            }
        }

        public ServiceResult<DtoCategory> Remove(DtoCategory item)
        {
            try
            {
                var delItem = Repository.DbContext.Categories.Single(i => i.Id == item.Id);
                Repository.Delete(delItem);
                //DbContext.SaveChanges(); 
                var categoryList = new List<DtoCategory>();
                return new ServiceResult<DtoCategory>
                {
                    ListItems = categoryList,
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult<DtoCategory>
                {
                    Success = false,
                    Exception = ex,
                    ErrorMessage = ex.Message
                };
            }
        }
    }
}
