using AbstractFlowerShopServiceDAL1.BindingModel;
using AbstractFlowerShopServiceDAL1.ViewModel;
using System.Collections.Generic;

namespace AbstractFlowerShopServiceDAL1.Interfaces
{
    public interface IElementService
    {
        List<ElementViewModel> ListGet();
        ElementViewModel ElementGet(int id);
        void AddElement(ElementBindingModel model);
        void UpdateElement(ElementBindingModel model);
        void DeleteElement(int id);
    }
}
