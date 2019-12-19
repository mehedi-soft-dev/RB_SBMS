using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecycleBin.Model.Model
{
    public class StockView
    {
      public string Product { get; set; }
      public int ProductId { get; set; }
      public int ReOrderLevel { get; set; }
      public int OpeningBalance { get; set; }
      public int StockIn { get; set; }
      public int StockOut { get; set; }
      public int ClosingBalance { get; set; }
    }
}
