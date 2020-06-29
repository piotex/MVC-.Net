using MVC_DotNet_v2.DB;
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
        //[HttpPost]
        //public ActionResult Index(DbModel_Products product)
        //{
        //    return View();
        //}
        [HttpPost]
        public ActionResult Index(List<DbModel_Products> product)
        {
            DB.Request_Factory<DbModel_Products> fac = new DB.Request_Factory<DbModel_Products>();
            List<DbModel_Products> list = fac.Select("SELECT * from products;");
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < product.Count; j++)
                {
                    if (list[i].id == product[j].id && 
                        (list[i]._name_ != product[j]._name_ ||
                        list[i]._price_ != product[j]._price_ ||
                        list[i]._quantity_ != product[j]._quantity_ ||
                        list[i]._type_ != product[j]._type_ 
                        ))
                    {
                        string query = string.Format("UPDATE products SET " +
                            "_name_='{0}'," +
                            "_price_={1}," +
                            "_quantity_={2}," +
                            "_type_={3} " +
                            "WHERE id = " + 
                            list[i].id + ";", product[j]._name_, product[j]._price_.ToString().Replace(',','.'), product[j]._quantity_, product[j]._type_);
                        Request_Factory<DbModel_Users> request_Factory = new Request_Factory<DbModel_Users>();
                        request_Factory.Update(query);
                    }
                }
            }
            return View(product);
        }
    }
}