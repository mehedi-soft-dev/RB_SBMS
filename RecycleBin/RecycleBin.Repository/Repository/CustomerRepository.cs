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
    public class CustomerRepository
    {
        ProjectDbContext _dbContext = new ProjectDbContext();

        public bool Add(Customer customer)
        {
            _dbContext.Customers.Add(customer);

            return _dbContext.SaveChanges() > 0;
        }

        public List<Customer> GetAll()
        {
            return _dbContext.Customers.ToList();
        }

        public Customer GetById(int id)
        {
            return _dbContext.Customers.FirstOrDefault(c => c.Id == id);
        }

        public bool Upadate(Customer customer)
        {
            _dbContext.Entry(customer).State = EntityState.Modified;
            return _dbContext.SaveChanges() > 0;
        }

        public bool IsCodeExist(string code)
        {
            return GetAll().Exists(c => c.Code.Equals(code, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
