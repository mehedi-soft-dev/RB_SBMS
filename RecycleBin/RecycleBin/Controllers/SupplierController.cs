using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using RecycleBin.Manager.Manager;
using RecycleBin.Model.Model;
using RecycleBin.Models;
using Rotativa;

namespace RecycleBin.Controllers
{
    public class SupplierController : Controller
    {
        SupplierManager _supplierManager = new SupplierManager();

        [HttpGet]
        public ActionResult Add()
        {
            SupplierViewModel supplierViewModel = new SupplierViewModel();
            supplierViewModel.Suppliers = _supplierManager.GetAll();
            return View(supplierViewModel);
        }

        [HttpPost]
        public ActionResult Add(SupplierViewModel supplierViewModel)
        {
            Supplier supplier = Mapper.Map<Supplier>(supplierViewModel);

            string message = "";
            if (ModelState.IsValid)
            {
                if (_supplierManager.Add(supplier))
                {
                    message = "Supplier Saved Successfully";
                }
                else
                {
                    message = "Failed";
                }
            }
            else
            {
                ViewBag.ModelSateMessage = "Model State Failed";
            }

            ViewBag.Message = message;
            supplierViewModel.Suppliers = _supplierManager.GetAll();
            return View(supplierViewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Supplier supplier = _supplierManager.GetById(id);
            SupplierViewModel supplierViewModel = Mapper.Map<SupplierViewModel>(supplier);

            return View(supplierViewModel);
        }

        [HttpPost]
        public ActionResult Edit(SupplierViewModel supplierViewModel)
        {
            Supplier supplier = Mapper.Map<Supplier>(supplierViewModel);
            string message = "";
            if (ModelState.IsValid)
            {
                if (_supplierManager.Upadate(supplier))
                {
                    message = "Updated Successfully...!";
                }
                else
                {
                    message = "Not Updated...!";
                }
            }
            else
            {
                ViewBag.Message = "Model state failed..!";
            }


            return View(supplierViewModel);

        }

        public ActionResult PrintViewToPdf()
        {
            var report = new ActionAsPdf("Add");
            return report;
        }

        public JsonResult IsCodeExist(string code)
        {
            var result = _supplierManager.IsCodeExist(code);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}