using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer
{
    public class CommentManager:IGenericService<Comment>
    {
        private readonly IGenericDal<Comment> _CommentDal;

        public CommentManager(IGenericDal<Comment> CommentDal)
        {
                _CommentDal=CommentDal;
        }


        public List<Comment> CommentListByBlog(int id)
        {
            return _CommentDal.List(X=>X.BlogID==id);
        }
        
        public List<Comment> CommentListByStatusTrue()
        {
            return _CommentDal.List(x => x.CommentStatus == true);
        }
        public List<Comment> CommentListByStatusFalse()
        {
            return _CommentDal.List(x => x.CommentStatus == false);
        }
    
        public void SetCommentStatusFalse(int id)
        {
            Comment comment=_CommentDal.Find(x=>x.CommentID==id);  
            comment.CommentStatus = false;
            _CommentDal.Update(comment);
        }
        public void SetCommentStatusTrue(int id)
        {
            Comment comment = _CommentDal.Find(x=>x.CommentID==id);
            comment.CommentStatus = true;
            _CommentDal.Update(comment);
        }

        public List<Comment> List()
        {
            return _CommentDal.GetList();
        }

        public void Add(Comment t)
        {
            _CommentDal.Insert(t);
        }

        public Comment GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Comment t)
        {
            throw new NotImplementedException();
        }

        public void Update(Comment t)
        {
            throw new NotImplementedException();
        }
    }
}
