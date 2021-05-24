using ECommEntities;
using ECommServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommWeb.Controllers
{
    public class CategoryController : Controller
    {
        CategoriesService categoryService = new CategoriesService();

       //Lists all the categories inside Index view
        [HttpGet]
        public ActionResult Index()
        {
            var categories = categoryService.GetCategories();
        
            //Add view and name it same as action name(right click here)
            return View(categories);
        }

        // Display Create view
        [HttpGet]
        public ActionResult Create()
        {
            //Add view and name it same as action name(right click here)
            return View();
        }

        //Display Index view when user post/submit the data to the server
        [HttpPost]
        public ActionResult Create(Category category)
        {
            //Call the service layer 
            categoryService.SaveCategory(category);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            //Get ID from the database
            var category = categoryService.GetCategory(ID);
            //Add view and name it same as action name(right click here)
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            //Call the service layer 
            categoryService.UpdateCategory(category);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {
            //Get ID from the database
            var category = categoryService.GetCategory(ID);
            //Add view and name it same as action name(right click here)
            return View(category);
        }

        [HttpPost]
        public ActionResult Delete(Category category)
        {
            category = categoryService.GetCategory(category.ID);
            //Call the service layer 
            categoryService.DeleteCategory(category.ID);
            return RedirectToAction("Index");
        }
    }
}