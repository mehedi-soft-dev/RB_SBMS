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
    public class PurchaseRepository
    {
        ProjectDbContext _dbContext = new ProjectDbContext();
        public bool Add(Purchase purchase)
        {
            _dbContext.Purchases.Add(purchase);

            return _dbContext.SaveChanges()>0;
        }

        public int GetTotalPurchaseQuantity(int id)
        {
            int sum = _dbContext.PurchaseDetailses
                .AsEnumerable()
                .Where(c => c.ProductId == id)
                .Sum(c => c.Quantity);

            return sum;
        }

        public double GetMRP(int productId)
        {
            double MRP;
            try
            {
                MRP = (double?)_dbContext.PurchaseDetailses
                    .AsEnumerable()
                    .Where(c => c.ProductId == productId)
                    .Last()
                    .MRP ?? 0;
            }
            catch (Exception exception)
            {
                MRP = 0;
            }

            return MRP;
        }

        public List<Purchase> GetAll()
        {
            return _dbContext.Purchases.Include(c=>c.PurchaseDetailses).Include(c=>c.Supplier).OrderByDescending(x=>x.Id).ToList();
        }

        public List<PurchaseDetails> GetPurchaseDetailsById(int purchaseId)
        {
            return _dbContext.PurchaseDetailses.Include(c=>c.Product).Include(c=>c.Purchase.Supplier).Where(c=>c.PurchaseId == purchaseId).ToList();
        }

        public List<PurchaseDetails> GetAllPurchaseDetails()
        {
            return _dbContext.PurchaseDetailses.Include(c=>c.Product).ToList();
        }

        public Purchase GetPurchaseById(int id)
        {
            return _dbContext.Purchases.Include(c=>c.Supplier).FirstOrDefault(c=>c.Id == id);
        }
    }
}
