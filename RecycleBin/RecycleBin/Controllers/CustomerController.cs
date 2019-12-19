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
    public class CustomerController : Controller
    {
        CustomerManager _customerManager = new CustomerManager();

        [HttpGet]
        public ActionResult Add()
        {
            CustomerViewModel customerViewModel = new CustomerViewModel();
            customerViewModel.Customers = _customerManager.GetAll();
            return View(customerViewModel);
        }

        [HttpPost]
        public ActionResult Add(CustomerViewModel customerViewModel)
        {
            Customer customer = Mapper.Map<Customer>(customerViewModel);
            string message = "";
            if (ModelState.IsValid)
            {
                if (_customerManager.Add(customer))
                {
                    message = "Customer Added Successfully";
                }
                else
                {
                    message = "Failed";
                }
            }
            else
            {
                ViewBag.ModelStateMessage = "Model State Faile";
            }

            ViewBag.Message = message;
            customerViewModel.Customers = _customerManager.GetAll();
            return View(customerViewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Customer customer = _customerManager.GetById(id);
            CustomerViewModel customerViewModel = Mapper.Map<CustomerViewModel>(customer);

            return View(customerViewModel);
        }

        [HttpPost]
        public ActionResult Edit(CustomerViewModel customerViewModel)
        {
            Customer customer = Mapper.Map<Customer>(customerViewModel);
            string message = "";
            if (ModelState.IsValid)
            {
                if (_customerManager.Upadate(customer))
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


            return View(customerViewModel);

        }

        public ActionResult PrintViewToPdf()
        {
            var report = new ActionAsPdf("Add");
            return report;
        }

        public JsonResult IsCodeExist(string code)
        {
            var result = _customerManager.IsCodeExist(code);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}