using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogProject.Models;
using DataAccesLayer.Concrete;
using EntityLayer.Concrete;

namespace BlogProject.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult VisualizeResult()
        //{
        //    return Json(CategoryList(),JsonRequestBehavior.AllowGet);
        //}

        //public List<PieChartData> CategoryList()
        //{
        //    List<PieChartData> categoryList = new List<PieChartData>();

        //    categoryList.Add(new PieChartData()
        //    {
        //         CategoryName="Teknoloji",
        //         BlogCount=15
        //    });
        //    categoryList.Add(new PieChartData()
        //    {
        //        CategoryName="Sağlık",
        //        BlogCount=15
        //    });
        //    categoryList.Add(new PieChartData()
        //    {
        //        CategoryName = "Kimya",
        //        BlogCount = 15
        //    });

        //    return categoryList;
        //}

        public ActionResult VisualizeResult2()
        {
            return Json(BlogList(),JsonRequestBehavior.AllowGet);
        }

        public List<BlogListChart> BlogList()
        {
            List<BlogListChart> BlogList = new List<BlogListChart>();
            using (var db = new Context())
            {
                BlogList = db.Blogs.Select(x => new BlogListChart
                {
                    BlogName = x.BlogTitle,
                    BlogRating = x.BlogRating
                }).ToList();
            }

            return BlogList; 
        }

        public ActionResult BlogListChart1()
        {
            return View();
        }

        public ActionResult BlogListChart2()
        {
            return View();
        }

        public ActionResult BlogListChart3()
        {
            return View();
        }
    }
}