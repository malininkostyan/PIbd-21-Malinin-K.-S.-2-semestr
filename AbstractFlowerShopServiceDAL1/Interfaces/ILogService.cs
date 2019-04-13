using AbstractFlowerShopServiceDAL1.BindingModel;
using AbstractFlowerShopServiceDAL1.ViewModel;
using System.Collections.Generic;

namespace AbstractFlowerShopServiceDAL1.Interfaces
{
    public interface ILogService
    {
        void SaveBouquetPrice(LogBindingModel model);
        List<LoadStoragesViewModel> GetStoragesLoad();
        void SaveStoragesLoad(LogBindingModel model);
        List<CustomerBookingViewModel> GetCustomerBookings(LogBindingModel model);
        void SaveCustomerBookings(LogBindingModel model);
    }
}
