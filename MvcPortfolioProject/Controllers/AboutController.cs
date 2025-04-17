using MvcPortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPortfolioProject.Controllers
{
    public class AboutController : Controller
    {
        MyPortfolioDbEntities db = new MyPortfolioDbEntities();
        public ActionResult Index()
        {
            var values = db.TblAbouts.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var value = db.TblAbouts.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateAbout(TblAbout model)
        {
            var value = db.TblAbouts.Find(model.AboutId);
            if (ModelState.IsValid)
            {
                if (model.ImageName != null)
                {
                    var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    var saveLocation = currentDirectory + "images";
                    var fileName = Path.Combine(saveLocation, model.ImageName.FileName);
                    model.ImageName.SaveAs(fileName);
                    model.ImageUrl = "/images/" + model.ImageName.FileName;
                }

                if (model.CvName != null)
                {
                    var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    var cvSaveLocation = currentDirectory + "cv";
                    if (!Directory.Exists(cvSaveLocation))
                    {
                        Directory.CreateDirectory(cvSaveLocation);
                    }

                    var cvFileName = Path.Combine(cvSaveLocation, model.CvName.FileName);
                    model.CvName.SaveAs(cvFileName);
                    model.CvUrl = "/cv/" + model.CvName.FileName;
                }

                value.Title = model.Title;
                value.ImageUrl = model.ImageUrl;
                value.Description = model.Description;
                value.CvUrl = model.CvUrl;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}