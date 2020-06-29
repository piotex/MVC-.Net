using MVC_DotNet_v2.DB;
using MVC_DotNet_v2.Helpers;
using MVC_DotNet_v2.Models.DbModels;
using MVC_DotNet_v2.Models.LogIn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_DotNet_v2.Controllers
{
    public class ConfirmEmailAddressController : Controller
    {
        // GET: ConfirmEmailAddress
        public ActionResult Index(int key,string email)
        {
            if (email.IsValid() )
            {
                string query = "UPDATE users SET role_id = 3 WHERE role_id = -1 and email = '" + email + "';";
                Request_Factory<DbModel_Users> request_Factory = new Request_Factory<DbModel_Users>();
                request_Factory.Update(query);
                return View("../LogIn/SignIn");
            }
            ModelState.AddModelError("Pwd", "Confirm email address!");
            return View(new Model_Register());
        }
    }
}