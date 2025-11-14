using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DataAccesLayer.Concrete;
using EntityLayer.Concrete;

namespace BlogProject.Controllers
{
    [AllowAnonymous]
    public class AdminLoginController : Controller
    {

         Context context = new Context();
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            var AdminInfo = context.Admins.FirstOrDefault(x=>x.Username==admin.Username && x.Password==admin.Password);

            if (AdminInfo != null)
            {
                FormsAuthentication.SetAuthCookie(AdminInfo.Username,false);
                Session["UserName"] = AdminInfo.Username.ToString();
                //Session["Password"]=AdminInfo.Password;
                return RedirectToAction("AdminBlogList", "Blog");
            }
            else
            {
                throw new Exception("Lütfen Gerekli Alanları Eksiksiz Girerek Tekrar Deneyiniz");
            }

        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login", "AdminLogin");
        }
    }
}