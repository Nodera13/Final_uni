using Final.Models;
using Final.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Final.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(UserViewModel user)
        {
            LoginService service = new LoginService();

            User u = service.LoginAttempt(user);
            if (u == null)
            {
                ViewData["wrongUser"] = true;
                return View();
            }
            Session["user"] = u;

            return RedirectToAction("Index", "Home");
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }
    }
}