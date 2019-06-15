using AbstractFlowerShopServiceDAL.Interfaces;
using AbstractFlowerShopServiceImplementList.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationFlowerShop
{
    public class Globals
    {
        public static ICustomerService CustomerService { get; } = new CustomerServiceList();
        public static IElementService ElementService { get; } = new ElementServiceList();
        public static IBouquetService BouquetService { get; } = new BouquetServiceList();
        public static IServiceMain MainService { get; } = new ServiceMainList();
    }
}