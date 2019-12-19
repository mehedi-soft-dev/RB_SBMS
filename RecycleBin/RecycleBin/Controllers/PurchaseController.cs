using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecycleBin.Manager.Manager;
using RecycleBin.Model.Model;
using RecycleBin.Models;
using Rotativa;

namespace RecycleBin.Controllers
{
    public class PurchaseController : Controller
    {
        CategoryManager _categoryManager = new CategoryManager();
        ProductManager _productManager = new ProductManager();
        SupplierManager _supplierManager = new SupplierManager();
        PurchaseManager _purchaseManager = new PurchaseManager();
        SalesManager _salesManager = new SalesManager();
        
        [HttpGet]
        public ActionResult Add()
        {
            PurchaseViewModel purchaseViewModel = new PurchaseViewModel();
            purchaseViewModel.SupplierSelectListItems = _supplierManager
                                                        .GetAll()
                                                        .Select(c => new SelectListItem()
                                                            {
                                                                Value = c.Id.ToString(),
                                                                Text = c.Name
                                                            }
                                                        ).ToList();
            purchaseViewModel.CategorySelectListItems = _categoryManager
                                                        .GetAll()
                                                        .Select(c => new SelectListItem()
                                                            {
                                                                Value = c.Id.ToString(),
                                                                Text = c.Name
                                                            }
                                                        ).ToList();

            purchaseViewModel.ProductSelectListItems = _productManager
                                                        .GetAll()
                                                        .Select(c => new SelectListItem()
                                                            {
                                                                Value = c.Id.ToString(),
                                                                Text = c.Name
                                                            }
                                                        ).ToList();
            return View(purchaseViewModel);
        }

        [HttpPost]
        public void Add(Purchase purchase)
        {
            string message = "";
            if (_purchaseManager.Add(purchase))
            {
                message = "Added Successfully";
            }
            else
            {
                message = "Failed";
            }

            Add();
        }

        [HttpGet]
        public ActionResult ViewPurchaseReport()
        {
            PurchaseViewModel purchaseViewModel = new PurchaseViewModel();
            purchaseViewModel.Purchases = _purchaseManager.GetAll();

            return View(purchaseViewModel);
        }


        [HttpGet]
        public PartialViewResult ViewPurchaseDetails(int purchaseId)
        {
            PurchaseViewModel purchaseViewModel = new PurchaseViewModel();
            Purchase purchase = new Purchase();
            purchase = _purchaseManager.GetPurchaseById(purchaseId);

            purchaseViewModel.Date = purchase.Date;
            purchaseViewModel.InvoiceNo = purchase.InvoiceNo;
            purchaseViewModel.Supplier = purchase.Supplier;
            purchaseViewModel.PurchaseDetailses = _purchaseManager.GetPurchaseDetailsById(purchaseId);
            return PartialView("ViewPurchaseDetails", purchaseViewModel);
        }

        public JsonResult GetProductByCategory(int categoryId)
        {
            var productList = _productManager
                .GetAll()
                .Where(c=>c.CategoryId == categoryId)
                .Select(c => new
                {
                    c.Id,
                    c.Name,
                }).ToList();

            return Json(productList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProductDetailsById(int productId)
        {
            var productDetails = _productManager.GetById(productId);

            return Json(productDetails, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTotalPurchaseQuantity(int productId)
        {
            int purchaseQuantity = _purchaseManager.GetTotalPurchaseQuantity(productId);
            int salesQuantity = _salesManager.GetTotalSaleQuantity(productId);
            int availableQuantity = purchaseQuantity - salesQuantity;
            return Json(availableQuantity, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProductMRP(int productId)
        {
            double MRP = _purchaseManager.GetMRP(productId);
            return Json(MRP, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPreviousInfo(int productId)
        {
            var result = (from t in _purchaseManager.GetAllPurchaseDetails()
                where t.ProductId == productId
                orderby t.Id descending select new {PreviousUnitPrice = t.UnitPrice, PreviousMRP = t.MRP}).First();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PrintViewToPdf()
        {
            var report = new ActionAsPdf("ViewPurchaseReport");
            return report;
        }
    }
}