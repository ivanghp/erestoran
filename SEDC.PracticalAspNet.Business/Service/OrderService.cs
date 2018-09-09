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
    public class OrderService : BaseService<OrderRepository>, IService<DtoOrder>
    {
        public ServiceResult<DtoOrder> Add(DtoOrder order)
        {
            using (var transaction = DbContext.Database.BeginTransaction())
            {
                try
                {
                    var newOrder = new Order
                    {
                        Id = 0,
                        StatusId = (byte)OrderStatus.Created,
                        Table = order.Table,
                        WhenCreated = DateTime.UtcNow
                    };
                    DbContext.Orders.Add(newOrder);
                    DbContext.SaveChanges();
                    DbContext.OrderItems.AddRange(order.OrderItems.Select(o => new OrderItem
                    {
                        OrderItemId = 0,
                        ItemId = o.ItemId,
                        OrderId = o.OrderId,
                        Quantity = o.Quantity
                    }));
                    transaction.Commit();
                    return new ServiceResult<DtoOrder>
                    {
                        Success = true,
                        Item = new DtoOrder(newOrder)
                    };
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return new ServiceResult<DtoOrder>
                    {
                        Success = false,
                        Exception = ex,
                        ErrorMessage = "an exception occured"
                    };

                }
            }
        }

        public ServiceResult<DtoOrder> Edit(DtoOrder item)
        {
            try
            {
                var editItem = Repository.DbContext.Orders.Single(i => i.Id == item.Id);
                Repository.Update(editItem);
                //DbContext.SaveChanges();
                return new ServiceResult<DtoOrder>
                {
                    Item = item,
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult<DtoOrder>
                {
                    Success = false,
                    Exception = ex,
                    ErrorMessage = ex.Message
                };
            }
        }

        public ServiceResult<DtoOrder> Load(DtoOrder item)
        {
            try
            {
                return new ServiceResult<DtoOrder>
                {
                    Item = item,
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult<DtoOrder>
                {
                    Success = false,
                    Exception = ex,
                    ErrorMessage = ex.Message
                };
            }
        }

        public ServiceResult<DtoOrder> LoadAll()
        {
            try
            {
                var orders = Repository.GetAll().ToList();
                var resultList = new List<DtoOrder>();
                orders.ForEach(o => resultList.Add(new DtoOrder(o)));
                return new ServiceResult<DtoOrder>()
                {
                    ListItems = resultList,
                    Success = true
                };
            }
            catch (Exception ex)
            {
                //Log exception
                return new ServiceResult<DtoOrder>()
                {
                    Success = false,
                    Exception = ex,
                    ErrorMessage = ex.Message
                };
            }
        }

        public ServiceResult<DtoOrder> Remove(DtoOrder item)
        {
            try
            {
                var delItem = Repository.DbContext.Orders.Single(i => i.Id == item.Id);
                Repository.Delete(delItem);
                //DbContext.SaveChanges();
                var categoryList = new List<DtoOrder>();
                return new ServiceResult<DtoOrder>
                {
                    ListItems = categoryList,
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult<DtoOrder>
                {
                    Success = false,
                    Exception = ex,
                    ErrorMessage = ex.Message
                };
            }
        }
    }
}
