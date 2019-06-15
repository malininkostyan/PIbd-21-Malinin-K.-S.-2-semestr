using AbstractFlowerShopServiceDAL.BindingModel;
using AbstractFlowerShopServiceDAL.ViewModel;
using System.Collections.Generic;

namespace AbstractFlowerShopServiceDAL.Interfaces
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
