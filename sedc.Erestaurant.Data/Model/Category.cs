﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sedc.Erestaurant.Data.Model
{
    class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MenuId { get; set; }
    }
}