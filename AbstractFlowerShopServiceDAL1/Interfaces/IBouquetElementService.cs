using AbstractFlowerShopServiceDAL1.BindingModel;
using AbstractFlowerShopServiceDAL1.ViewModel;
using System.Collections.Generic;

namespace AbstractFlowerShopServiceDAL1.Interfaces
{
    public interface IBouquetElementService
    {
        List<BouquetElementViewModel> ListGet();
        BouquetElementViewModel ElementGet(int id);
        void AddElement(BouquetElementBindingModel model);
        void UpdateElement(BouquetElementBindingModel model);
        void DeleteElement(int id);

    }
}
