using System.Collections.Generic;

namespace SWTS.Models.Interface
{
    public interface ISupplierService
    {
        List<Supplier> GetAllSuppliers();
        Supplier GetSupplier(int id);
        Supplier AddSupplier(Supplier supplier);
    }
}