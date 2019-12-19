using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecycleBin.Model.Model;
using RecycleBin.Repository.Repository;

namespace RecycleBin.Manager.Manager
{
    public class ProductManager
    {
        ProductRepository _productRepository = new ProductRepository();

        public bool Add(Product product)
        {
            return _productRepository.Add(product);
        }

        public List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        public bool Update(Product product)
        {
            return _productRepository.Upadate(product);
        }

        public bool IsCodeExist(string code)
        {
            return _productRepository.IsCodeExist(code);
        }
    }
}
