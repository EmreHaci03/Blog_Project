using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using BusinessLayer.ValidationRules;
using DataAccesLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.Results;
using FluentValidation.Validators;
using PagedList;

namespace BlogProject.Controllers
{
    public class CommentController : Controller
    {
        CommentManager commentManager = new CommentManager(new GenericRepository<Comment>(new Context()));

        CommentValidator commentValidator = new CommentValidator();

        [AllowAnonymous]
        public PartialViewResult CommentList(int id,int page=1)
        {
            var commentList = commentManager.CommentListByBlog(id).ToPagedList(page,3);
            return PartialView(commentList);
        }
        [AllowAnonymous]
        [HttpGet]
        public PartialViewResult AddComment(int id)
        {
            ViewBag.id = id;
            return PartialView();
        }
        [AllowAnonymous]
        [HttpPost]
        public PartialViewResult AddComment(Comment comment)
        {
            ValidationResult results = commentValidator.Validate(comment);

            if (results.IsValid)
            {
                comment.CommentStatus = true;
                commentManager.Add(comment);

               
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

            }

            return PartialView(comment);
        }

        public ActionResult GetCommentByBlog(int id)
        {
            var commentList=commentManager.CommentListByBlog(id);
            return View(commentList);
        }

        public ActionResult AdminCommentListTrue()
        {
            var commentList = commentManager.CommentListByStatusTrue();
            return View(commentList);
        }
        public ActionResult StatusChangeToFalse(int id)
        {
            commentManager.SetCommentStatusFalse(id);
            return RedirectToAction("AdminCommentListTrue");
        }
        public ActionResult StatusChangeToTrue(int id)
        {
            commentManager.SetCommentStatusTrue(id);
            return RedirectToAction("AdminCommentListFalse");
        }
        public ActionResult AdminCommentListFalse()
        {
            var commentList = commentManager.CommentListByStatusFalse();
            return View(commentList);
        }
    }
}