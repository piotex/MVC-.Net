using LionLibrary.Factory;
using MVC_DotNet_v2.DB;
using MVC_DotNet_v2.Helpers;
using MVC_DotNet_v2.Models.DbModels;
using MVC_DotNet_v2.Models.LogIn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

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
            if (model.Email.IsValid() && model.Pwd.IsValid())
            {
                Request_Factory<DbModel_Users> request_Factory = new Request_Factory<DbModel_Users>();
                string query = string.Format("SELECT role_id from users where email = '{0}' and pwd = '{1}' limit 1;",model.Email,model.Pwd);
                List<DbModel_Users> response = request_Factory.Select(query);
                if (response.Count > 0 && response[0].role_id > 0)
                {
                    Session["role_id"] = response[0].role_id;
                    return View("../Home/Index");
                }
            }
            ModelState.AddModelError("Pwd", "Email or Password is not valid");
            return View(new Model_SignIn());
        }

        public ActionResult Register()
        {
            return View(new Model_Register());
        }
        [HttpPost]
        public ActionResult Register(Model_Register model)
        {
            if (model.Email.IsValid() && model.Pwd.IsValid() && model.Name.IsValid())
            {

                Request_Factory<DbModel_Users> request_Factory = new Request_Factory<DbModel_Users>();
                string query = string.Format("SELECT role_id from users where email = '{0}' limit 1;", model.Email);
                List<DbModel_Users> response = request_Factory.Select(query);
                if (response.Count == 0 || response[0].role_id == 0)
                {
                    DbModel_Users dbModel_Users = new DbModel_Users()
                    {
                        email = model.Email,
                        name = model.Name,
                        pwd = model.Pwd,
                        role_id = -1
                    };
                    request_Factory.Insert(dbModel_Users);

                    MailMessage mm = new MailMessage();
                    mm.From = new MailAddress("pkubon3@gmail.com");
                    mm.To.Add(model.Email);
                    mm.Subject = "Confirm account registration";
                    mm.Body = "http://localhost:50071/ConfirmEmailAddress?key=77&email=" + model.Email;
                    mm.IsBodyHtml = false;
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                    smtp.UseDefaultCredentials = false;
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    ///////////
                    throw new Exception("Zwracam sobie uwage ze musze uzupelnic pole haslo w linijce ponizej w miejscu xxx -> S1-5");
                    ///////////
                    smtp.Credentials = new NetworkCredential("pkubon3@gmail.com", "xxx");
                    smtp.Send(mm);

                    ModelState.AddModelError("Pwd", "Confirm email address!");
                    return View(new Model_Register());
                }
                else
                {
                    ModelState.AddModelError("Pwd", "User already exist");
                    return View(new Model_Register());
                }
            }
            ModelState.AddModelError("Pwd", "Name, Email or Password is not valid");
            return View(new Model_Register());
        }

        public ActionResult LogOut()
        {
            Session["role_id"] = null;
            return View("../Home/Index");
        }
    }
}