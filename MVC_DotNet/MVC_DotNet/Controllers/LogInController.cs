using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
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
        public ActionResult SignIn_LogIn(Model_User model)
        {
            Model_Query<Model_User> table = new Model_Select<Model_User>();
            string query = String.Format("select id from users where email = '{0}' and pwd = '{1}'",model.email,model.pwd);
            RequestFactory<Model_User>.MakeRequest(query,ref table);
            if (table.Rows.Count>0)
            {
                this.ControllerContext.HttpContext.Response.Cookies.Append("zz","qss");
            }
            return View("SignIn", model);
        }



        public string Register()
        {
            var aa = ControllerContext.HttpContext.Request.Cookies["zz"];
            return aa[0].ToString();
            //return View();
        }


    }
}
