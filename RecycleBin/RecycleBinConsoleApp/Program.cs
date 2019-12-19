using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecycleBin.Manager.Manager;
using RecycleBin.Model.Model;

namespace RecycleBinConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            //---------Add---------
            //Category category = new Category()
            //{
            //    Code = "C002", Name = "Computer"
            //};

            CategoryManager _categoryManager = new CategoryManager();

            //if (_categoryManager.Add(category))
            //{
            //    Console.WriteLine("Saved");
            //}
            //else
            //{
            //    Console.WriteLine("Not Saved");
            //}
            //-----Show All------
            //foreach (var aCategory in _categoryManager.GetAll())
            //{
            //    Console.WriteLine($"Code : {aCategory.Code} Name : {aCategory.Name}");
            //}

            //-------Remove---------
            //if(_categoryManager.Remove(2))
            //    Console.WriteLine("Removed");
            //else
            //    Console.WriteLine("Not Removed");

            //------Get By Id------
            //Category aCategory = _categoryManager.GetById(2);
            //if(aCategory != null)
            //    Console.WriteLine($"Code : {aCategory.Code} Name : {aCategory.Name}");
            //else
            //    Console.WriteLine("No Data Found");

            //-------Update---------
            //-------Method 1
            //Category category = new Category()
            //{
            //    Id = 1, Code = "CT01", Name = "Mobile"
            //};

            //----------Method 2
            //var aCategory = _categoryManager.GetById(1);
            //if (aCategory != null)
            //{
            //    aCategory.Code = "CM01";
            //    aCategory.Name = "Mobile";

            //    if (_categoryManager.Upadate(aCategory))
            //        Console.WriteLine("Updated");
            //    else
            //        Console.WriteLine("Not Updated");
            //}
            //else 
            //    Console.WriteLine("No Data Found");
            //---------Insert Related Data------------
            //Category category = new Category()
            //{
            //    Code = "CC01",
            //    Name = "Computer",
            //    Products = new List<Product>()
            //    {
            //        new Product()
            //        {
            //            Code = "HKZV",
            //            Name = "Hp Probook 403",
            //            ReOrderLevel = 5,
            //            Description = "Core i5, 4GB RAM, 2TB HDD"
            //        },

            //        new Product()
            //        {
            //            Code = "DKSP",
            //            Name = "Dell Inspiron 556",
            //            ReOrderLevel = 5,
            //            Description = "Core i3, 4GB RAM, 1TB HDD"
            //        }
            //    }
                
            //};

            //if(_categoryManager.Add(category))
            //    Console.WriteLine("Data Added");
            //else
            //{
            //    Console.WriteLine("Not Added");
            //}

            Product product = new Product()
            {
                Code = "SMGC",
                Name = "Samsung Note 10",
                ReOrderLevel = 5,
                Description = "Premium Quality Flagship Phone"
                
            };

            

            Console.ReadKey();
        }
    }
}
