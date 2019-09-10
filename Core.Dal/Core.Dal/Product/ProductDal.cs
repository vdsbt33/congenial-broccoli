using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Core.Interface.Model.Product;
using Core.Model.Product;
using Core.Interface.Dal;
using Core.Controller;

namespace Core.Dal
{
    public class ProductDal : IProductDal
    {
        public List<IProductInfo> GetAll()
        {
            return Product.GetInstance().GetAll();
        }

        public List<IProductInfo> GetBetweenDate(DateTime startDate, DateTime endDate)
        {
            return Product.GetInstance().GetBetweenDate(startDate, endDate);
        }

        public IProductInfo Get(int id)
        {
            return Product.GetInstance().Get(id);
        }

        public bool Insert(IProductInfo product)
        {
            return Product.GetInstance().Insert(product);
        }

        public bool Delete(IProductInfo product)
        {
            return Product.GetInstance().Delete(product);
        }
        
        public bool Update(IProductInfo product)
        {
            return Product.GetInstance().Update(product);
        }
    }
}
