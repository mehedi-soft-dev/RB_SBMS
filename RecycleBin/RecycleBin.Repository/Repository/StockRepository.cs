using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RecycleBin.Model.Model;

namespace RecycleBin.Repository.Repository
{
    public class StockRepository
    {
        ProductRepository _productRepository = new ProductRepository();
        PurchaseRepository _purchaseRepository = new PurchaseRepository();
        SalesRepository _salesRepository = new SalesRepository();

        public List<StockView> ViewStock()
        {
            List<StockView> stockViews = new List<StockView>();
            
            var products = _productRepository.GetAll();

            foreach (var p in products)
            {
                StockView stockView = new StockView();
                var pd = _purchaseRepository.GetAllPurchaseDetails().Where(c => c.ProductId == p.Id).ToList();
                var sd = _salesRepository.GetAllSalesDetailses().Where(c => c.ProductId == p.Id).ToList();

                stockView.Product = p.Name;
                stockView.ReOrderLevel = p.ReOrderLevel;
                stockView.OpeningBalance = 0;
                stockView.StockIn = pd.AsEnumerable().Sum(c => (int?) c.Quantity) ?? 0;
                stockView.StockOut = sd.AsEnumerable().Sum(c => (int?) c.Quantity) ?? 0;
                stockView.ClosingBalance = stockView.StockIn - stockView.StockOut;

                stockViews.Add(stockView);

            }

            return stockViews;

        }

        public List<StockView> ViewStockByDate(DateTime startDate, DateTime endDate)
        {
            List<StockView> stockViews = new List<StockView>();
            List<PurchaseDetails> pds = new List<PurchaseDetails>();
            List<SalesDetails> sds = new List<SalesDetails>();
            var products = _productRepository.GetAll();
            var purchases = _purchaseRepository
                            .GetAll()
                            .Where(c => c.Date >= startDate)
                            .Where(c => c.Date <= endDate)
                            .ToList();

            var sales = _salesRepository
                .GetAll()
                .Where(c => c.Date >= startDate)
                .Where(c => c.Date <= endDate)
                .ToList();


            foreach (var pr in purchases)
            {
                var p = _purchaseRepository.GetAllPurchaseDetails().Where(c => c.PurchaseId == pr.Id).ToList();
                pds.AddRange(p);
            }

            foreach (var sl in sales)
            {
                var s = _salesRepository.GetAllSalesDetailses().Where(c => c.SalesId == sl.Id).ToList();
                sds.AddRange(s);
            }

            foreach (var p in products)
            {
                var pd = pds.Where(c => c.ProductId == p.Id).ToList();
                var sd = sds.Where(c => c.ProductId == p.Id).ToList();
                if (pd.Count == 0 && sd.Count == 0) continue;

                StockView stockView = new StockView();
                stockView.ReOrderLevel = p.ReOrderLevel;
                stockView.Product = p.Name;
                stockView.OpeningBalance = GetOpeningBalance(startDate, p.Id);
                stockView.StockIn = pd.AsEnumerable().Sum(c => (int?)c.Quantity)??0;
                stockView.StockOut = sd.AsEnumerable().Sum(c => (int?)c.Quantity)??0;
                stockView.ClosingBalance = stockView.OpeningBalance + stockView.StockIn - stockView.StockOut;
                stockViews.Add(stockView);
            }
            

            return stockViews;
        }

        private int GetOpeningBalance(DateTime date, int productId)
        {
            var purchases = _purchaseRepository.GetAll().Where(c => c.Date < date).ToList();
            List<PurchaseDetails> pds = new List<PurchaseDetails>();
            foreach (var pr in purchases)
            {
                var pd = _purchaseRepository.GetAllPurchaseDetails().Where(c => c.PurchaseId == pr.Id).Where(c=>c.ProductId == productId).ToList();
                if(pd.Count!=0)
                    pds.AddRange(pd);
            }

            int OpeningBalance = 0;
            OpeningBalance = pds.AsEnumerable().Sum(c =>(int?) c.Quantity) ?? 0;

            return OpeningBalance;
        }
    }
}
