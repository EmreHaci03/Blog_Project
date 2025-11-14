using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer
{
    public class BlogManager:IBlogService
    {
        private readonly IGenericDal<Blog> _BlogDal;
       
        public BlogManager(IGenericDal<Blog> Blogdal)
        {
               _BlogDal = Blogdal;
        }
        public List<Blog> GetBlogById(int id)
        {
            return _BlogDal.List(x => x.BlogID == id);
        }

        public List<Blog> GetBlogByAuthor(int id)
        {
            return _BlogDal.List(x=>x.AuthorID == id);
        }

        public List<Blog>  GetBlogByCategory(int id)
        {
            return _BlogDal.List(x=>x.CategoryID == id);    
        }

        
        public List<Blog> List()
        {
            return _BlogDal.GetList();
        }

        public void Add(Blog t)
        {
            _BlogDal.Insert(t);
        }

        public Blog GetByID(int id)
        {
            return _BlogDal.GetById(id);
        }

        public void Delete(Blog t)
        {
            _BlogDal.Delete(t);
        }

        public void Update(Blog t)
        {
            _BlogDal.Update(t);
        }
    }
}
