using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomValidationinMVC.Models;
using RecycleBin.Model.Model;

namespace RecycleBin.Models
{
    public class PurchaseViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Select Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [ShippedDateValidate]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Please Enter Invoice No")]
        [Display(Name = "Invoice No")]
        public string InvoiceNo { get; set; }
        public string Code { get; set; }

        [Display(Name = "Available Quantity")]
        public int AvailableQuantity { get; set; }

        [Required(ErrorMessage = "Please Select Supplier")]
        [Display(Name = "Supplier")]
        public int SupplierId { get; set; }

        public Supplier Supplier;

        [Required(ErrorMessage = "Please SELECT Category")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Required]
        [Display(Name = "Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string ProductName { get; set; }
        public int ReOrderLevel { get; set; }

        [Display(Name = "Previous Unit Price")]
        public double PreviousUnitPrice { get; set; }

        [Display(Name = "Previous MRP")]
        public double PreviousMRP { get; set; }

        [Display(Name = "Total Price")]
        public double TotalPrice { get; set; }

        [Display(Name = "Mf. Date")]
        public Nullable<DateTime> ManufacturedDate { get; set; }

        [Display(Name = "Ex. Date")]
        public Nullable<DateTime> ExpireDate { get; set; }

        [Required(ErrorMessage = "Please Enter Quantity")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Please Enter Quantity")]
        public int Quantity { get; set; }

        [Display(Name = "Unit Price")]
        public double UnitPrice { get; set; }

        [Display(Name = "MRP")]
        public double MRP { get; set; }
        public string Remarks { get; set; }

        public List<PurchaseDetails> PurchaseDetailses { get; set; }
        public List<Purchase> Purchases { get; set; }
        public List<PurchaseView> PurchaseViews = new List<PurchaseView>();

        public IEnumerable<SelectListItem> SupplierSelectListItems { get; set; }

        public IEnumerable<SelectListItem> CategorySelectListItems { get; set; }

        public IEnumerable<SelectListItem> ProductSelectListItems { get; set; }

    }
}