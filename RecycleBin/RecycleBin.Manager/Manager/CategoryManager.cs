using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecycleBin.Model.Model;
using RecycleBin.Repository.Repository;

namespace RecycleBin.Manager.Manager
{
    public class CategoryManager
    {
        CategoryRepository _categoryRepository = new CategoryRepository();

        public bool Add(Category category)
        {
            return _categoryRepository.Add(category);
        }

        public List<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public Category GetById(int id)
        {
            return _categoryRepository.GetById(id);
        }

        public bool Upadate(Category category)
        {
            return _categoryRepository.Upadate(category);
        }

        public bool Remove(int id)
        {
            return _categoryRepository.Remove(id);
        }

        public bool IsCodeExist(string code)
        {
            return _categoryRepository.IsCodeExist(code);
        }
    }
}
