using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RecycleBin.Model.Model;

namespace RecycleBin.Models
{
    public class StockViewModel
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public int ReOrderLevel { get; set; }
        public int OpeningBalance { get; set; }
        public int StockIn { get; set; }
        public int StockOut { get; set; }
        public int ClosingBalance { get; set; }

        public List<StockView> StockViews { get; set; }
        public List<Stock> Stocks { get; set; }
        public List<PurchaseDetails> PurchaseDetailses { get; set; }
        public List<SalesDetails> SalesDetailses { get; set; }
    }
}