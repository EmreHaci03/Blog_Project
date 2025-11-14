using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer
{
    public class CategoryManager:IGenericService<Category>
    {
        private readonly IGenericDal<Category> _categoryDal;

        public CategoryManager(IGenericDal<Category> categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public List<Category> List()
        {
            return _categoryDal.GetList();
        }

        public Category GetByID(int id)
        {
            return _categoryDal.GetById(id);
        }

        public void Add(Category category)
        {
             _categoryDal.Insert(category);
        }

        public void Delete(Category category)
        {
             _categoryDal.Delete(category);
        }


        public void Update(Category category)
        {
             _categoryDal.Update(category);
        }
        public Category getByID(int id)
        {
            return _categoryDal.GetById(id);
        }

        public void CategoryEditStatus(int id)
        {
            Category category = _categoryDal.Find(x => x.CategoryID == id);
            category.CategoryStatus = true;
             _categoryDal.Update(category);
        }
        public void DeleteCategory(int id)
        {
            Category category = _categoryDal.Find(x => x.CategoryID ==id);
            category.CategoryStatus = false;
             _categoryDal.Update(category);  
        }

       
    }
}
