using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using RecycleBin.Model.Model;
using RecycleBin.Repository.Repository;

namespace RecycleBin.Manager.Manager
{
    public class PurchaseManager
    {
        PurchaseRepository _purchaseRepository = new PurchaseRepository();

        public bool Add(Purchase purchase)
        {
            return _purchaseRepository.Add(purchase);
        }

        public int GetTotalPurchaseQuantity(int id)
        {
            return _purchaseRepository.GetTotalPurchaseQuantity(id);
        }

        public List<Purchase> GetAll()
        {
            return _purchaseRepository.GetAll();
        }

        public List<PurchaseDetails> GetPurchaseDetailsById(int purchaseId)
        {
            return _purchaseRepository.GetPurchaseDetailsById(purchaseId);
        }

        public List<PurchaseDetails> GetAllPurchaseDetails()
        {
            return _purchaseRepository.GetAllPurchaseDetails();
        }

        public double GetMRP(int productId)
        {
            return _purchaseRepository.GetMRP(productId);
        }

        public Purchase GetPurchaseById(int id)
        {
            return _purchaseRepository.GetPurchaseById(id);
        }
    }
}
