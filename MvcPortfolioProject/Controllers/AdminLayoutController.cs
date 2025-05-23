﻿using Antlr.Runtime;
using MvcPortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPortfolioProject.Controllers
{
    public class AdminLayoutController : Controller
    {
        MyPortfolioDbEntities db = new MyPortfolioDbEntities();
        public ActionResult Layout()
        {
            return View();
        }
        public PartialViewResult AdminLayoutHead()
        {
            return PartialView();
        }
        public PartialViewResult AdminLayoutSpinner()
        {
            return PartialView();
        }
        public PartialViewResult AdminLayoutSidebar()
        {
            var email = Session["email"].ToString();
            var admin = db.TblAdmins.FirstOrDefault(x => x.Email == email);
            ViewBag.nameSurname = admin.Name + " " + admin.Surname;
            ViewBag.image = admin.ImageUrl;

            return PartialView();
        }
        public PartialViewResult AdminLayoutNavbar()
        {
            var email = Session["email"].ToString();
            var admin = db.TblAdmins.FirstOrDefault(x => x.Email == email);
            ViewBag.nameSurname = admin.Name + " " + admin.Surname;
            ViewBag.image = admin.ImageUrl;
            var value = db.TblMessages.Where(x => x.IsRead == false).OrderByDescending(x => x.MessageId).Take(2).ToList();
            return PartialView(value);
        }
        public PartialViewResult AdminLayoutFooter()
        {
            return PartialView();
        }
        public PartialViewResult AdminLayoutScript()
        {
            return PartialView();
        }
    }
}