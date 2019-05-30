using AbstractFlowerShopServiceDAL1.ViewModel;
using AbstractFlowerShopServiceDAL1.BindingModel;
using System.Collections.Generic;
using AbstractFlowerShopServiceDAL1.Attributies;

namespace AbstractFlowerShopServiceDAL1.Interfaces
{
    [CustomInterface("Интерфейс для работы с заказами")]
    public interface IServiceMain
    {
        [CustomMethod("Метод получения списка заказов")]
        List<BookingViewModel> ListGet();
        [CustomMethod("Метод получения списка ")]
        List<BookingViewModel> GetFreeBookings();
        [CustomMethod("Метод создания заказа")]
        void CreateBooking(BookingBindingModel model);
        [CustomMethod("Метод выполнения заказа")]
        void TakeBookingInWork(BookingBindingModel model);
        [CustomMethod("Метод завершения выполнения заказа")]
        void FinishBooking(BookingBindingModel model);
        [CustomMethod("Метод оплаты заказа")]
        void PayBooking(BookingBindingModel model);
        [CustomMethod("Метод пополнения склада")]
        void PutElementOnStorage(StorageElementBindingModel model);
    }
}
