using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using BusinessLayer.ValidationRules;
using DataAccesLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.Results;

namespace BlogProject.Controllers
{
    public class CategoryController : Controller
    {
       
        CategoryManager categoryManager = new CategoryManager(new GenericRepository<Category>(new Context()));
        Context context = new Context();
        CategoryValidator categoryvalidator = new CategoryValidator();

        [AllowAnonymous]
        public PartialViewResult BlogDetailCategories()
        {
            var CountCategories = from x in context.Categories
                                  join b in context.Blogs
                                  on x.CategoryID equals b.CategoryID
                                  group b by x.CategoryName into g
                                  select new
                                  {
                                      CategoryID = g.Key,
                                      blogsayisi = g.Count()
                                  };

            var list = categoryManager.List();
            return PartialView(list);
        }

        public ActionResult AdminCategoryList()
        {
            var list = categoryManager.List();
     
            return View(list);
        }

        public ActionResult AdminBlogListByCategory()
        {
            var list=categoryManager.List();
            return View();
        }
        [HttpGet]
        public ActionResult AdminCategoryAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminCategoryAdd(Category category)
        {
            ValidationResult results=categoryvalidator.Validate(category);
            if (results.IsValid)
            {
                categoryManager.Add(category);
                return RedirectToAction("AdminCategoryList");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult CategoryEdit(int id)
        {
            Category category = categoryManager.GetByID(id);
            return View(category);
        }
        [HttpPost]
        public ActionResult CategoryEdit(Category category)
        {
            ValidationResult results = categoryvalidator.Validate(category);
            if (results.IsValid)
            {
                categoryManager.Update(category);
                return RedirectToAction("AdminCategoryList");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(category);

        }
        public ActionResult categoryEditStatus(int id)
        {
            categoryManager.CategoryEditStatus(id);
            return RedirectToAction("AdminCategoryList");
        }
        public ActionResult CategoryDelete(int id)
        {
            categoryManager.DeleteCategory(id);
            return RedirectToAction("AdminCategoryList");
        }


    }
}