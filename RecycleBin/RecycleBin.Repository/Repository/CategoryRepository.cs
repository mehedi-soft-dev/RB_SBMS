using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecycleBin.DatabaseContext.DatabaseContext;
using RecycleBin.Model.Model;

namespace RecycleBin.Repository.Repository
{
    public class CategoryRepository
    {
        ProjectDbContext _dbContext = new ProjectDbContext();

        public bool Add(Category category)
        {
            _dbContext.Categories.Add(category);

            return _dbContext.SaveChanges() > 0;
        }

        public List<Category> GetAll()
        {
            return _dbContext.Categories.ToList();
        }

        public Category GetById(int id)
        {
            return _dbContext.Categories.FirstOrDefault(c => c.Id == id);
        }

        public bool Upadate(Category category)
        {
            _dbContext.Entry(category).State = EntityState.Modified;
            return _dbContext.SaveChanges()>0;
        }

        public bool Remove(int id)
        {
            Category aCategory = _dbContext.Categories.FirstOrDefault(c => c.Id == id);

            _dbContext.Categories.Remove(aCategory);

            return _dbContext.SaveChanges() > 0;
        }

        public bool IsCodeExist(string code)
        {
            return GetAll().Exists(c => c.Code.Equals(code, StringComparison.CurrentCultureIgnoreCase));
        }

    }
}
