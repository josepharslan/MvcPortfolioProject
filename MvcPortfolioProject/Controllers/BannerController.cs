using MvcPortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPortfolioProject.Controllers
{
    public class BannerController : Controller
    {
        MyPortfolioDbEntities db = new MyPortfolioDbEntities();
        public ActionResult Index()
        {
            var value = db.TblBanners.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult CreateBanner()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateBanner(TblBanner model)
        {
            db.TblBanners.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteBanner(int id)
        {
            var value = db.TblBanners.Find(id);
            db.TblBanners.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateBanner(int id)
        {
            var value = db.TblBanners.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateBanner(TblBanner model)
        {
            var value = db.TblBanners.Find(model.BannerId);
            value.Title = model.Title;
            value.Description = model.Description;
            value.IsShown = model.IsShown;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}