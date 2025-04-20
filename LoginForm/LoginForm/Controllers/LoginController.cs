using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginForm.Models;

namespace LoginForm.Controllers
{
    public class LoginController : Controller
    {
        LoginDBEntities db = new LoginDBEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(User s)
        {
            if (ModelState.IsValid == true)
            {
                var creditals = db.Users.Where(model => model.username == s.username && model.password == s.password).FirstOrDefault();
                if (creditals == null)
                {
                    ViewBag.ErrorMessage = "Login Failed!";
                    return View();
                }
                else
                {
                    Session["username"] = s.username;
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
        public ActionResult logout()
        {
            Session.Abandon();
            return RedirectToAction("Index","Home");
        }

        public ActionResult Reset()
        {
            ModelState.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}