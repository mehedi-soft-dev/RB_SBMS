using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using RecycleBin.Model.Model;

namespace RecycleBin.Models
{
    public class CustomerViewModel
    {
        public int ID { set; get; }

        [Required]
        [MaxLength(4, ErrorMessage = "Code must be 4 charecter")]
        [MinLength(4, ErrorMessage = "Code must be 4 charecter")]
        public string Code { set; get; }

        [Required(ErrorMessage = "Please Enter your Name")]
        [MaxLength(30, ErrorMessage = "Maximum 30 Charecter")]
        public string Name { set; get; }


        public string Address { set; get; }

        [Required(ErrorMessage = "Please Enter Contact Number")]
        [MaxLength(15,ErrorMessage = "Please Enter Valid Contact")]
        public string Contact { set; get; }

        [Required(ErrorMessage = "Please Enter your E-mail")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Please Enter a valid Email")]
        public string Email { set; get; }

        [Required(ErrorMessage = "Please Enter Loyality point")]
        [Display(Name = "Loyalty Point")]
        public int LoyalityPoint { set; get; }

        public List<Customer> Customers { set; get; }

        public CustomerViewModel()
        {
            Customers = new List<Customer>();
        }
    }
}