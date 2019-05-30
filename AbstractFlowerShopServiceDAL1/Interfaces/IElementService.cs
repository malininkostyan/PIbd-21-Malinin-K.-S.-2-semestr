using AbstractFlowerShopServiceDAL1.Attributies;
using AbstractFlowerShopServiceDAL1.BindingModel;
using AbstractFlowerShopServiceDAL1.ViewModel;
using System.Collections.Generic;

namespace AbstractFlowerShopServiceDAL1.Interfaces
{
    [CustomInterface("Интерфейс для работы с элементами")]
    public interface IElementService
    {
        [CustomMethod("Метод получения списка элементов")]
        List<ElementViewModel> ListGet();
        [CustomMethod("Метод получения элемента по id")]
        ElementViewModel ElementGet(int id);
        [CustomMethod("Метод добавления элемента")]
        void AddElement(ElementBindingModel model);
        [CustomMethod("Метод изменения данных по элементу")]
        void UpdateElement(ElementBindingModel model);
        [CustomMethod("Метод удаления элемента")]
        void DeleteElement(int id);
    }
}
