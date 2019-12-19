using RecycleBin.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecycleBin.Model.Model;

namespace RecycleBin.Manager.Manager
{
    public class StockManger
    {
        StockRepository _stockRepository = new StockRepository();

        public List<StockView> ViewStock()
        {
            return _stockRepository.ViewStock();
        }

        public List<StockView> ViewStockByDate(DateTime startDate, DateTime endDate)
        {
            return _stockRepository.ViewStockByDate(startDate, endDate);
        }

    }
}
