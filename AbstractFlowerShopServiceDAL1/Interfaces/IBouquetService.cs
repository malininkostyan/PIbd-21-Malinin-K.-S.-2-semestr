using AbstractFlowerShopServiceDAL1.BindingModel;
using AbstractFlowerShopServiceDAL1.ViewModel;
using System.Collections.Generic;

namespace AbstractFlowerShopServiceDAL1.Interfaces
{
    public interface IBouquetService
    {
        List<BouquetViewModel> ListGet();
        BouquetViewModel ElementGet(int id);
        void AddElement(BouquetBindingModel model);
        void UpdateElement(BouquetBindingModel model);
        void DeleteElement(int id);

    }
}
