using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using DataAnnotationsValidations.Attributes;
using RecycleBin.Manager.Manager;
using RecycleBin.Model.Model;
using static CustomValidation;

namespace RecycleBin.Models
{
    public class CategoryViewModel
    {
        

        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Category Code")]
        [MaxLength(4, ErrorMessage = "Must be 4 charecter")]
        [MinLength(4, ErrorMessage = "Must be 4 charecter")]
        [Display(Name = "Code")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Please Enter Category Name")]
        [MaxLength(30,ErrorMessage = "Maximum 30 charecter")]
        public string Name { get; set; }

        public List<Product> Products { get; set; }

        public List<Category> Categories { get; set; }

        public CategoryViewModel()
        {
            Categories = new List<Category>();
        }
    }

}