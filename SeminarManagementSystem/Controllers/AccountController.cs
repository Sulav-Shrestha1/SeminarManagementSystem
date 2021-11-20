using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ManagementSystem.DB;
using ManagementSystem.Model;
using System.Web.Security;

namespace SeminarManagementSystem.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        // GET: Account
        
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(AccountModel model)
        {
            using (var context = new SeminarDBEntities())
            {
                bool isvalid = context.Account.Any(x => x.Username == model.Username && x.Password == model.Password);

                if (isvalid)
                {
                    FormsAuthentication.SetAuthCookie(model.Username, false);
                    TempData["msg"] = "<script>alert('Login Successful, Hello'+  Username+');</script>";
                    return RedirectToAction("GetAllAttendee", "Home" );
                }
                return View();
            }  
        }
        
        public ActionResult Signup()
        {
            var availability = new List<string>() { "True", "False" };
            ViewBag.Availability = availability;

            return View();
        }
        [HttpPost]
        public ActionResult Signup(Account model)
        {
            var availability = new List<string>() { "True", "False" };
            ViewBag.Availability = availability;

            using (var context = new SeminarDBEntities())
            {
                if(context.Account.Any(x => x.Username == model.Username))
                {
                    FormsAuthentication.SetAuthCookie(model.Username, false);
                    ViewBag.DuplicateMessage = "Username Already Exists";
                    return View("Signup");
                }
                else if(context.Account.Any(x => x.Email == model.Email))
                {
                    FormsAuthentication.SetAuthCookie(model.Username, false);
                    ViewBag.DuplicateMessage = "Email Already Exists";
                    return View("Signup");
                }
                try
                {
                    context.Account.Add(model);
                    context.SaveChanges();
                    TempData["msg"] = "<script>alert('Account Created Successfully');</script>";
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return RedirectToAction("Signup");
                }

            }

             return RedirectToAction("Login");
        }
    }
}