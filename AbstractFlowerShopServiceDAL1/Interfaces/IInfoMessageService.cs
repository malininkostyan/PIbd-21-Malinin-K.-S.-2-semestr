using AbstractFlowerShopServiceDAL1.Attributies;
using AbstractFlowerShopServiceDAL1.BindingModel;
using AbstractFlowerShopServiceDAL1.ViewModel;
using System.Collections.Generic;

namespace AbstractFlowerShopServiceDAL1.Interfaces
{
    [CustomInterface("Интерфейс для работы с сообщениями")]
    public interface IInfoMessageService
    {
        [CustomMethod("Метод получения списка сообщений")]
        List<InfoMessageViewModel> ListGet();
        [CustomMethod("Метод получения сообщения по id")]
        InfoMessageViewModel ElementGet(int id);
        [CustomMethod("Метод добавления сообщения")]
        void AddElement(InfoMessageBindingModel model);
    }
}
