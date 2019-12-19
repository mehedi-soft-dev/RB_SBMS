using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecycleBin.Model.Model;
using RecycleBin.Repository.Repository;

namespace RecycleBin.Manager.Manager
{
    public class SalesManager
    {
        SalesRepository _salesRepository = new SalesRepository();

        public bool Add(Sales sales)
        {
            return _salesRepository.Add(sales);
        }

        public int GetTotalSaleQuantity(int productId)
        {
            return _salesRepository.GetTotalSaleQuantity(productId);
        }


        public List<SalesDetails> GetAllSalesDetailses()
        {
            return _salesRepository.GetAllSalesDetailses();
        }

        public Sales GetSalesById(int id)
        {
            return _salesRepository.GetSalesById(id);
        }

        public List<SalesDetails> GetSalesDetailsesById(int id)
        {
            return _salesRepository.GetSalesDetailsesById(id);
        }

        public List<Sales> GetAll()
        {
            return _salesRepository.GetAll();
        }
    }
}
