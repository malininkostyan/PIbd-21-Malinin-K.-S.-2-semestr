using AbstractFlowerShopServiceDAL.BindingModel;
using AbstractFlowerShopServiceDAL.ViewModel;
using System.Collections.Generic;

namespace AbstractFlowerShopServiceDAL.Interfaces
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
