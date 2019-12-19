using RecycleBin.DatabaseContext.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecycleBin.Model.Model;
using System.Data.Entity;

namespace RecycleBin.Repository.Repository
{
    public class SupplierRepository
    {
        ProjectDbContext _dbContext = new ProjectDbContext();

        public bool Add(Supplier supplier)
        {
            _dbContext.Suppliers.Add(supplier);

            return _dbContext.SaveChanges() > 0;
        }

        public List<Supplier> GetAll()
        {
            return _dbContext.Suppliers.ToList();
        }

        public Supplier GetById(int id)
        {
            return _dbContext.Suppliers.FirstOrDefault(c => c.Id == id);
        }

        public bool Upadate(Supplier supplier)
        {
            _dbContext.Entry(supplier).State = EntityState.Modified;
            return _dbContext.SaveChanges() > 0;
        }

        public bool IsCodeExist(string code)
        {
            return GetAll().Exists(c => c.Code.Equals(code, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
