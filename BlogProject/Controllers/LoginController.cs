using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DataAccesLayer.Concrete;
using DataAccesLayer.Migrations;
using EntityLayer.Concrete;

namespace BlogProject.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        Context context = new Context();

        [HttpGet]
        public ActionResult AuthorLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AuthorLogin(Author author)
        {
            var UserInfo = context.Authors.FirstOrDefault(x => x.Mail == author.Mail && x.Password == author.Password);

            if(UserInfo!= null)
            {
                FormsAuthentication.SetAuthCookie(UserInfo.Mail,false);
                Session["Mail"] = UserInfo.Mail.ToString();
                Session["NameSurname"] = UserInfo.NameSurname;
                Session["AuthorImage"] = UserInfo.AuthorImage;
                return RedirectToAction("Index", "User");
                
            }
            else
            {
                return RedirectToAction("AuthorLogin", "Login");
                
            }

        }

    }
}