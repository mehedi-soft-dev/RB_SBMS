using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecycleBin.Model.Model;
using RecycleBin.Repository.Repository;

namespace RecycleBin.Repository
{
    public class ReportRepository
    {
        ProductRepository _productRepository = new ProductRepository();
        PurchaseRepository _purchaseRepository = new PurchaseRepository();
        SalesRepository _salesRepository = new SalesRepository();


        public List<PurchaseView> GetExpenseReportOnPurchse()
        {
            List<PurchaseView> purchaseViews = new List<PurchaseView>();

            var products = _productRepository.GetAll();

            foreach (var p in products)
            {
                var pds = _purchaseRepository.GetAllPurchaseDetails().Where(c => c.ProductId == p.Id).ToList();

                if(pds.Count == 0) continue;

                int TotalPurchseQuantity = _purchaseRepository.GetTotalPurchaseQuantity(p.Id);
                int TotalSaleQuantity = _salesRepository.GetTotalSaleQuantity(p.Id);
                int AvailableQuantity = TotalPurchseQuantity - TotalSaleQuantity;

                PurchaseView purchaseView = new PurchaseView();
                purchaseView.Product = p.Name;
                purchaseView.Quantity = AvailableQuantity;
                purchaseView.ReOrderLevel = p.ReOrderLevel;
                purchaseView.UnitPrice = pds.Last().UnitPrice;
                purchaseView.MRP = pds.Last().MRP;
                purchaseView.Profit = (purchaseView.Quantity * purchaseView.MRP) -
                                      (purchaseView.Quantity * purchaseView.UnitPrice);

                purchaseViews.Add(purchaseView);
            }

            return purchaseViews;
        }

        public List<PurchaseView> GetExpenseReportOnSales()
        {
            List<PurchaseView> purchaseViews = new List<PurchaseView>();

            var products = _productRepository.GetAll();

            foreach (var p in products)
            {
                var sds = _salesRepository.GetAllSalesDetailses().Where(c => c.ProductId == p.Id).ToList();

                if (sds.Count == 0) continue;

                int SoldQuantity = _salesRepository.GetTotalSaleQuantity(p.Id);

                PurchaseView purchaseView = new PurchaseView();
                purchaseView.Product = p.Name;
                purchaseView.Quantity = SoldQuantity;
                purchaseView.ReOrderLevel = p.ReOrderLevel;
                purchaseView.UnitPrice = sds.Last().UnitPrice;
                purchaseView.MRP = sds.Last().MRP;
                purchaseView.Profit = (purchaseView.Quantity * purchaseView.MRP) -
                                      (purchaseView.Quantity * purchaseView.UnitPrice);

                purchaseViews.Add(purchaseView);
            }

            return purchaseViews;
        }

    }
}
