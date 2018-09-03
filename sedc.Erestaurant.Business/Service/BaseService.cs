using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sedc.Erestaurant.Data.Repository;

namespace sedc.Erestaurant.Business.Service
{
    public class BaseService<T> : IDisposable where T : BaseRepository
    {
        private T _repository;
        public T Repository => _repository;

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
