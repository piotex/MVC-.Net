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


        public ActionResult SignIn()
        {
            return View(new Model_User());
        }
        [HttpPost]
        public ActionResult SignIn_Logic(Model_User model)
        {
            Model_Query<Model_User> table = new Model_Select<Model_User>();
            if (model.IsValid())
            {
                string query = String.Format("select * from users where email = '{0}' and pwd = '{1}'", model.email, model.pwd);
                RequestFactory<Model_User>.MakeRequest(query, ref table);
                if (table.Rows.Count > 0)
                {
                    return View("../Home/Index", model);
                }
            }
            return View("SignIn", model);
        }



        public ActionResult Register()
        {
            return View(new Model_User());
        }
        [HttpPost]
        public ActionResult Register_Logic(Model_User model)
        {
            Model_Query<Model_User> table = new Model_Insert<Model_User>();
            table.Rows.Add(model);
            if (model.IsValid())
            {
                table.Rows[0].role_id = 3;
                ActionFactory<Model_User>.DoAction(Enum_Action.Insert, ref table);
                return SignIn_Logic(model);
            }
            return View("Register", model);
        }
    }
}
