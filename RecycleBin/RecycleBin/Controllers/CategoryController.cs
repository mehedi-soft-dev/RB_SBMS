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
    public class CategoryController : Controller
    {
        CategoryManager _categoryManager = new CategoryManager();

        // GET: Category
        public ActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            CategoryViewModel categoryViewModel = new CategoryViewModel();
            categoryViewModel.Categories = _categoryManager.GetAll();
            return View(categoryViewModel);
        }

        [HttpPost]
        public ActionResult Add(CategoryViewModel categoryViewModel)
        {
            Category category = Mapper.Map<Category>(categoryViewModel);
            string message = "";

            if (ModelState.IsValid)
            {
                if (_categoryManager.Add(category))
                {
                    message = "Saved";
                }
                else
                {
                    message = "Not Saved..!";
                }
            }
            else
            {
                ViewBag.Message = "Model State Failed..!";
            }

            categoryViewModel.Categories = _categoryManager.GetAll();
            return View(categoryViewModel);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Category category = _categoryManager.GetById(id);


            CategoryViewModel categoryViewModel = Mapper.Map<CategoryViewModel>(category);

            return View(categoryViewModel);

        }


        [HttpPost]
        public ActionResult Edit(CategoryViewModel categoryViewModel)
        {
            Category category = Mapper.Map<Category>(categoryViewModel);
            string message = "";
            if (ModelState.IsValid)
            {
                if (_categoryManager.Upadate(category))
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
            categoryViewModel.Categories = _categoryManager.GetAll();
            return View(categoryViewModel);
            
        }

        public JsonResult IsCodeExist(string code)
        {
            var result = _categoryManager.IsCodeExist(code);
                
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PrintViewToPdf()
        {
            var report = new ActionAsPdf("Add");
            return report;
        }

        public ActionResult PrintPartialViewToPdf(CategoryViewModel categoryViewModel)
        {
            var categories = _categoryManager.GetAll();

            categoryViewModel = Mapper.Map<CategoryViewModel>(categories);

            var report = new ActionAsPdf("~/Views/Shared/Category/_categoryDetails");

            return report;
        }

    }
}