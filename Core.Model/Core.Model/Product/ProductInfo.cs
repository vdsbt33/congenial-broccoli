using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interface.Product;

namespace Core.Model.Product
{
    public class ProductInfo : IProductInfo
    {
        public long Id { get; set; }
        public string Name { get;set; }
        public double Price { get;set; }
        public string Description { get;set; }

        public ProductInfo(string name, double price, string description)
        {
            this.Name = name;
            this.Price = price;
            this.Description = description;
        }

        public ProductInfo(long id, string name, double price, string description)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.Description = description;
        }
    }
}
