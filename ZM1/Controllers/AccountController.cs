using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ZM1.Data;
using ZM1.Models;

namespace ZM1.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserAccount user)
        {
            using (ZmContext db = new ZmContext())
            {
                var userExist = db.Users.SingleOrDefault(u => u.Username == user.Username && u.Password == user.Password);
                if(userExist != null)
                {
                    //second parameter false is for remember me implementation
                    FormsAuthentication.SetAuthCookie(user.Username, false);
                    return RedirectToAction("Index", "Employees");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Username or Password");
                    return View();
                }
            }
        }

        //[HttpPost]
        //public ActionResult Login(User user)
        //{
        //    using (var context = new Data.ZmContext())
        //    {
        //        bool isValid = context.Users.Any(x => x.UserName == user.UserName && x.Password == user.Password);
        //        if(isValid)
        //        {
        //            //second parameter false is for remember me implementation
        //            FormsAuthentication.SetAuthCookie(user.UserName, false);
        //            return RedirectToAction("Index", "Employees");
        //        }
        //        ModelState.AddModelError("", "Invalid Username or Password");
        //        return View();
        //    }

        //}

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserAccount user)
        {
            ZmContext db = new ZmContext();
            var userExist = db.Users.Where(u => u.Username == user.Username).SingleOrDefault();
            
            if (ModelState.IsValid)
            {
                if(userExist == null)
                {
                    db.Users.Add(user);
                    db.SaveChanges();

                    //second parameter false is for remember me implementation
                    FormsAuthentication.SetAuthCookie(user.Username, false);
                    return RedirectToAction("Index", "Employees");
                    //return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.Message = "Username Already Exist";
                    return View();
                }
                //using (ZmContext db = new ZmContext())
                //{
                //    db.Users.Add(user);
                //    db.SaveChanges();
                //}
                //ModelState.Clear();
                //ViewBag.Message = user.FirstName + " " + user.LastName + " successfully registered";
            }
            else
            {
                return View();
            }
        }

        //[HttpPost]
        //public ActionResult SignUp(User user)
        //{
        //    var context = new Data.ZmContext();
        //    var userExist = context.Users.Where(u => u.UserName == user.UserName).SingleOrDefault();
        //    if (ModelState.IsValid)
        //    {
        //        if(userExist == null)
        //        {
        //            context.Users.Add(user);
        //            context.SaveChanges();
        //            return RedirectToAction("Login");
        //        }
        //        else
        //        {
        //            ViewBag.Message = "User with this Email Already Exist";
        //            return View();
        //        }

        //    }
        //    else
        //    {
        //        return View();
        //    }

        //}

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        //Other 
        //public JsonResult IsUserExist(string userName)
        //{
        //    var db = new ZmContext();
        //    bool isExist = db.Users.Where(u=> u.Username == userName).FirstOrDefault() != null;
        //    return Json(!isExist, JsonRequestBehavior.AllowGet);
        //}
    }
}