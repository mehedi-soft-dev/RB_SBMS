using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecycleBin.Model.Model;
using RecycleBin.Repository;

namespace RecycleBin.Manager.Manager
{
    public class ReportManager
    {
        ReportRepository _reportRepository = new ReportRepository();

        public List<PurchaseView> GetExpenseReportOnPurchse()
        {
            return _reportRepository.GetExpenseReportOnPurchse();
        }

        public List<PurchaseView> GetExpenseReportOnSales()
        {
            return _reportRepository.GetExpenseReportOnSales();
        }

    }
}
