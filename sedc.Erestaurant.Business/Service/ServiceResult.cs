using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sedc.Erestaurant.Business.Service
{
    public class ServiceResult<T>
    {
        public T Item { get; set; }
        public IList<T> ListItems { get; set; }
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public Exception Exception { get; set; }
    }
}
