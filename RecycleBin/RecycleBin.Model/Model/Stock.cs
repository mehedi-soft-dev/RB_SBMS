using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecycleBin.Model.Model
{
    public class Stock
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int OpentingBalance { get; set; }
        public int StockIn { get; set; }
        public int StockOut { get; set; }
        public int ClosingBalance { get; set; }
    }
}
