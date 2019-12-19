using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecycleBin.Model.Model
{
    public class SalesDetails
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double MRP { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int SalesId { get; set; }
        public Sales Sales { get; set; }

    }
}
