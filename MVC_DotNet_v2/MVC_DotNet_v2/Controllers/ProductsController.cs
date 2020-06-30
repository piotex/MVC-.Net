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
            DB.Request_Factory<DbModel_Categories> facx = new DB.Request_Factory<DbModel_Categories>();
            List<DbModel_Categories> listx = facx.Select("select categorie_id, categorie_name from categories order by categorie_id;");
            Dictionary<string, string> categories = new Dictionary<string, string>();
            foreach (var item in listx)
            {
                categories.Add(item.categorie_id.ToString(),item.categorie_name);
            }
            ViewBag.Categories = categories;

            //DB.Request_Factory<DbModel_Products> fac = new DB.Request_Factory<DbModel_Products>();
            //List<DbModelJoin_Products> list = fac.Select("SELECT * from products;");
            DB.Request_Factory<DbModelJoin_Products> fac = new Request_Factory<DbModelJoin_Products>();
            List<DbModelJoin_Products> list = fac.Select("SELECT " +
                                                        "products.id, products._name_, products._price_, products._quantity_, products._type_, categories.categorie_name " +
                                                        "FROM products " +
                                                        "LEFT JOIN categories ON products._type_ = categories.categorie_id " +
                                                        "ORDER BY products.id; ");
            return View(list);
        }
        
        [HttpPost]
        public ActionResult ChangeProduct(DbModelJoin_Products _product)
        {
            if (_product._name_.IsValid())
            {
                DbModel_Products product = new DbModel_Products()
                {
                    id = _product.id,
                    _name_ = _product._name_,
                    _price_ = _product._price_,
                    _quantity_ = _product._quantity_,
                    _type_ = _product._type_
                };


                Request_Factory<DbModel_Products> request_Factory = new Request_Factory<DbModel_Products>();
                if (product.id > 0)
                {
                    string query = string.Format("UPDATE products SET " +
                    "_name_='{0}'," +
                    "_price_={1}," +
                    "_quantity_={2}," +
                    "_type_={3} " +
                    "WHERE id = " +
                    product.id + ";", product._name_, product._price_.ToString().Replace(',','.'), product._quantity_, product._type_);
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