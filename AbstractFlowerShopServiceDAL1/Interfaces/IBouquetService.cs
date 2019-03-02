using AbstractFlowerShopServiceDAL.BindingModel;
using AbstractFlowerShopServiceDAL.ViewModel;
using System.Collections.Generic;

namespace AbstractFlowerShopServiceDAL.Interfaces
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
