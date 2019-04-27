using AbstractFlowerShopServiceDAL1.BindingModel;
using AbstractFlowerShopServiceDAL1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractFlowerShopServiceDAL1.Interfaces
{
    public interface IInfoMessageService
    {
        List<InfoMessageViewModel> ListGet();
        InfoMessageViewModel ElementGet(int id);
        void AddElement(InfoMessageBindingModel model);
    }
}
