using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using EntityLayer.Concrete;

namespace BusinessLayer
{
    public class UserProfileManager
    {
        private readonly IGenericDal<Author> _AuthorDal;
        private readonly IGenericDal<Blog> _BlogDal;

        public UserProfileManager(IGenericDal<Author> authorDal, IGenericDal<Blog> blogDal)
        {
            _AuthorDal = authorDal;
            _BlogDal = blogDal;
        }


        public List<Author> GetAuthorByMail(string mail)
        {
            return _AuthorDal.List(x => x.Mail == mail);
        }

        public List<Blog> GetBLogByAuthorId(int id)
        {
            return _BlogDal.List(x=>x.AuthorID== id); 
        }

        public void EditAuthor(Author p)
        {
            Author author=_AuthorDal.Find(x=>x.AuthorID== p.AuthorID);
            author.NameSurname = p.NameSurname;
            author.Mail = p.Mail;
            author.AuthorShortAbout = p.AuthorShortAbout;
            author.AuthorTitle = p.AuthorTitle;
            author.Password = p.Password;
            author.PhoneNumber = p.PhoneNumber;
            author.AuthorImage = p.AuthorImage; 
            author.AuthorAbout = p.AuthorAbout;
            _AuthorDal.Update(author);

        }
    }
}
