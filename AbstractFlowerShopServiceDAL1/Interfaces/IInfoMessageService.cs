using AbstractFlowerShopServiceDAL1.BindingModel;
using AbstractFlowerShopServiceDAL1.ViewModel;
using System.Collections.Generic;

namespace AbstractFlowerShopServiceDAL1.Interfaces
{
    public interface IInfoMessageService
    {
        List<InfoMessageViewModel> ListGet();
        InfoMessageViewModel ElementGet(int id);
        void AddElement(InfoMessageBindingModel model);
    }
}
