using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SWTS.Models
{
    /// <summary>
    ///  This class is a context which uses the connection and checks
    ///  which tables to use in the database. 
    ///  It initalize the connection in a short sentence.
    /// </summary>
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