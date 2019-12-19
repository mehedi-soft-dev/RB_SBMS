using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecycleBin.Model.Model
{
    public class Sales
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string BillNo { get; set; }
        public int DiscountPercentage { get; set; }


        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public List<SalesDetails> SalesDetailses { get; set; }
    }
}
