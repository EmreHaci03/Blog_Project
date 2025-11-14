using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T>
    {
        List<T> List();

        void Add(T t);

        T GetByID(int id);

        void Delete(T t);

        void Update(T t);
    }
}
