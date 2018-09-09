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
    public class ItemService : BaseService<ItemRepository>, IService<DtoItem>
    {
        public ServiceResult<DtoItem> Add(DtoItem item)
        {
            //Repository.DbContext.Set<>
            var categoryExists = Repository.DbContext.Categories.Any(x => x.Id == item.CategoryId);
            if (!categoryExists)
                return new ServiceResult<DtoItem>
                {
                    Success = false,
                    ErrorMessage = "2404"
                };
            var newItem = new Item
            {
                Id = 0,
                Name = item.Name,
                CategoryId = item.CategoryId,
                Description = item.Description,
                Contents = item.Contents,
                Price = item.Price,
                Availability = item.Availability
            };
            var result = Repository.Create(newItem);
            return new ServiceResult<DtoItem>()
            {
                Item = new DtoItem(result)
            };
        }

        public ServiceResult<DtoItem> Edit(DtoItem item)
        {
            try
            {
                var editItem = Repository.DbContext.Items.Single(i => i.Id == item.Id);
                Repository.Update(editItem);
                //DbContext.SaveChanges();
                return new ServiceResult<DtoItem>
                {
                    Item = item,
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult<DtoItem>
                {
                    Success = false,
                    Exception = ex,
                    ErrorMessage = ex.Message
                };
            }
        }

        public ServiceResult<DtoItem> Load(DtoItem item)
        {
            try
            {
                return new ServiceResult<DtoItem>
                {
                    Item = item,
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult<DtoItem>
                {
                    Success = false,
                    Exception = ex,
                    ErrorMessage = ex.Message
                };
            }
        }

        public ServiceResult<DtoItem> LoadAll()
        {
            try
            {
                var items = Repository.GetAll().ToList();
                var resultList = new List<DtoItem>();
                items.ForEach(i => resultList.Add(new DtoItem(i)));
                return new ServiceResult<DtoItem>()
                {
                    ListItems = resultList,
                    Success = true
                };
            }
            catch (Exception ex)
            {
                //Log exception
                return new ServiceResult<DtoItem>()
                {
                    Success = false,
                    Exception = ex,
                    ErrorMessage = ex.Message
                };
            }
        }

        public ServiceResult<DtoItem> Remove(DtoItem item)
        {
            try
            {
                var delItem = Repository.DbContext.Items.Single(i => i.Id == item.Id);
                Repository.Delete(delItem);
                //DbContext.SaveChanges();
                var categoryList = new List<DtoItem>();
                return new ServiceResult<DtoItem>
                {
                    ListItems = categoryList,
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult<DtoItem>
                {
                    Success = false,
                    Exception = ex,
                    ErrorMessage = ex.Message
                };
            }
        }
    }
}
