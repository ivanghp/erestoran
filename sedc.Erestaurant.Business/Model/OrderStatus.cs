using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sedc.Erestaurant.Data.Model
{
    public enum OrderStatus
    {
        Undefined = 0,
        Created = 1,
        InProgress = 2,
        Prepared = 3,
        Delivered = 4
    }
}
