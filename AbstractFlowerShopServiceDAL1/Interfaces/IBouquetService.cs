using AbstractFlowerShopServiceDAL1.Attributies;
using AbstractFlowerShopServiceDAL1.BindingModel;
using AbstractFlowerShopServiceDAL1.ViewModel;
using System.Collections.Generic;

namespace AbstractFlowerShopServiceDAL1.Interfaces
{
    [CustomInterface("Интерфейс для работы с букетами")]
    public interface IBouquetService
    {
        [CustomMethod("Метод получения списка букетов")]
        List<BouquetViewModel> ListGet();
        [CustomMethod("Метод получения букета по id")]
        BouquetViewModel ElementGet(int id);
        [CustomMethod("Метод добавления букета")]
        void AddElement(BouquetBindingModel model);
        [CustomMethod("Метод изменения данных по букету")]
        void UpdateElement(BouquetBindingModel model);
        [CustomMethod("Метод удаления букета")]
        void DeleteElement(int id);

    }
}
