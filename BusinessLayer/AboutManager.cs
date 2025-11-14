using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer
{
    public class AboutManager:IGenericService<About>
    {
        private readonly IGenericDal<About> _AboutDal;

        public AboutManager(IGenericDal<About> AboutDal)
        {
            _AboutDal = AboutDal;
        }

        public void Add(About t)
        {
            throw new NotImplementedException();
        }

        public void Delete(About t)
        {
            throw new NotImplementedException();
        }

        public About GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<About> List()
        {
            return _AboutDal.GetList();
        }

        public void Update(About t)
        {
            _AboutDal.Update(t);
        }

    }
}
