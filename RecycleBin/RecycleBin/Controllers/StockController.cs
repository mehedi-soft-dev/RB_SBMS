using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecycleBin.Manager.Manager;
using RecycleBin.Model.Model;
using RecycleBin.Models;
using Rotativa;

namespace RecycleBin.Controllers
{
    public class StockController : Controller
    {
        PurchaseManager _purchaseManager = new PurchaseManager();
        SalesManager _salesManager = new SalesManager();
        ProductManager _productManager = new ProductManager();
        StockManger _stockManger = new StockManger();

        [HttpGet]
        public ActionResult StockView()
        {
            StockViewModel stockViewModel = new StockViewModel();

            

            stockViewModel.StockViews = _stockManger.ViewStock();

            
            return View(stockViewModel);
        }

        [HttpPost]
        public ActionResult StockView(DateTime startDate, DateTime endDate)
        {
            StockViewModel stockViewModel = new StockViewModel();

            stockViewModel.StockViews = _stockManger.ViewStockByDate(startDate, endDate);
            return View(stockViewModel);
        }

        private int GetOpeningBalance(int id, DateTime date)
        {
            var r = _purchaseManager.GetAll().Where(c => c.Date < date);
            int sum = 0;

            foreach (var pr in r)
            {
                sum += pr.PurchaseDetailses.Sum(c => c.Quantity);
            }

            return sum;
        }

        public ActionResult PrintViewToPdf()
        {
            var report = new ActionAsPdf("Add");
            return report;
        }
    }
}