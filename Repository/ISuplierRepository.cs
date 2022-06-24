using Pharmacy_Management1.Models;

using System.Collections.Generic;

namespace Pharmacy_Management1.Repository
{
    public interface ISuplierRepository
    {
        SupplierDetail Create(SupplierDetail supplierDetail);
        IEnumerable<SupplierDetail> GetAll();

        SupplierDetail GetSupplier(int id);
        void DeleteSupplier(int id);
        void UpdateSupplier(SupplierDetail supplierDetail);
    }
}