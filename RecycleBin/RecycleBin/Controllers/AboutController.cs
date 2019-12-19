using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecycleBin.Controllers
{
    public class AboutController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}