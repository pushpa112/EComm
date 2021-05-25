﻿using ECommServices;
using ECommWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommWeb.Controllers
{
    public class HomeController : Controller
    {
        CategoriesService categoryService = new CategoriesService();
        HomeViewModels model = new HomeViewModels();
        public ActionResult Index()
        {
            model.Categories = categoryService.GetCategories();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}