using AbstractFlowerShopModel1;
using System.Data.Entity;

namespace AbstractFlowerShopServiceImplementDataBase
{
    public class AbstractContextDb : DbContext
    {
        public AbstractContextDb() : base("AbstractFlowerDatabase")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Element> Elements { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Bouquet> Bouquets { get; set; }
        public virtual DbSet<BouquetElement> BouquetElements { get; set; }
        public virtual DbSet<Storage> Storages { get; set; }
        public virtual DbSet<StorageElement> StorageElements { get; set; }
        public virtual DbSet<Executor> Executors { get; set; }
    }
}
