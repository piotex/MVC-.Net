using MVC_DotNet_v2.Models.LogIn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_DotNet_v2.Controllers
{
    public class LogInController : Controller
    {
        // GET: LogIn
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SignIn()
        {
            //Session["role_id"] = 1;
            return View(new Model_SignIn());
        }
        [HttpPost]
        public ActionResult SignIn(Model_SignIn model)
        {
            Session["role_id"] = 1;
            return View("../Home/Index");
        }


        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Model_Register model)
        {
            Session["role_id"] = 1;
            return View();
        }
    }
}