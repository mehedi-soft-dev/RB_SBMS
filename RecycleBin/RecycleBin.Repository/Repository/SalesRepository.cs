using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using RecycleBin.DatabaseContext.DatabaseContext;
using RecycleBin.Model.Model;

namespace RecycleBin.Repository.Repository
{
    public class SalesRepository
    {
        ProjectDbContext _dbContext = new ProjectDbContext();
        public bool Add(Sales sales)
        {
            _dbContext.Saleses.Add(sales);

            return _dbContext.SaveChanges() > 0;
        }

        public int GetTotalSaleQuantity(int productId)
        {
            int sum = _dbContext.SalesDetailses
                .AsEnumerable()
                .Where(c => c.ProductId == productId)
                .Sum(c => c.Quantity);

            return sum;
        }

        public List<Sales> GetAll()
        {
            return _dbContext.Saleses.Include(c => c.Customer).Include(c => c.SalesDetailses).OrderByDescending(c=>c.Id).ToList();
        }

        public List<SalesDetails> GetAllSalesDetailses()
        {
            return _dbContext.SalesDetailses.ToList();
        }

        public List<SalesDetails> GetSalesDetailsesById(int id)
        {
            return _dbContext.SalesDetailses.Include(c => c.Sales.Customer).Include(c => c.Product).Where(c => c.SalesId == id).ToList();

        }

        public Sales GetSalesById(int id)
        {
            return _dbContext.Saleses.Include(c=>c.SalesDetailses).Include(c => c.Customer).FirstOrDefault(c => c.Id == id);
        }

    }
}
