using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interface.Model.Product
{
    public interface IProductInfo
    {
        long Id { get; set; }
        string Name { get; set; }
        double Price { get; set; }
        string Description { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime EditedDate { get; set; }
    }
}
