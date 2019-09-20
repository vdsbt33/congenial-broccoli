using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Core.Interface.Model.Product;
using Core.Model.Product;
using Core.Controller;
using Newtonsoft.Json.Serialization;
using System.Web.Http.Results;

namespace Core.WebAPI.Controllers
{
    public class ProductsController : ApiController
    {
        // GET api/products
        [Route("api/products/get")]
        [HttpGet]
        public List<IProductInfo> GetAll()
        {
            return Product.GetInstance().GetAll();
        }

        // GET api/products/5
        [Route("api/products/get")]
        [HttpGet]
        public List<IProductInfo> GetBetweenDate([FromUri]string startDate, [FromUri] string endDate)
        {
            return Product.GetInstance().GetBetweenDate(startDate, endDate);
        }

        // POST api/products
        [Route("api/products/post")]
        [HttpPost]
        public bool Insert(ProductInfo product)
        {
            return Product.GetInstance().Insert(product);
        }

        // PUT api/products/5
        [Route("api/products/put")]
        [HttpPut]
        public bool Put(ProductInfo product)
        {
            return Product.GetInstance().Update(product);
        }

        // DELETE api/products/5
        [Route("api/products/delete")]
        [HttpDelete]
        public bool Delete(int id)
        {
            return Product.GetInstance().Delete(id);
        }
    }
}
