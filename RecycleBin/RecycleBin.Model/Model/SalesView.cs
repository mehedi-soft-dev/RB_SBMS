using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecycleBin.Model.Model
{
    public class SalesView
    {
        public int ProductId { get; set; }
        public string Product { get; set; }
        public int ReOrderLevel { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double MRP { get; set; }
        public double Profit { get; set; }
    }
}
