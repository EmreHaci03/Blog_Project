using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer
{
    public class AuthorManager:IGenericService<Author>
    {
        private readonly IGenericDal<Author> _authorDal;

        public AuthorManager(IGenericDal<Author> authorDal)
        {
               _authorDal = authorDal;  
        }   

        public List<Author> List()
        {
            return _authorDal.GetList();
        }

        public void Add(Author t)
        {
            _authorDal.Insert(t);
        }

        public Author GetByID(int id)
        {
            return _authorDal.GetById(id);
        }

        public void Delete(Author t)
        {
            throw new NotImplementedException();
        }

        public void Update(Author t)
        {
            _authorDal.Update(t);
        }
    }
}
