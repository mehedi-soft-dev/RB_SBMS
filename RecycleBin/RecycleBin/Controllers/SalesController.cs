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
    public class SalesController : Controller
    {

        CustomerManager _customerManager = new CustomerManager();
        CategoryManager _categoryManager = new CategoryManager();
        ProductManager _productManager = new ProductManager();
        SalesManager _salesManager = new SalesManager();
        PurchaseManager _purchaseManager = new PurchaseManager();

        // GET: Sales
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            SalesViewModel salesViewModel = new SalesViewModel();
            salesViewModel.CustomerSelectListItems = _customerManager
                                                    .GetAll()
                                                    .Select(c => new SelectListItem()
                                                        {
                                                            Value = c.Id.ToString(),
                                                            Text = c.Name
                                                        }
                                                    ).ToList();

            salesViewModel.CategorySelectListItems = _categoryManager
                                                    .GetAll()
                                                    .Select(c => new SelectListItem()
                                                        {
                                                            Value = c.Id.ToString(),
                                                            Text = c.Name
                                                        }
                                                    ).ToList();

            
            return View(salesViewModel);
        }

        [HttpPost]
        public void Add(Sales sales)
        {
            string message = "";

            if (_salesManager.Add(sales))
            {
                message = "Sales Completed Successfully";
            }
            else
            {
                message = "Failed";
            }

            ViewBag.Message = message;

            Add();
        }

        [HttpGet]
        public ActionResult ViewSalesReport()
        {
            SalesViewModel salesViewModel = new SalesViewModel();
            salesViewModel.Saleses = _salesManager.GetAll();

            return View(salesViewModel);
        }
        [HttpGet]
        public PartialViewResult ViewSalesDetails(int salesId)
        {
            SalesViewModel salesViewModel = new SalesViewModel();
            Sales sales = new Sales();
            sales = _salesManager.GetSalesById(salesId);

            salesViewModel.Date = sales.Date;
            salesViewModel.Customer = sales.Customer;
            salesViewModel.DiscountPercentage = sales.DiscountPercentage;
            salesViewModel.SalesDetailses = _salesManager.GetSalesDetailsesById(salesId);
            return PartialView("ViewSalesDetails", salesViewModel);
        }

        public JsonResult GetProductByCategoryId(int categoryId)
        {
            var productList = _productManager
                .GetAll()
                .Where(c => c.CategoryId == categoryId)
                .Select(c => new
                {
                    c.Id,
                    c.Name
                });

            return Json(productList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCustomerDetailsById(int customerId)
        {
            Customer customer = _customerManager.GetById(customerId);

            return Json(customer, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProductDetailsById(int productId)
        {
            Product product = _productManager.GetById(productId);

            return Json(product, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateCustomer(int customerId, int point)
        {
            Customer cus = _customerManager.GetById(customerId);
            cus.LoyalityPoint = point;
            _customerManager.Upadate(cus);
            return Json(0, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetLastUnitPrice(int productId)
        {
            var result = (from t in _purchaseManager.GetAllPurchaseDetails()
                where t.ProductId == productId
                orderby t.Id descending
                select new { LastUnitPrice = t.UnitPrice }).First();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}