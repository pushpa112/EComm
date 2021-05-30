using ECommEntities;
using ECommServices;
using ECommWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommWeb.Controllers
{
    public class ProductController : Controller
    {
        ProductsService productsService = new ProductsService();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductTable(string search)
        {
            //get list of products
            var products = productsService.GetProducts();

            //Check if search field is nont empty and check if there is any match with the product list
            if (string.IsNullOrEmpty(search) == false)
            {
                products = products.Where(p => p.Name != null && p.Name.ToLower().Contains(search.ToLower())).ToList();
            }
                       
            return PartialView(products);
        }

        [HttpGet]
        public ActionResult Create()
        {
            CategoriesService categoryService = new CategoriesService();
            var categories = categoryService.GetCategories();
            return PartialView(categories);
        }

        [HttpPost]
        public ActionResult Create(NewCategoryViewModel model)
        {
            CategoriesService categoriesService = new CategoriesService();
            var newProduct = new Product();
            newProduct.Name = model.Name;
            newProduct.Description = model.Description;
            newProduct.Price = model.Price;
          //newProduct.CategoryID = model.CategoryID;
            newProduct.Category = categoriesService.GetCategory(model.CategoryID);
            productsService.SaveProduct(newProduct);
            return RedirectToAction("ProductTable");
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var product = productsService.GetProduct(ID);
            return PartialView(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            productsService.UpdateProduct(product);
            return RedirectToAction("ProductTable");
        }

        [HttpPost]
        public ActionResult Delete(int ID)
        {
            productsService.DeleteProduct(ID);
            return RedirectToAction("ProductTable");
        }
    }
}