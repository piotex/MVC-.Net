using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using MVC_DotNet.Hellpers;
using MVC_DotNet.Models;
using OwlLibrary.Classes.Models.Basic;
using OwlLibrary.Classes.Models.Query.Complete;
using OwlLibrary.Classes.Models.Records;
using OwlLibrary.Enums;
using OwlLibrary.Factory;

namespace MVC_DotNet.Controllers
{
    public class LogInController : Controller
    {
        // GET: LogInController
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult SignIn(Model_Basket model)
        {
            return View(model);
        }
        [HttpPost]
        public ActionResult SignIn_Logic(Model_Basket model)
        {
            Model_Query<Model_User> table = new Model_Select<Model_User>();
            if (model.User.IsValid())
            {
                string query = String.Format("select * from users where email = '{0}' and pwd = '{1}'", model.User.email, model.User.pwd);
                RequestFactory<Model_User>.MakeRequest(query, ref table);
                if (table.Rows.Count > 0)
                {
                    model.Logged = true;
                    model.User = table.Rows[0];

                    model.Basket.Add(new Model_Product() { _name_ = "pizza",_price_=(99.99),_quantity_=100,_type_=12});
                    model.Basket.Add(new Model_Product() { _name_ = "spaghetti",_price_=(199.99),_quantity_=10,_type_=13});
                    model.Basket.Add(new Model_Product() { _name_ = "bred",_price_=(0.99),_quantity_=100500,_type_=1});
                    model.Basket.Add(new Model_Product() { _name_ = "sugar",_price_=(1.99),_quantity_=12000,_type_=2});
                    model.Basket.Add(new Model_Product() { _name_ = "Lays",_price_=(9.99),_quantity_=990,_type_=7 });

                    return View("../Home/Index_Logged", model);
                }
            }
            return View("SignIn", model);
        }



        public ActionResult Register()
        {
            return View(new Model_User());
        }
        [HttpPost]
        public ActionResult Register_Logic(Model_Basket model)
        {
            Model_Query<Model_User> table = new Model_Insert<Model_User>();
            table.Rows.Add(model.User);
            if (model.User.IsValid())
            {
                table.Rows[0].role_id = 3;
                ActionFactory<Model_User>.DoAction(Enum_Action.Insert, ref table);
                return SignIn_Logic(model);
            }
            return View("Register");
        }
    }
}
