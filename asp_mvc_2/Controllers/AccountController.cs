using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace asp_mvc_2.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
    }

    public ActionResult LogIn()
    {
        return View();
    }
    [HttpPost]
    public ActionResult LogIn(UserLoginView ULV, string returnUrl)
    {
        if (ModelState.IsValid)
        {
            UserManager UM = new UserManager();
            string password = UM.GetUserPassword(ULV.LoginName);
            if (string.IsNullOrEmpty(password))
                ModelState.AddModelError("", "The user login or password provide is incorrect.");
else {
                if (ULV.Password.Equals(password))
                {
                    FormsAuthentication.SetAuthCookie(ULV.LoginName, false);
                    return RedirectToAction("Welcome", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "The password provided is incorrect.");
                }
            }
        }
        // If we got this far, something failed, redisplay form
        return View(ULV);
    }
}