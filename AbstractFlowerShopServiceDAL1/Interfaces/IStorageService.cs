using AbstractFlowerShopServiceDAL1.BindingModel;
using AbstractFlowerShopServiceDAL1.ViewModel;
using System.Collections.Generic;

namespace AbstractFlowerShopServiceDAL1.Interfaces
{
    public interface IStorageService
    {
        List<StorageViewModel> ListGet();
        StorageViewModel ElementGet(int id);
        void AddElement(StorageBindingModel model);
        void UpdateElement(StorageBindingModel model);
        void DeleteElement(int id);
    }

}
