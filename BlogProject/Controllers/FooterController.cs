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
    public class FooterController : Controller
    {

        AboutManager aboutManager = new AboutManager(new GenericRepository<About>(new Context()));

        public PartialViewResult Index()
        {
            var values = aboutManager.List();
            return PartialView(values);
        }
    }
}