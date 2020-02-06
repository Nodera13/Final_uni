using Final.DataBase;
using Final.Filters;
using Final.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Final.Controllers
{
    [FilterPrivilege]
    public class ShopController : Controller
    {
        private Entity db;

        public ShopController()
        {
            this.db = new Entity();
        }
        public ActionResult Index()
        {
            List<Items> items = this.db.Items.ToList();
            return View(items);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Items Item)
        {
            this.db.Items.Add(Item);
            int result = this.db.SaveChanges();
            if (result == 1)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            Items i = this.db.Items.Where(x => x.Id == id).FirstOrDefault();
            if (i == null)
            {
                return Redirect("404");
            }
            return View(i);
        }
        [HttpPost]
        public ActionResult Edit(Items item)
        {
            Items i = this.db.Items.Where(x => x.Id == item.Id).FirstOrDefault();
            if (i == null)
            {
                return Redirect("404");
            }
            i.Name = item.Name;
            i.Price = item.Price;
            i.Quantity = item.Quantity;
            this.db.Items.Add(item);
            this.db.Entry(i).State = EntityState.Modified;
            int result = this.db.SaveChanges();
            if (result >= 1)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Items i = this.db.Items.Where(x => x.Id == id).FirstOrDefault();
            if (i == null)
            {
                return Redirect("404");
            }
            this.db.Items.Add(i);
            this.db.Entry(i).State = EntityState.Deleted;
            int result = this.db.SaveChanges();
            if (result == 1)
            {
                return RedirectToAction("Index");
            }
            //todo show msg error
            return RedirectToAction("Index");
        }
    }
}

