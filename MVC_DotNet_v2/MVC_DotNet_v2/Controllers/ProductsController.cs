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
            switch (Session["role_id"])
            {
                case 2:
                    return AdminView();
                case 3:
                    return UserView();
            }
            throw new NotImplementedException();
        }
        public ActionResult UserView()
        {
            DB.Request_Factory<DbModelJoin_Products> fac = new Request_Factory<DbModelJoin_Products>();
            List<DbModelJoin_Products> list = fac.Select("SELECT " +
                                                        "products.id, products._name_, products._price_, products._quantity_, products._type_, categories.categorie_name " +
                                                        "FROM products " +
                                                        "LEFT JOIN categories ON products._type_ = categories.categorie_id " +
                                                        "ORDER BY products.id; ");

            List<DbModel_Products> basked = Session["basket"] as List<DbModel_Products>;
            for (int j = 0; j < list.Count; j++)
            {
                for (int i = 0; i < basked.Count; i++)
                {
                    if (list[j].id == basked[i].id)
                    {
                        list[j]._quantity_ -= basked[i]._quantity_;
                    }
                }
            }
            return View("UserView",list);
        }
        public ActionResult AdminView()
        {
            DB.Request_Factory<DbModel_Categories> facx = new DB.Request_Factory<DbModel_Categories>();
            List<DbModel_Categories> listx = facx.Select("select categorie_id, categorie_name from categories order by categorie_id;");
            Dictionary<string, string> categories = new Dictionary<string, string>();
            foreach (var item in listx)
            {
                categories.Add(item.categorie_id.ToString(), item.categorie_name);
            }
            ViewBag.Categories = categories;

            DB.Request_Factory<DbModelJoin_Products> fac = new Request_Factory<DbModelJoin_Products>();
            List<DbModelJoin_Products> list = fac.Select("SELECT " +
                                                        "products.id, products._name_, products._price_, products._quantity_, products._type_, categories.categorie_name " +
                                                        "FROM products " +
                                                        "LEFT JOIN categories ON products._type_ = categories.categorie_id " +
                                                        "ORDER BY products.id; ");
            return View("AdminView",list);
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
        [HttpPost]
        public ActionResult AddToBasket(string id, string quantity)
        {
            if (id.IsValid() && quantity.IsValid())
            {
                DB.Request_Factory<DbModelJoin_Products> fac = new Request_Factory<DbModelJoin_Products>();
                int count = fac.Select(string.Format("select _quantity_ from products where id = {0};", id)).First()._quantity_;
                int _id = int.Parse(id);
                int _quantity = int.Parse(quantity);
                bool isNotInBasket = true;
                List<DbModel_Products> basket = Session["basket"] as List<DbModel_Products>;
                for (int i = 0; i < basket.Count; i++)
                {
                    if (_id == basket[i].id)
                    {
                        isNotInBasket = false;
                    }
                    if (!isNotInBasket && count - basket[i]._quantity_ >= _quantity)
                    {
                        basket[i]._quantity_ += _quantity;
                        break;
                    }
                }
                if (isNotInBasket && count >=  _quantity)
                {
                    basket.Add(new DbModel_Products() { id = _id, _quantity_ = _quantity });
                }
            }
            return Index();
        }
    }
}

//Session["basket"] = new List<DbModel_Products>();
