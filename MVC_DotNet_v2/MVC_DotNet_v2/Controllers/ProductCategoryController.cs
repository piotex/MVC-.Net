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
    public class ProductCategoryController : Controller
    {
        // GET: ProductCategory
        public ActionResult Index()
        {
            DB.Request_Factory<DbModel_Categories> fac = new DB.Request_Factory<DbModel_Categories>();
            List<DbModel_Categories> list = fac.Select("SELECT * from categories  order by categorie_id;");
            return View(list);
        }

        [HttpPost]
        public ActionResult ChangeCategory(DbModel_Categories category)
        {
            if (category.categorie_name.IsValid())
            {
                Request_Factory<DbModel_Categories> request_Factory = new Request_Factory<DbModel_Categories>();
                if (category.id > 0)
                {
                    string query = string.Format("UPDATE categories SET " +
                    "categorie_id={0}," +
                    "categorie_name='{1}' " +
                    "WHERE id = " +
                    category.id + ";", category.categorie_id, category.categorie_name);
                    request_Factory.Update(query);
                }
                if (category.id == -1)
                {
                    category.id = 0;
                    request_Factory.Insert(category);
                }

            }
            return RedirectToAction("Index");
        }
    }
}