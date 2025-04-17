using MvcPortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPortfolioProject.Controllers
{
    public class ProfileController : Controller
    {
        MyPortfolioDbEntities db = new MyPortfolioDbEntities();
        public ActionResult Index()
        {
            string email = Session["email"].ToString();
            if (String.IsNullOrEmpty(email))
            {
                return RedirectToAction("Index", "Login");
            }
            var admin = db.TblAdmins.FirstOrDefault(x => x.Email == email);
            return View(admin);
        }
        [HttpPost]
        public ActionResult Index(TblAdmin model)
        {
            string email = Session["email"].ToString();
            var admin = db.TblAdmins.FirstOrDefault(x => x.Email == email);

            if (admin.Password == model.Password)
            {
                if (model.ImageFile != null)
                {
                    var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    var saveLocation = Path.Combine(currentDirectory, "images");

                    if (!Directory.Exists(saveLocation))
                    {
                        Directory.CreateDirectory(saveLocation);
                    }

                    var fileName = Path.GetFileName(model.ImageFile.FileName);
                    var filePath = Path.Combine(saveLocation, fileName);

                    model.ImageFile.SaveAs(filePath);
                    admin.ImageUrl = "/images/" + fileName;
                }

                admin.Name = model.Name;
                admin.Surname = model.Surname;
                admin.Email = model.Email;
                db.SaveChanges();
                Session.Abandon();
                return RedirectToAction("Index", "Login");
            }


            ModelState.AddModelError("", "Girdiğiniz Şifre Hatalı");
            return View(model);
        }
    }
}