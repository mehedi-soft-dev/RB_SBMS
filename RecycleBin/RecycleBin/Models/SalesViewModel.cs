using RecycleBin.Model.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecycleBin.Models
{
    public class SalesViewModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string BillNo { get; set; }

        [Display(Name = "Available Quantity")]
        public int AvailableQuantity { get; set; }

        [Range(1,Int32.MaxValue, ErrorMessage = "Invalid Quantity")]
        public int Quantity { get; set; }

        [Display(Name = "M.R.P (TK.)")]
        public double MRP { get; set; }

        [Display(Name = "Total M.R.P (TK.)")]
        public double TotalMRP { get; set; }

        [Display(Name = "Grand Total")]
        public double GrandTotal { get; set; }

        [Display(Name = "Discount (%)")]
        public double DiscountPercentage { get; set; }

        [Display(Name = "Discount Ammount")]
        public double DiscountAmmount { get; set; }

        [Display(Name = "Payable Ammount")]
        public double PayableAmmount { get; set; }

        [Display(Name = "Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [Display(Name = "Loyalty Point")]
        public double LoyalityPoint { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [Display(Name = "Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int SalesId { get; set; }
        public List<Sales> Saleses { get; set; }
        public List<SalesView> SalesViews = new List<SalesView>();

        public IEnumerable<SelectListItem> CustomerSelectListItems { get; set; }
        public IEnumerable<SelectListItem> CategorySelectListItems { get; set; }
        public IEnumerable<SelectListItem> ProductSelectListItems { get; set; }

        public List<SalesDetails> SalesDetailses { get; set; }

    }
}