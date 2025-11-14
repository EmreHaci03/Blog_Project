using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using DataAccesLayer.Concrete;
using EntityLayer.Concrete;

namespace BlogProject.Controllers
{

    [AllowAnonymous]
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new GenericRepository<About>(new Context()));
        public ActionResult Index()
        {
            var list = aboutManager.List();
            return View(list);
        }
        public PartialViewResult OurTeam()
        {
            AuthorManager authorManager = new AuthorManager(new GenericRepository<Author>(new Context()));
            var authorList = authorManager.List();
            return PartialView(authorList);
        }

        [HttpGet]
        public ActionResult UpdateAboutList()
        {
            var aboutList=aboutManager.List();
            return View(aboutList);
        }

        [HttpPost]
        public ActionResult UpdateAbout(About p)
        {
            aboutManager.Update(p);
            return RedirectToAction("Index");
        }
    }
}