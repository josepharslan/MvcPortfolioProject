﻿using MvcPortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcPortfolioProject.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        MyPortfolioDbEntities db = new MyPortfolioDbEntities();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TblAdmin model)
        {
            var value = db.TblAdmins.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);
            if (value == null)
            {
                ModelState.AddModelError("", "Email veya şifre hatalı");
                return View();
            }
            FormsAuthentication.SetAuthCookie(value.Email, false);
            Session["email"] = value.Email;
            return RedirectToAction("Index", "Category");
        }
    }
}