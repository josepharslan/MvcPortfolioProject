﻿using MvcPortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcPortfolioProject.Controllers
{
    public class ProjectController : Controller
    {
        MyPortfolioDbEntities db = new MyPortfolioDbEntities();

        private void CategoryDropDown()
        {
            var categoryList = db.TblCategories.ToList();

            List<SelectListItem> categories = (from x in categoryList
                                               select new SelectListItem
                                               {
                                                   Text = x.Name,
                                                   Value = x.CategoryId.ToString()
                                               }).ToList();
            ViewBag.categories = categories;
        }
        public ActionResult Index()
        {
            var values = db.TblProjects.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateProject()
        {
            CategoryDropDown();
            return View();
        }
        [HttpPost]
        public ActionResult CreateProject(TblProject model)
        {
            CategoryDropDown();

            if (!ModelState.IsValid)
                return View(model);

            db.TblProjects.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteProject(int id)
        {
            var value = db.TblProjects.Find(id);
            db.TblProjects.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateProject(int id)
        {
            CategoryDropDown();
            var value = db.TblProjects.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateProject(TblProject model)
        {
            CategoryDropDown();
            var value = db.TblProjects.Find(model.ProjectId);
            value.Name = model.Name;
            value.ImageUrl = model.ImageUrl;
            value.Description = model.Description;
            value.CategoryId = model.CategoryId;
            value.GithubUrl = model.GithubUrl;
            if (!ModelState.IsValid)
                return View(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}