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
    public class ProductRepository
    {
        ProjectDbContext _dbContext = new ProjectDbContext();

        public bool Add(Product product)
        {
            _dbContext.Products.Add(product);

            return _dbContext.SaveChanges() > 0;
        }

        public List<Product> GetAll()
        {
            return _dbContext.Products.Include(c => c.Category).OrderBy(c => c.CategoryId).ToList();
        }

        public Product GetById(int id)
        {
            return _dbContext.Products.FirstOrDefault(c => c.Id == id);
        }

        public bool Upadate(Product product)
        {
            _dbContext.Entry(product).State = EntityState.Modified;
            return _dbContext.SaveChanges() > 0;
        }

        public bool IsCodeExist(string code)
        {
            return GetAll().Exists(c => c.Code.Equals(code, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
