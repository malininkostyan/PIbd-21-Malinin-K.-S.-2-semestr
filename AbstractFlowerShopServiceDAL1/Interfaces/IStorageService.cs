using AbstractFlowerShopServiceDAL1.Attributies;
using AbstractFlowerShopServiceDAL1.BindingModel;
using AbstractFlowerShopServiceDAL1.ViewModel;
using System.Collections.Generic;

namespace AbstractFlowerShopServiceDAL1.Interfaces
{
    [CustomInterface("Интерфейс для работы со складами")]
    public interface IStorageService
    {
        [CustomMethod("Метод получения списка складов")]
        List<StorageViewModel> ListGet();
        [CustomMethod("Метод получения склада по id")]
        StorageViewModel ElementGet(int id);
        [CustomMethod("Метод добавления склада")]
        void AddElement(StorageBindingModel model);
        [CustomMethod("Метод изменения данных по складу")]
        void UpdateElement(StorageBindingModel model);
        [CustomMethod("Метод удаления склада")]
        void DeleteElement(int id);
    }

}
