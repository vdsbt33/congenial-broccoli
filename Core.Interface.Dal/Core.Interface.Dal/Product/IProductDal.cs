using System;
using System.Collections.Generic;

using Core.Interface.Model.Product;

namespace Core.Interface.Dal
{
    public interface IProductDal
    {
        List<IProductInfo> GetAll();
        List<IProductInfo> GetBetweenDate(DateTime startDate, DateTime endDate);
        IProductInfo Get(int id);
        bool Insert(IProductInfo product);
        bool Delete(IProductInfo product);
        bool Update(IProductInfo product);
    }
}
