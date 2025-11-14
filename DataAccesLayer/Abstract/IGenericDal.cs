using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Abstract
{
    public interface IGenericDal<T> where T : class //T parametresi ile tablolar gönderilir
    {
        List<T> GetList();

        void Insert(T t); //Sayısal ifade döndürür o yüzden int kullandık.

        void Update(T t);

        void Delete(T t);

        T GetById(int id); //T yerine Blog geldiğinde id=5 olduğunda mesela id değeri 5 olan blog getirilir.

        List<T> List(Expression<Func<T,bool>> filter);

        T Find(Expression<Func<T,bool>> filter);
    }
}
