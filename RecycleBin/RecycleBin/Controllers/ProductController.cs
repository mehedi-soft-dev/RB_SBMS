using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using RecycleBin.Model.Model;
using RecycleBin.Models;
using RecycleBin.Manager.Manager;
using Rotativa;

namespace RecycleBin.Controllers
{
    public class ProductController : Controller
    {
        ProductManager _productManager = new ProductManager();
        CategoryManager _categoryManager = new CategoryManager();

        [HttpGet]
        public ActionResult Add()
        {
            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.Products = _productManager.GetAll();
            productViewModel.CategorySelectListItems = _categoryManager
                .GetAll()
                .Select(c => new SelectListItem()
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    }
                ).ToList();
            return View(productViewModel);
        }

        [HttpPost]
        public ActionResult Add(ProductViewModel productViewModel)
        {

            string message = "";
            if (ModelState.IsValid)
            {
                Product product = Mapper.Map<Product>(productViewModel);

                if (_productManager.Add(product))
                {
                    message = "Product Saved Successfully";
                }
                else
                {
                    message = "Failed";
                }
            }
            else
            {
                ViewBag.ModelStateMessage = "Model State Failed";
            }

            ViewBag.Messagee = message;
            productViewModel.Products = _productManager.GetAll();
            productViewModel.CategorySelectListItems = _categoryManager
                .GetAll()
                .Select(c => new SelectListItem()
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    }
                ).ToList();
            return View(productViewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Product products = _productManager.GetById(id);
            ProductViewModel productViewModel = Mapper.Map<ProductViewModel>(products);
            productViewModel.CategorySelectListItems = _categoryManager
                .GetAll()
                .Select(c => new SelectListItem()
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    }
                ).ToList();
            return View(productViewModel);

        }

        [HttpPost]
        public ActionResult Edit(ProductViewModel productViewModel)
        {
            Product product = Mapper.Map<Product>(productViewModel);
            string message = "";
            if (ModelState.IsValid)
            {
                if (_productManager.Update(product))
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

            productViewModel.CategorySelectListItems = _categoryManager
                .GetAll()
                .Select(c => new SelectListItem()
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    }
                ).ToList();
            return View(productViewModel);

        }

        public ActionResult PrintViewToPdf()
        {
            var report = new ActionAsPdf("Add");
            return report;
        }

        public JsonResult IsCodeExist(string code)
        {
            var result = _productManager.IsCodeExist(code);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}