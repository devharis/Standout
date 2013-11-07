using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SWTS.Models
{
    public class SupplierContext : DbContext
    {
        public SupplierContext()
            : base("name=DefaultConnection")
        {
            this.Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Supplier>().ToTable("Supplier");
        }
    }
}