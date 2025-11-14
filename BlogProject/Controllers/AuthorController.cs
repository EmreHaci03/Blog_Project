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
using PagedList;

namespace BlogProject.Controllers
{
   
    public class AuthorController : Controller
    {

        BlogManager blogManager = new BlogManager(new GenericRepository<Blog>(new Context()));

        AuthorManager authorManager = new AuthorManager(new GenericRepository<Author>(new Context()));
        AuthorValidator authorValidator=new AuthorValidator();

        [AllowAnonymous]
        public PartialViewResult AuthorAbout(int id)
        {
            var authorabout=blogManager.GetBlogById(id);
            return PartialView(authorabout);
        }
        [AllowAnonymous]
        public PartialViewResult AuthorPost(int id)
        {
            var authorpost=blogManager.List().Where(x=>x.BlogID== id).Select(z=>z.AuthorID).FirstOrDefault();
            var authorblogs=blogManager.GetBlogByAuthor(authorpost);
            return PartialView(authorblogs);
        }
        
        public ActionResult AuthorList()
        {
            var authorLists = authorManager.List();
            return View(authorLists);
        }

        [HttpGet]
        public ActionResult AddAuthor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAuthor(Author author)
        {
            ValidationResult results = authorValidator.Validate(author);
            if (results.IsValid)
            {
                authorManager.Add(author);
                return RedirectToAction("AuthorList");
            }
            else
            {
                foreach(var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }

        [HttpGet]
        public ActionResult AuthorEdit(int id)
        {
            Author author = authorManager.GetByID(id);
            return View(author);
        }
        [HttpPost]
        public ActionResult AuthorEdit(Author author)
        {
            ValidationResult results = authorValidator.Validate(author);
            if (results.IsValid)
            {
                authorManager.Update(author);
                return RedirectToAction("AuthorList");
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
    }
}