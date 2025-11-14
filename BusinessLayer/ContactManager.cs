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
    public class ContactManager:IGenericService<Contact>
    {

        private readonly IGenericDal<Contact> _contactDal;

        public ContactManager(IGenericDal<Contact> contactDal)
        {
                _contactDal = contactDal;
        }
        public List<Contact> List()
        {
            return _contactDal.GetList();
        }
        public void Add(Contact t)
        {
            _contactDal.Insert(t);
        }

        public void Delete(Contact t)
        {
           _contactDal.Delete(t);
        }

        public Contact GetByID(int id)
        {
            return _contactDal.GetById(id);
        }


        public void Update(Contact t)
        {
            throw new NotImplementedException();
        }
    }
}
