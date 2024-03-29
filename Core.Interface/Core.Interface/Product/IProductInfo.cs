﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interface.Product
{
    public interface IProductInfo
    {
        long Id { get; set; }
        string Name { get; set; }
        double Price { get; set; }
        string Description { get; set; }
    }
}
