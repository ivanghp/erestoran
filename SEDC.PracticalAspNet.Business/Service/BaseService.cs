using System;
using SEDC.PracticalAspNet.Data;
using SEDC.PracticalAspNet.Data.Repository;

namespace SEDC.PracticalAspNet.Business.Service
{
    public class BaseService<T> : IDisposable
        where T : BaseRepository
    {
        private T _repository;

        public T Repository => _repository;

        protected RestaurantContext DbContext => _repository.DbContext;

        public BaseService()
        {
            _repository = Activator.CreateInstance<T>();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
