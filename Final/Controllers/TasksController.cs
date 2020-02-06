using Final.Models;
using Final.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Final.Controllers
{
    public class TasksController : Controller
    {
        private TasksService service;
        public TasksController()
        {
            this.service = new TasksService();
        }

        // GET: Tasks
        public ActionResult Index()
        {
            List<Tasks> tasks = this.service.GetTasks();
            return View(tasks);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Tasks tasks)
        {
            if (this.service.Create(tasks))
            {
                return RedirectToAction("Index");
            }
            ViewData["error"] = true;
            return View();
        }
        public ActionResult Edit(int Id)
        {
            Tasks t = this.service.GetTaskByID(Id);
            if (t == null)
            {
                return Redirect("404");
            }
            return View(t);
        }
        [HttpPost]
        public ActionResult Edit(Tasks tasks)
        {
            bool result = this.service.Update(tasks);
            if (result == true)
            {
                return RedirectToAction("Index");
            }
            ViewData["error"] = true;
            return View();
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (this.service.Delete(id))
            {
                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");
        }
    }
}