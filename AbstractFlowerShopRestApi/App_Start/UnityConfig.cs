using AbstractFlowerShopServiceDAL1.Interfaces;
using AbstractFlowerShopServiceImplementDataBase;
using AbstractFlowerShopServiceImplementDataBase.Implementations;
using System;
using System.Data.Entity;
using Unity;
using Unity.Lifetime;

namespace AbstractFlowerShopRestApi
{
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
        new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });
       
        public static IUnityContainer Container => container.Value;
        #endregion

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<DbContext, AbstractContextDb>(new
            HierarchicalLifetimeManager());
            container.RegisterType<ICustomerService, CustomerServiceDB>(new
            HierarchicalLifetimeManager());
            container.RegisterType<IElementService, ElementServiceDB>(new
            HierarchicalLifetimeManager());
            container.RegisterType<IBouquetService, BouquetServiceDB>(new
            HierarchicalLifetimeManager());
            container.RegisterType<IStorageService, StorageServiceDB>(new
            HierarchicalLifetimeManager());
            container.RegisterType<IServiceMain, ServiceMainDB>(new
            HierarchicalLifetimeManager());
            container.RegisterType<ILogService, LogServiceDB>(new
            HierarchicalLifetimeManager());
        }
    }
}