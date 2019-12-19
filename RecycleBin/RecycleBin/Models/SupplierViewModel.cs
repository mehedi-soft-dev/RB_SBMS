using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using RecycleBin.Model.Model;

namespace RecycleBin.Models
{
    public class SupplierViewModel
    {
        public int Id { set; get; }

        [Required(ErrorMessage = "Please Enter Supplier Code")]
        [MaxLength(4, ErrorMessage = "Must be 4 Charecter")]
        [MinLength(4, ErrorMessage = "Must be 4 Charecter")]
        public string Code { set; get; }

        [Required(ErrorMessage = "Please Enter Supplier Name")]
        [MaxLength(30,ErrorMessage = "Maximum 30 Charecter")]
        public string Name { set; get; }

        public string Address { set; get; }

        [Required(ErrorMessage = "Please Enter Supplier Contact Number")]
        public string Contact { set; get; }

        [EmailAddress(ErrorMessage = "Please Enter a valid Email")]
        public string Email { set; get; }

        [Required(ErrorMessage = "Please Enter Contact Person")]
        public string ContactPerson { set; get; }
        public List<Supplier> Suppliers { set; get; }
    }
}