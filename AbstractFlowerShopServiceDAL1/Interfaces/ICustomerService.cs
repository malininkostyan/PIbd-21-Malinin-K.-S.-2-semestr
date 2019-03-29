using AbstractFlowerShopServiceDAL1.BindingModel;
using AbstractFlowerShopServiceDAL1.ViewModel;
using System.Collections.Generic;

namespace AbstractFlowerShopServiceDAL1.Interfaces
{
    public interface ICustomerService
    {
        List<CustomerViewModel> ListGet();
        CustomerViewModel ElementGet(int id);
        void AddElement(CustomerBindingModel model);
        void UpdateElement(CustomerBindingModel model);
        void DeleteElement(int id);

    }   
}
