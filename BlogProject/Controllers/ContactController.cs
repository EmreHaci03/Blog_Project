using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using BusinessLayer;
using BusinessLayer.ValidationRules;
using DataAccesLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.Results;
using WebGrease;

namespace BlogProject.Controllers
{
    public class ContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new GenericRepository<Contact>(new Context()));
        ContactValidator contactValidator = new ContactValidator(); 
        Contact contact=new Contact();  
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult SendMessage()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]

        public ActionResult SendMessage(Contact contact)
        {
           
            ValidationResult results= contactValidator.Validate(contact);
            if (results.IsValid)
            {
                contactManager.Add(contact);
                return RedirectToAction("SendMessage", "Contact");
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

        public ActionResult SendBox()
        {
            var List = contactManager.List();
            return View(List);
        }
        
        public ActionResult MessageDetails(int id)
        {
            Contact contact = contactManager.GetByID(id);
            return View(contact);
        }
        public ActionResult DeleteMessage(int id)
        {
            Contact Contact = contactManager.GetByID(id);
            contactManager.Delete(Contact);
            return RedirectToAction("SendBox", "Contact");
        }

    }
}