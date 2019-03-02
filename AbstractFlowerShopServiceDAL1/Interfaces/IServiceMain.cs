using AbstractFlowerShopServiceDAL.BindingModel;
using AbstractFlowerShopServiceDAL.ViewModel;
using System.Collections.Generic;

namespace AbstractFlowerShopServiceDAL.Interfaces
{
    public interface IServiceMain
    {
        List<BookingViewModel> ListGet();
        void CreateBooking(BookingBindingModel model);
        void TakeBookingInWork(BookingBindingModel model);
        void FinishBooking(BookingBindingModel model);
        void PayBooking(BookingBindingModel model);
    }
}
