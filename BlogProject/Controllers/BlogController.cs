using System;
using System.Collections.Generic;
using PagedList;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using DataAccesLayer.Concrete;
using EntityLayer.Concrete;
using Antlr.Runtime.Tree;

namespace BlogProject.Controllers
{
    public class BlogController : Controller
    {
        BlogManager blogManager = new BlogManager(new GenericRepository<Blog>(new Context()));

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public PartialViewResult BLogList(int page=1)
        {
            var list = blogManager.List().ToPagedList(page, 4);
            return PartialView(list);
        }
        [AllowAnonymous]
        public PartialViewResult FeaturedPost()
        {

            // 1.Post
            var postID = blogManager.List().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 7).Select(y => y.BlogID).FirstOrDefault();
            var posttitle1=blogManager.List().OrderByDescending(z=>z.BlogID).Where(x=>x.CategoryID==7).Select(y=>y.BlogTitle).FirstOrDefault();
            var postimage1= blogManager.List().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 7).Select(y => y.BlogImage).FirstOrDefault();
            var blogdate1=blogManager.List().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 7).Select(y => y.BlogDate).FirstOrDefault();
            
            ViewBag.PostID = postID;
            ViewBag.PostTitle1 = posttitle1;
            ViewBag.PostImage1 = postimage1;
            ViewBag.BlogDate1 = blogdate1;


            //2.Post
            var postID2 = blogManager.List().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 8).Select(y => y.BlogID).FirstOrDefault();
            var posttitle2 = blogManager.List().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 8).Select(y => y.BlogTitle).FirstOrDefault();
            var postimage2 = blogManager.List().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 8).Select(y => y.BlogImage).FirstOrDefault();
            var blogdate2 = blogManager.List().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 8).Select(y => y.BlogDate).FirstOrDefault();
            ViewBag.PostID2 = postID2;
            ViewBag.PostTitle2 = posttitle2;
            ViewBag.PostImage2 = postimage2;
            ViewBag.BlogDate2 = blogdate2;

            //3.Post
            var postID3 = blogManager.List().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 9).Select(y => y.BlogID).FirstOrDefault();
            var posttitle3 = blogManager.List().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 9).Select(y => y.BlogTitle).FirstOrDefault();
            var postimage3 = blogManager.List().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 9).Select(y => y.BlogImage).FirstOrDefault();
            var blogdate3 = blogManager.List().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 9).Select(y => y.BlogDate).FirstOrDefault();
            ViewBag.PostID3 = postID3;
            ViewBag.PostTitle3 = posttitle3;
            ViewBag.PostImage3 = postimage3;
            ViewBag.BlogDate3 = blogdate3;

            //4.Post
            var postID4 = blogManager.List().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 6).Select(y => y.BlogID).FirstOrDefault();
            var posttitle4 = blogManager.List().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 6).Select(y => y.BlogTitle).FirstOrDefault();
            var postimage4 = blogManager.List().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 6).Select(y => y.BlogImage).FirstOrDefault();
            var blogdate4 = blogManager.List().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 6).Select(y => y.BlogDate).FirstOrDefault();
            ViewBag.PostID4 = postID4;
            ViewBag.PostTitle4 = posttitle4;
            ViewBag.PostImage4 = postimage4;
            ViewBag.BlogDate4 = blogdate4;

            //5.Post
            var postID5 = blogManager.List().OrderByDescending(x => x.BlogID).Where(y => y.CategoryID == 4).Select(z => z.BlogID).FirstOrDefault();
            var postTitle5= blogManager.List().OrderByDescending(x => x.BlogID).Where(y => y.CategoryID == 4).Select(z => z.BlogTitle).FirstOrDefault();
            var postimage5 = blogManager.List().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 4).Select(y => y.BlogImage).FirstOrDefault();
            var blogdate5 = blogManager.List().OrderByDescending(z => z.BlogID).Where(x => x.CategoryID == 4).Select(y => y.BlogDate).FirstOrDefault();
            
            ViewBag.PostID5 = postID5;
            ViewBag.PostTitle5 = postTitle5;
            ViewBag.PostImage5 = postimage5;
            ViewBag.BlogDate5 = blogdate5;


            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult OtherFeaturedPost()
        {
            return PartialView();
        }
        [AllowAnonymous]
        public ActionResult BlogDetails()
        {    
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult BlogCover(int id)
        {
            var values = blogManager.GetBlogById(id);
            return PartialView(values);
        }
        [AllowAnonymous]
        public PartialViewResult ReadMore(int id)
        {
            var values = blogManager.GetBlogById(id);
            return PartialView(values);
        }
        [AllowAnonymous]
        public PartialViewResult CommentList()
        {
            return PartialView();
        }
        [AllowAnonymous]
        public ActionResult BlogByCategory(int id,int page=1)
        {
            var ListByCategory = blogManager.GetBlogByCategory(id).ToPagedList(page,4);

            var categoryname = blogManager.GetBlogByCategory(id).Select(y => y.Category.CategoryName).FirstOrDefault();
            ViewBag.CategoryName = categoryname;

            var categoryDescription=blogManager.GetBlogByCategory(id).Select(y=>y.Category.CategoryDescription).FirstOrDefault();

            ViewBag.CategoryDescription=categoryDescription;
            return View(ListByCategory);
        }

        public ActionResult AdminBlogList()
        {
            var BlogList = blogManager.List();
            return View(BlogList);
        }

        public ActionResult AdminBlogList2()
        {
            var BlogList = blogManager.List();
            return View(BlogList);
        }

        [Authorize(Roles ="A")]
        [HttpGet]
        public ActionResult AddNewBlog()
        {
            Context context= new Context();
            List<SelectListItem> List = (from x in context.Categories.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.CategoryName,
                                             Value = x.CategoryID.ToString()
                                         }
                                       ).ToList();

            ViewBag.values=List;

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
            return RedirectToAction("AdminBlogList");
        }
        public ActionResult DeleteBlog(int id)
        {
            Blog blog = blogManager.GetByID(id);
            blogManager.Delete(blog);
            return RedirectToAction("AdminBlogList");
        }

        [HttpGet]
        public ActionResult UpdateBlog(int id)
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
       public ActionResult UpdateBLog(Blog blog)
        {
            
            blogManager.Update(blog);
            return RedirectToAction("AdminBlogList");
        }
        public ActionResult AuthorBlogList(int id)
        {
            var Blogs = blogManager.GetBlogByAuthor(id);
            return View(Blogs);
        }
        
    }
}