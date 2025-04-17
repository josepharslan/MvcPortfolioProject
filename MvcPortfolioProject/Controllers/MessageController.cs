using MvcPortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPortfolioProject.Controllers
{
    public class MessageController : Controller
    {
        MyPortfolioDbEntities db = new MyPortfolioDbEntities();
        public ActionResult Index()
        {
            var values = db.TblMessages.Where(x => x.IsRead == false).ToList();
            return View(values);
        }
        public ActionResult MessageDetail(int id)
        {
            var value = db.TblMessages.Find(id);
            value.IsRead = true;
            db.SaveChanges();
            return View(value);
        }
        [HttpPost]
        public ActionResult MarkMessageRead(int id)
        {
            var value = db.TblMessages.Find(id);
            value.IsRead = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult ReadMessages()
        {
            var value = db.TblMessages.Where(x => x.IsRead == true).ToList();
            return View(value);
        }
        public ActionResult DeleteMessage(int id)
        {
            var value = db.TblMessages.Find(id);
            db.TblMessages.Remove(value);
            db.SaveChanges();
            return RedirectToAction("ReadMessages");
        }
    }
}