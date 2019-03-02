using AbstractFlowerShopServiceDAL.BindingModel;
using AbstractFlowerShopServiceDAL.ViewModel;
using System.Collections.Generic;

namespace AbstractFlowerShopServiceDAL.Interfaces
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
