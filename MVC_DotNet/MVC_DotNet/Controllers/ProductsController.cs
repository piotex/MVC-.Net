using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_DotNet.Models;

namespace MVC_DotNet.Controllers
{
    public class ProductsController : Controller
    {
        [HttpPost]
        public IActionResult Index(Model_Basket model)
        {
            switch(model.User.role_id)
            {
                case 1: return ProductsAdmin(model);
                case 2: return ProductsClient(model);
                case 3: return ProductsUser(model);
                default:
                    throw new Exception("Not Implemented User Role");
            }
        }
        public ActionResult ProductsUser(Model_Basket model)
        {
            return View("ProductsUser",model);
        }
        public ActionResult ProductsClient(Model_Basket model)
        {
            return View("ProductsClient", model);
        }
        public ActionResult ProductsAdmin(Model_Basket model)
        {
            return View("ProductsAdmin", model);
        }
    }
}
