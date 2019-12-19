using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using RecycleBin.Model.Model;
using RecycleBin.Models;

namespace RecycleBin
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<CategoryViewModel, Category>();
                cfg.CreateMap<Category, CategoryViewModel>();

                cfg.CreateMap<ProductViewModel, Product>();
                cfg.CreateMap<Product, ProductViewModel>();

                cfg.CreateMap<CustomerViewModel, Customer>();
                cfg.CreateMap<Customer, CustomerViewModel>();

                cfg.CreateMap<SupplierViewModel, Supplier>();
                cfg.CreateMap<Supplier, SupplierViewModel>();

                cfg.CreateMap<PurchaseViewModel, Purchase>();
                cfg.CreateMap<Purchase, PurchaseViewModel>();
            });
        }
    }
}
