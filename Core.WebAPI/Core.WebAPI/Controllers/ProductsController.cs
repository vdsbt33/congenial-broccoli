using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Core.Interface.Model.Product;
using Core.Model.Product;
using Core.Controller;

namespace Core.WebAPI.Controllers
{
    public class ProductsController : ApiController
    {
        // GET api/values
        public List<IProductInfo> GetAll()
        {
            return Product.GetInstance().GetAll();
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
