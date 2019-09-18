using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interface.Model.Product;

namespace Core.Model.Product
{
    public class ProductInfo : IProductInfo, IBaseInfo
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime EditedDate { get; set; }

        public ProductInfo(string name, double price, string description)
        {
            this.Name = name;
            this.Price = price;
            this.Description = description;
            this.CreatedDate = DateTime.Now;
            this.EditedDate = DateTime.MinValue;
        }

        public ProductInfo(long id, string name, double price, string description)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.Description = description;
            this.CreatedDate = DateTime.Now;
            this.EditedDate = DateTime.MinValue;
        }

        public ProductInfo(long id, string name, double price, string description, DateTime createdDate, DateTime editedDate)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.Description = description;
            this.CreatedDate = createdDate;
            this.EditedDate = editedDate;
        }
    }
}
