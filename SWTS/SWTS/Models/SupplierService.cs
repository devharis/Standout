using System.Collections.Generic;
using System.Linq;
using SWTS.Models.Interface;

namespace SWTS.Models
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _repository;

        public SupplierService()
            : this(new SupplierRepository())
        {
            // Empty!
        }

        public SupplierService(ISupplierRepository repository)
        {
            this._repository = repository;
        }

        public List<Supplier> GetAllSuppliers()
        {
            return this._repository.Query<Supplier>().ToList();
        }

        public Supplier GetSupplier(int id)
        {
            var supplier = this._repository.Find<Supplier>(o => o.SupplierId == id);
            return supplier;
        }
    }
}