using Final.Models;
using Final.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Final.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(UserViewModel user)
        {
            RegisterService service = new RegisterService();
            bool result = service.Register(user);
            if (result)
            {
                return RedirectToAction("Index", "Login");

            }
            ViewData["existingUser"] = true;
            return View();
        }
    }
}