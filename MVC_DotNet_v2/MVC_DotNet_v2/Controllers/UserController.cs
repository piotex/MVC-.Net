using MVC_DotNet_v2.DB;
using MVC_DotNet_v2.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_DotNet_v2.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Basket()
        {
            List<DbModel_Products> basket = Session["basket"] as List<DbModel_Products>;
            if (basket.Count > 0)
            {
                string query = "select id, _name_, _price_ from products where ";
                for (int i = 0; i < basket.Count-1; i++)
                {
                    query += " id="+basket[i].id+" or ";
                }
                query += " id=" + basket[basket.Count-1].id;

                DB.Request_Factory<DbModel_Products> fac = new Request_Factory<DbModel_Products>();
                List<DbModel_Products> info = fac.Select(query);
                for (int i = 0; i < basket.Count; i++)
                {
                    for (int j = 0; j < info.Count; j++)
                    {
                        if (basket[i].id == info[j].id)
                        {
                            basket[i]._name_ = info[j]._name_;
                            basket[i]._price_ = info[j]._price_;
                        }
                    }
                }
            }
            return View("Basket",basket);
        }
        [HttpPost]
        public ActionResult ChangeBasket(DbModel_Products model)
        {
            List<DbModel_Products> basket = Session["basket"] as List<DbModel_Products>;    // dodac sprawdzenie czy nie chce wiecej niz jest na magazynie
            for (int i = 0; i < basket.Count; i++)
            {
                if (basket[i].id == model.id)
                {
                    basket[i]._quantity_ = model._quantity_;
                    break;
                }
            }
            Session["basket"] = basket;
            return Basket();
        }

        
    }
}