using AbstractFlowerShopServiceDAL1.Attributies;
using AbstractFlowerShopServiceDAL1.BindingModel;
using AbstractFlowerShopServiceDAL1.ViewModel;
using System.Collections.Generic;

namespace AbstractFlowerShopServiceDAL1.Interfaces
{
    [CustomInterface("Интерфейс для работы с отчетами")]
    public interface ILogService
    {
        [CustomMethod("Метод сохранения цены букета")]
        void SaveBouquetPrice(LogBindingModel model);
        [CustomMethod("Метод получения информации о складе")]
        List<LoadStoragesViewModel> GetStoragesLoad();
        [CustomMethod("Метод сохранения информации о складе")]
        void SaveStoragesLoad(LogBindingModel model);
        [CustomMethod("Метод получения информации о заказе")]
        List<CustomerBookingViewModel> GetCustomerBookings(LogBindingModel model);
        [CustomMethod("Метод сохранения информации о заказе")]
        void SaveCustomerBookings(LogBindingModel model);
    }
}
