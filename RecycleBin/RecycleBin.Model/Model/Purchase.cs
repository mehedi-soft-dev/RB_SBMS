using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecycleBin.Model.Model
{
    public class Purchase
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string InvoiceNo { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        public List<PurchaseDetails> PurchaseDetailses { get; set; }
    }
}
