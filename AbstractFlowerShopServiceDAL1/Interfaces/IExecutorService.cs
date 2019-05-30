using AbstractFlowerShopServiceDAL1.Attributies;
using AbstractFlowerShopServiceDAL1.BindingModel;
using AbstractFlowerShopServiceDAL1.ViewModel;
using System.Collections.Generic;

namespace AbstractFlowerShopServiceDAL1.Interfaces
{
    [CustomInterface("Интерфейс для работы с работниками")]
    public interface IExecutorService
    {
        [CustomMethod("Метод получения списка работников")]
        List<ExecutorViewModel> ListGet();
        [CustomMethod("Метод получения работника по id")]
        ExecutorViewModel ElementGet(int id);
        [CustomMethod("Метод добавления работника")]
        void AddElement(ExecutorBindingModel model);
        [CustomMethod("Метод изменения данных по работнику")]
        void UpdateElement(ExecutorBindingModel model);
        [CustomMethod("Метод удаления работника")]
        void DeleteElement(int id);
        [CustomMethod("Метод получения свободного работника")]
        ExecutorViewModel GetFreeWorker();
    }
}
