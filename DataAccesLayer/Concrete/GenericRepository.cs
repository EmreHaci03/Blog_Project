using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;

namespace DataAccesLayer.Concrete
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {

        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public void Delete(T t)
        {
            _dbSet.Remove(t);
             _context.SaveChanges();
        }

        public T Find(Expression<Func<T, bool>> filter)
        {
            return _dbSet.FirstOrDefault(filter);
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);

        }

        public List<T> GetList()
        {
            return _dbSet.ToList();
        }

        public void Insert(T t)
        {
            _dbSet.Add(t);
             _context.SaveChanges();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _dbSet.Where(filter).ToList();
        }

        public void Update(T t)
        {

                _context.Entry(t).State = EntityState.Modified;
                 _context.SaveChanges();
        }


    }
}
