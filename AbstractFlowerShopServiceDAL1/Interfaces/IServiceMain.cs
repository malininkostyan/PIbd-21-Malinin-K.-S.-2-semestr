using AbstractFlowerShopServiceDAL1.ViewModel;
using AbstractFlowerShopServiceDAL1.BindingModel;
using System.Collections.Generic;

namespace AbstractFlowerShopServiceDAL1.Interfaces
{
    public interface IServiceMain
    {
        List<BookingViewModel> ListGet();
        void CreateBooking(BookingBindingModel model);
        void TakeBookingInWork(BookingBindingModel model);
        void FinishBooking(BookingBindingModel model);
        void PayBooking(BookingBindingModel model);
        void PutElementOnStorage(StorageElementBindingModel model);
    }
}
