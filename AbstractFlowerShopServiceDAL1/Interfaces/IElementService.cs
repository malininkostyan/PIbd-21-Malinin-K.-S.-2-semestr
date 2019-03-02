using AbstractFlowerShopServiceDAL.BindingModel;
using AbstractFlowerShopServiceDAL.ViewModel;
using System.Collections.Generic;

namespace AbstractFlowerShopServiceDAL.Interfaces
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
