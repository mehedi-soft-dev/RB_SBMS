using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecycleBin.Model.Model
{
    public class PurchaseDetails
    {
        public int Id { get; set; }
        public Nullable<DateTime> ManufacturdeDate { get; set; }
        public Nullable<DateTime> ExpireDate { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double MRP { get; set; }
        public string Remark { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int PurchaseId { get; set; }
        public Purchase Purchase { get; set; }

    }
}
