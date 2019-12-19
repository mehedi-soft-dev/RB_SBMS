using RecycleBin.Model.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Web;
using System.Web.Mvc;

namespace RecycleBin.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Product Code")]
        [MaxLength(4, ErrorMessage = "Code must be 4 Charecter")]
        [MinLength(4, ErrorMessage = "Code must be 4 charecter")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Please Enter Product Name")]
        [MaxLength(20, ErrorMessage = "Maximum 20 Charecter")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Product Re-Order Level")]
        [Range(5,50,ErrorMessage = "Re-Order Level should between 5 and 50")]
        [Display(Name = "Re-Order Level")]
        public int ReOrderLevel { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Please Select an Category")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public List<Product> Products { get; set; }

        //[Required(ErrorMessage ="Please Select Category")]
        public List<SelectListItem> CategorySelectListItems { get; set; }
    }
}