using AbstractFlowerShopModel;
using AbstractFlowerShopServiceDAL.BindingModel;
using AbstractFlowerShopServiceDAL.Interfaces;
using AbstractFlowerShopServiceDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbstractFlowerShopServiceImplementList.Implementations
{
    public class ElementServiceList : IElementService
    {
        private SingleDataList origin;
        public ElementServiceList()
        {
            origin = SingleDataList.GetInstance();
        }
        public List<ElementViewModel> ListGet()
        {
            List<ElementViewModel> result = origin.Elements.Select(rec => new ElementViewModel
            {
                Id = rec.Id,
                ElementName = rec.ElementName
            }) .ToList();
            return result;
        }
        public ElementViewModel ElementGet(int id)
        {
            Element component = origin.Elements.FirstOrDefault(rec => rec.Id == id);
            if (component != null)
            {
                return new ElementViewModel
                {
                    Id = component.Id,
                    ElementName = component.ElementName
                };
            }
                throw new Exception("Элемент не найден");
        }
        public void AddElement(ElementBindingModel model)
        {
            Element component = origin.Elements.FirstOrDefault(rec => rec.ElementName == model.ElementName);
            if (component != null)
            {
                throw new Exception("Уже есть компонент с таким названием");
            }
            int maxId = origin.Elements.Count > 0 ? origin.Elements.Max(rec => rec.Id) : 0;
            origin.Elements.Add(new Element
            {
                Id = maxId + 1,
                ElementName = model.ElementName
            });
        }
        public void UpdateElement(ElementBindingModel model)
        {
            Element component = origin.Elements.FirstOrDefault(rec => rec.ElementName == model.ElementName && rec.Id != model.Id);
            if (component != null)
            {
                throw new Exception("Уже есть компонент с таким названием");
            }
            component = origin.Elements.FirstOrDefault(rec => rec.Id == model.Id);
            if (component == null)
            {
                throw new Exception("Элемент не найден");
            }
            component.ElementName = model.ElementName;
        }
        public void DeleteElement(int id)
        {
            Element component = origin.Elements.FirstOrDefault(rec => rec.Id == id);
            if (component != null)
            {
                origin.Elements.Remove(component);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
