using AbstractFlowerShopModel;
using AbstractFlowerShopServiceDAL.BindingModel;
using AbstractFlowerShopServiceDAL.Interfaces;
using AbstractFlowerShopServiceDAL.ViewModel;
using System;
using System.Collections.Generic;

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
            List<ElementViewModel> result = new List<ElementViewModel>();
            for (int i = 0; i < origin.Elements.Count; ++i)
            {
                result.Add(new ElementViewModel
                {
                    Id = origin.Elements[i].Id,
                    ElementName = origin.Elements[i].ElementName
                });
            }
            return result;
        }
        public ElementViewModel ElementGet(int id)
        {
            for (int i = 0; i < origin.Elements.Count; ++i)
            {
                if (origin.Elements[i].Id == id)
                {
                    return new ElementViewModel
                    {
                        Id = origin.Elements[i].Id,
                        ElementName = origin.Elements[i].ElementName
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(ElementBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < origin.Elements.Count; ++i)
            {
                if (origin.Elements[i].Id > maxId)
                {
                    maxId = origin.Elements[i].Id;
                }
                if (origin.Elements[i].ElementName == model.ElementName)
                {
                    throw new Exception("Уже есть компонент с таким названием");
                }
            }
            origin.Elements.Add(new Element
            {
                Id = maxId + 1,
                ElementName = model.ElementName
            });
        }
        public void UpdateElement(ElementBindingModel model)
        {
            int index = -1;

            for (int i = 0; i < origin.Elements.Count; ++i)
            {
                if (origin.Elements[i].Id == model.Id)
                {
                    index = i;
                }
                if (origin.Elements[i].ElementName == model.ElementName &&
                origin.Elements[i].Id != model.Id)
                {
                    throw new Exception("Уже есть компонент с таким названием");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            origin.Elements[index].ElementName = model.ElementName;
        }
        public void DeleteElement(int id)
        {
            for (int i = 0; i < origin.Elements.Count; ++i)
            {
                if (origin.Elements[i].Id == id)
                {
                    origin.Elements.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
    }
}
