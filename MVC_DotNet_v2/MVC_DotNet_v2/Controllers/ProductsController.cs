using MVC_DotNet_v2.DB;
using MVC_DotNet_v2.Helpers;
using MVC_DotNet_v2.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_DotNet_v2.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            DB.Request_Factory<DbModel_Products> fac = new DB.Request_Factory<DbModel_Products>();
            List<DbModel_Products> list = fac.Select("SELECT * from products;");
            return View(list);
        }
        
        [HttpPost]
        public ActionResult ChangeProduct(DbModel_Products product)
        {
            if (product._name_.IsValid())
            {
                Request_Factory<DbModel_Products> request_Factory = new Request_Factory<DbModel_Products>();
                if (product.id > 0)
                {
                    string query = string.Format("UPDATE products SET " +
                    "_name_='{0}'," +
                    "_price_={1}," +
                    "_quantity_={2}," +
                    "_type_={3} " +
                    "WHERE id = " +
                    product.id + ";", product._name_, product._price_, product._quantity_, product._type_);
                    request_Factory.Update(query);
                }
                if (product.id == -1)
                {
                    product.id = 0;
                    request_Factory.Insert(product);
                }

            }
            return RedirectToAction("Index");
        }
    }
}