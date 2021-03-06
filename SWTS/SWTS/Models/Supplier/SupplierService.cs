﻿using System.Collections.Generic;
using System.Linq;
using SWTS.Models.Interface;

namespace SWTS.Models
{
    /// <summary>
    ///  This class represents all specific CRUD functionality which uses
    ///  methods fom ISupplierService which it inherits from.
    /// </summary>
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _repository;

        public List<Supplier> GetAllSuppliers()
        {
            return this._repository.Query<Supplier>().ToList();
        }

        public Supplier GetSupplier(int id)
        {
            var supplier = this._repository.Find<Supplier>(o => o.SupplierId == id);
            return supplier;
        }

        public Supplier AddSupplier(Supplier supplier)
        {
            this._repository.Add(supplier);
            this._repository.Save();
            return this._repository.Query<Supplier>().FirstOrDefault(o => o.Name == supplier.Name);
        }

        public void DeleteSupplier(int id)
        {
            var supplier = this._repository.Find<Supplier>(o => o.SupplierId == id);
            this._repository.Delete(supplier);
            this._repository.Save();
        }

        public void Update(Supplier supplier)
        {
            this._repository.Update(supplier);
            this._repository.Save();
        }
    }
}