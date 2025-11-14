using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogProject.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
       

        public ActionResult Error403()
        {
            Response.StatusCode = 403;
            Response.TrySkipIisCustomErrors = true; //Bu satır → “IIS’in default hata sayfasını atla, benim gönderdiğim yanıtı direkt kullanıcıya göster” der.
            return View();
        }

        public ActionResult Error404()
        {
            Response.StatusCode = 404;
            Response.TrySkipIisCustomErrors = true;
            return View();
        }
    }
}