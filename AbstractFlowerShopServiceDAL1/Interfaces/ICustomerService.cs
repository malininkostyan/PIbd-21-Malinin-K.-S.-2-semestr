using AbstractFlowerShopServiceDAL1.Attributies;
using AbstractFlowerShopServiceDAL1.BindingModel;
using AbstractFlowerShopServiceDAL1.ViewModel;
using System.Collections.Generic;

namespace AbstractFlowerShopServiceDAL1.Interfaces
{
    [CustomInterface("Интерфейс для работы с клиентами")]
    public interface ICustomerService
    {
        [CustomMethod("Метод получения списка клиентов")]
        List<CustomerViewModel> ListGet();
        [CustomMethod("Метод получения клиента по id")]
        CustomerViewModel ElementGet(int id);
        [CustomMethod("Метод добавления клиента")]
        void AddElement(CustomerBindingModel model);
        [CustomMethod("Метод изменения данных по клиенту")]
        void UpdateElement(CustomerBindingModel model);
        [CustomMethod("Метод удаления клиента")]
        void DeleteElement(int id);
    }   
}
