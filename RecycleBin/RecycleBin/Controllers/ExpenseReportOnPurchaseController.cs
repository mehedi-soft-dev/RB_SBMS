using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecycleBin.Manager.Manager;
using RecycleBin.Model.Model;
using RecycleBin.Models;

namespace RecycleBin.Controllers
{
    public class ExpenseReportOnPurchaseController : Controller
    {
        ReportManager _reportManager = new ReportManager();

        [HttpGet]
        public ActionResult ViewExpenseReoprtOnPurchase()
        {
            PurchaseViewModel purchaseViewModel = new PurchaseViewModel();

            purchaseViewModel.PurchaseViews = _reportManager.GetExpenseReportOnPurchse();

            return View(purchaseViewModel);
        }

       
    }
}