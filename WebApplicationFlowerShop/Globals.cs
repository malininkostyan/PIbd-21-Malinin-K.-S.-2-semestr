using AbstractFlowerShopServiceDAL.Interfaces;
using AbstractFlowerShopServiceImplementDataBase;
using AbstractFlowerShopServiceImplementDataBase.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationFlowerShop
{
    public class Globals
    {
        public static AbstractContextDb DbContext { get; } = new AbstractContextDb();
        public static ICustomerService CustomerService { get; } = new CustomerServiceDB(DbContext);
        public static IElementService ElementService { get; } = new ElementServiceDB(DbContext);
        public static IBouquetService BouquetService { get; } = new BouquetServiceDB(DbContext);
        public static IServiceMain MainService { get; } = new ServiceMainDB(DbContext);
        public static IStorageService StorageService { get; } = new StorageServiceDB(DbContext);
    }
}