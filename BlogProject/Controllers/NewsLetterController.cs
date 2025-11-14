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
    public class NewsLetterController : Controller
    {
        MailManager mailManager = new MailManager(new GenericRepository<MailSubscribe>(new Context()));

        [HttpGet]
        public PartialViewResult AddMail()
        {
            return PartialView();
        }
        [HttpPost]

        public PartialViewResult AddMail(MailSubscribe p)
        {
            mailManager.Add(p);
            return PartialView();
        }
    }
}