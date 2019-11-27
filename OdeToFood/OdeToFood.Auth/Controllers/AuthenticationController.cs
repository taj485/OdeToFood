using OdeToFood.Auth.Models;
using OdeToFood.Auth.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OdeToFood.Auth.Controllers
{
    public class AuthenticationController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserModel user, string returnUrl)
        {
            if (IsValid(user))
            {
                FormsAuthentication.SetAuthCookie(user.UserName, true);
                return Redirect(returnUrl);
            }
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Restaurants");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserModel user)
        {
            if (ModelState.IsValid)
            {
                using (UserDBContext db = new UserDBContext())
                {
                    db.UserAccount.Add(user);
                    db.SaveChanges();
                    TempData["Register"] = "You have successfully registered your account";
                    FormsAuthentication.SetAuthCookie(user.UserName, true);
                    return RedirectToAction("Index", "Restaurants");
                }
            }
            return View("Register");
        }

        //private bool IsValid(UserModel user)
        //{
        //    return (user.UserName == "test" && user.Password == "test"); 
        //}

        private bool IsValid(UserModel user)
        {
            using(UserDBContext db = new UserDBContext())
            {
                var userAccount = db.UserAccount.Single(x => x.UserName == user.UserName && x.Password == user.Password);
                if (!(userAccount == null))
                {
                    return true;
                }
                return false;
            }
        }
    }
}