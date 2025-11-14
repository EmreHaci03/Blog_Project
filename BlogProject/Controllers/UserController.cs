using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BusinessLayer;
using DataAccesLayer.Concrete;
using EntityLayer.Concrete;

namespace BlogProject.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        UserProfileManager userProfileManager = new UserProfileManager(
        new GenericRepository<Author>(new Context()),
        new GenericRepository<Blog>(new Context())
    );
        BlogManager blogManager = new BlogManager(new GenericRepository<Blog>(new Context()));
        AuthorManager authorManager = new AuthorManager(new GenericRepository<Author>(new Context()));
        CommentManager commentManager = new CommentManager(new GenericRepository<Comment>(new Context()));
        Context context = new Context();
   

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult UserProfilePartial(string mail)
        {
            var Mail = (string)Session["Mail"];
            var profileValues = userProfileManager.GetAuthorByMail(Mail);
            
            return PartialView(profileValues);
        }

        public ActionResult BlogList(string mail)
        {
             mail = (string)Session["Mail"];
            int id = context.Authors.Where(x => x.Mail == mail).Select(y => y.AuthorID).FirstOrDefault();
            var Blogs = userProfileManager.GetBLogByAuthorId(id);
            return View(Blogs);
        }

        [HttpGet]
        public ActionResult UpdateBLog(int id)
        {
            Context context = new Context();
            List<SelectListItem> List = (from x in context.Categories.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.CategoryName,
                                             Value = x.CategoryID.ToString()
                                         }
                                       ).ToList();

            ViewBag.values = List;

            List<SelectListItem> List2 = (from x in context.Authors.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.NameSurname,
                                              Value = x.AuthorID.ToString()
                                          }
                                        ).ToList();

            ViewBag.value2 = List2;
            Blog blog = blogManager.GetByID(id);
            return View(blog);
        }

        [HttpPost]
        public ActionResult UpdateBlog(Blog p)
        {
            blogManager.Update(p);
            return RedirectToAction("BlogList");
        }

        [HttpGet]
        public ActionResult AddNewBlog()
        {
            Context context = new Context();
            List<SelectListItem> List = (from x in context.Categories.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.CategoryName,
                                             Value = x.CategoryID.ToString()
                                         }
                                       ).ToList();

            ViewBag.values = List;

     
            List<SelectListItem> List2 = (from x in context.Authors.ToList()
                                          select new SelectListItem
                                         {
                                              Text = x.NameSurname,
                                              Value = x.AuthorID.ToString()
                                          }
                                        ).ToList();

            ViewBag.value2 = List2;
            return View();
        }

        [HttpPost]

        public ActionResult AddNewBlog(Blog blog)
        {
            blogManager.Add(blog);
            return RedirectToAction("BlogList");
        }

        [HttpPost]
        public ActionResult UpdateUserProfile(Author author)
        {
            authorManager.Update(author);
            return RedirectToAction("Index", "User");
        }
        
        public ActionResult CommentListByStatusTrue()
        {
            var TrueList=commentManager.CommentListByStatusTrue();
            return View(TrueList);
        }
        public ActionResult CommentListByStatusFalse()
        {
            var FalseList=commentManager.CommentListByStatusFalse();
            return View(FalseList);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut(); // kullanıcının authentication cookie’sini (kimlik doğrulama çerezi) siler.
            Session.Abandon(); // Sunucudaki session temizlenir.
            return RedirectToAction("AuthorLogin","Login");
        }

      
    }
}
