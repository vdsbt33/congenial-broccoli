using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Core.WebAPI.Controllers
{
    public class HomeController : System.Web.Mvc.Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public void ProductPost()
        {
            ProductsController p = new ProductsController();
            p.Insert(new Model.Product.ProductInfo("C# Product", 12.99, "This is an api"));
        }
    }
}
