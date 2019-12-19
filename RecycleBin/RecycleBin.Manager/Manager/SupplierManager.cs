using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecycleBin.Model.Model;
using RecycleBin.Repository.Repository;

namespace RecycleBin.Manager.Manager
{
    public class SupplierManager
    {
        SupplierRepository _supplierRepository = new SupplierRepository();

        public bool Add(Supplier supplier)
        {
            return _supplierRepository.Add(supplier);
        }

        public List<Supplier> GetAll()
        {
            return _supplierRepository.GetAll();
        }

        public Supplier GetById(int id)
        {
            return _supplierRepository.GetById(id);
        }

        public bool Upadate(Supplier supplier)
        {
            return _supplierRepository.Upadate(supplier);
        }

        public bool IsCodeExist(string code)
        {
            return _supplierRepository.IsCodeExist(code);
        }
    }
}
