using MvcPortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace MvcPortfolioProject.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        MyPortfolioDbEntities db = new MyPortfolioDbEntities();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult DefaultBanner()
        {
            var values = db.TblBanners.Where(x => x.IsShown == true).ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultExpertise()
        {
            var values = db.TblExpertises.ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultExperience()
        {
            var values = db.TblExperiences.ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultEducation()
        {
            var values = db.TblEducations.ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultProjects()
        {
            var values = db.TblProjects.ToList();
            return PartialView(values);
        }
        [HttpGet]
        public PartialViewResult SendMessage()
        {
            List<TblSocialMedia> socialMedia = db.TblSocialMedias.ToList();
            ViewBag.SocialMedia = socialMedia;

            var value = db.TblContacts.ToList();
            return PartialView(value);
        }
        [HttpPost]
        public ActionResult SendMessage(TblMessage model)
        {
            if (ModelState.IsValid)
            {
                //model.DataSent = DateTime.Now;
                model.IsRead = false;

                db.TblMessages.Add(model);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }
        public PartialViewResult DefaultAbout()
        {
            var values = db.TblAbouts.ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultTestimonial()
        {
            var values = db.TblTestimonials.ToList();
            return PartialView(values);
        }
    }
}