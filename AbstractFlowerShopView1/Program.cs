using AbstractFlowerShopServiceDAL1.Interfaces;
using AbstractFlowerShopServiceImplementDataBase;
using AbstractFlowerShopServiceImplementDataBase.Implementations;
using System;
using System.Data.Entity;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace AbstractFlowerShopView1
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<MainForm>());
        }
        public static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<DbContext, AbstractContextDb>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<ICustomerService, CustomerServiceDB>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IElementService, ElementServiceDB>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IBouquetService, BouquetServiceDB>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IStorageService, StorageServiceDB>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<IServiceMain, ServiceMainDB>(new
            HierarchicalLifetimeManager());
            currentContainer.RegisterType<ILogService, LogServiceDB>(new
            HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}