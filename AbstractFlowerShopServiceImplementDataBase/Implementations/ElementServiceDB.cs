using AbstractFlowerShopModel1;
using AbstractFlowerShopServiceDAL.BindingModel;
using AbstractFlowerShopServiceDAL.Interfaces;
using AbstractFlowerShopServiceDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbstractFlowerShopServiceImplementDataBase.Implementations
{
    public class ElementServiceDB : IElementService
    {
        private AbstractContextDb context;

        public ElementServiceDB(AbstractContextDb context)
        {
            this.context = context;
        }

        public List<ElementViewModel> ListGet()
        {
            List<ElementViewModel> result = context.Elements.Select(rec => new  ElementViewModel
            {
                Id = rec.Id,
                ElementName = rec.ElementName
            })
            .ToList();
            return result;
        }

        public ElementViewModel ElementGet(int id)
        {
            Element element = context.Elements.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new ElementViewModel
                {
                    Id = element.Id,
                    ElementName = element.ElementName
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(ElementBindingModel model)
        {
            Element element = context.Elements.FirstOrDefault(rec => rec.ElementName ==  model.ElementName);
            if (element != null)
            {
                throw new Exception("Уже есть материал с таким названием");
            }
            context.Elements.Add(new Element
            {
                ElementName = model.ElementName
            });
            context.SaveChanges();
        }

        public void UpdateElement(ElementBindingModel model)
        {
            Element element = context.Elements.FirstOrDefault(rec => rec.ElementName ==
            model.ElementName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть материал с таким названием");
            }
            element = context.Elements.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.ElementName = model.ElementName;
            context.SaveChanges();
        }

        public void DeleteElement(int id)
        {
            Element element = context.Elements.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                context.Elements.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
