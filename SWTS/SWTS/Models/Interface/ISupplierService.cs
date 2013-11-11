using System.Collections.Generic;

namespace SWTS.Models.Interface
{
    /// <summary>
    ///  This interface represent method stubs for SupplerService
    /// </summary>
    public interface ISupplierService
    {
        List<Supplier> GetAllSuppliers();
        Supplier GetSupplier(int id);
        Supplier AddSupplier(Supplier supplier);
        void DeleteSupplier(int id);
        void Update(Supplier supplier);
    }
}