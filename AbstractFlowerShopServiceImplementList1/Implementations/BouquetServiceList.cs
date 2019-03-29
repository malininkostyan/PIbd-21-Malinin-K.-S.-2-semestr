using AbstractFlowerShopModel;
using AbstractFlowerShopServiceDAL.BindingModel;
using AbstractFlowerShopServiceDAL.Interfaces;
using AbstractFlowerShopServiceDAL.ViewModel;
using System;
using System.Collections.Generic;

namespace AbstractFlowerShopServiceImplementList.Implementations
{
    public class BouquetServiceList : IBouquetService
    {
        private SingleDataList origin;
        public BouquetServiceList()
        {
            origin = SingleDataList.GetInstance();
        }
        public List<BouquetViewModel> ListGet()
        {
            List<BouquetViewModel> result = new List<BouquetViewModel>();
            for (int i = 0; i < origin.Bouquets.Count; ++i)
            {
            List<BouquetElementViewModel> bouquetElements = new List<BouquetElementViewModel>();
                for (int j = 0; j < origin.BouquetElements.Count; ++j)
                {
                    if (origin.BouquetElements[j].BouquetId == origin.Bouquets[i].Id)
                    {
                        string elementName = string.Empty;
                        for (int k = 0; k < origin.Elements.Count; ++k)
                        {
                            if (origin.BouquetElements[j].ElementId ==
                           origin.Elements[k].Id)
                            {
                                elementName = origin.Elements[k].ElementName;
                                break;
                            }
                        }
                        bouquetElements.Add(new BouquetElementViewModel
                        {
                            Id = origin.BouquetElements[j].Id,
                            BouquetId = origin.BouquetElements[j].BouquetId,
                            ElementId = origin.BouquetElements[j].ElementId,
                            ElementName = elementName,
                            Amount = origin.BouquetElements[j].Amount
                        });
                    }
                }
                result.Add(new BouquetViewModel
                {
                    Id = origin.Bouquets[i].Id,
                    BouquetName = origin.Bouquets[i].BouquetName,
                    Cost = origin.Bouquets[i].Cost,
                    BouquetElements = bouquetElements
                });
            }
            return result;
        }
        public BouquetViewModel ElementGet(int id)
        {
            for (int i = 0; i < origin.Bouquets.Count; ++i)
            {
            List<BouquetElementViewModel> bouquetElements = new List<BouquetElementViewModel>();
                for (int j = 0; j < origin.BouquetElements.Count; ++j)
                {
                    if (origin.BouquetElements[j].BouquetId == origin.Bouquets[i].Id)
                    {
                        string elementName = string.Empty;
                        for (int k = 0; k < origin.Elements.Count; ++k)
                        {
                            if (origin.BouquetElements[j].ElementId ==
                           origin.Elements[k].Id)
                            {
                                elementName = origin.Elements[k].ElementName;
                                break;
                            }
                        }
                        bouquetElements.Add(new BouquetElementViewModel
                        {
                            Id = origin.BouquetElements[j].Id,
                            BouquetId = origin.BouquetElements[j].BouquetId,
                            ElementId = origin.BouquetElements[j].ElementId,
                            ElementName = elementName,
                            Amount = origin.BouquetElements[j].Amount
                        });
                    }
                }
                if (origin.Bouquets[i].Id == id)
                {
                    return new BouquetViewModel
                    {
                        Id = origin.Bouquets[i].Id,
                        BouquetName = origin.Bouquets[i].BouquetName,
                        Cost = origin.Bouquets[i].Cost,
                        BouquetElements = bouquetElements
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(BouquetBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < origin.Bouquets.Count; ++i)
            {
                if (origin.Bouquets[i].Id > maxId)
                {
                    maxId = origin.Bouquets[i].Id;
                }
                if (origin.Bouquets[i].BouquetName == model.BouquetName)
                {
                    throw new Exception("Уже есть изделие с таким названием");
                }
            }
            origin.Bouquets.Add(new Bouquet
            {
                Id = maxId + 1,
                BouquetName = model.BouquetName,
                Cost = model.Cost
            });
            int maxPCId = 0;
            for (int i = 0; i < origin.BouquetElements.Count; ++i)
            {
                if (origin.BouquetElements[i].Id > maxPCId)
                {
                    maxPCId = origin.BouquetElements[i].Id;
                }
            }
            for (int i = 0; i < model.BouquetElements.Count; ++i)
            {
                for (int j = 1; j < model.BouquetElements.Count; ++j)
                {
                    if (model.BouquetElements[i].ElementId ==
                    model.BouquetElements[j].ElementId)
                    {
                        model.BouquetElements[i].Amount +=
                        model.BouquetElements[j].Amount;
                        model.BouquetElements.RemoveAt(j--);
                    }
                }
            }
            for (int i = 0; i < model.BouquetElements.Count; ++i)
            {
                origin.BouquetElements.Add(new BouquetElement
                {
                    Id = ++maxPCId,
                    BouquetId = maxId + 1,
                    ElementId = model.BouquetElements[i].ElementId,
                    Amount = model.BouquetElements[i].Amount
                });
            }
        }
        public void UpdateElement(BouquetBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < origin.Bouquets.Count; ++i)
            {
                if (origin.Bouquets[i].Id == model.Id)
                {
                    index = i;
                }
                if (origin.Bouquets[i].BouquetName == model.BouquetName &&
                origin.Bouquets[i].Id != model.Id)
                {
                    throw new Exception("Уже есть изделие с таким названием");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            origin.Bouquets[index].BouquetName = model.BouquetName;
            origin.Bouquets[index].Cost = model.Cost;
            int maxPCId = 0;
            for (int i = 0; i < origin.BouquetElements.Count; ++i)
            {
                if (origin.BouquetElements[i].Id > maxPCId)
                {
                    maxPCId = origin.BouquetElements[i].Id;
                }
            }
            for (int i = 0; i < origin.BouquetElements.Count; ++i)
            {
                if (origin.BouquetElements[i].BouquetId == model.Id)
                {
                    bool flag = true;
                    for (int j = 0; j < model.BouquetElements.Count; ++j)
                    {
                        if (origin.BouquetElements[i].Id == model.BouquetElements[j].Id)
                        {
                            origin.BouquetElements[i].Amount = model.BouquetElements[j].Amount;
                            flag = false;
                            break;
                        }
                    }
                    if (flag)
                    {
                        origin.BouquetElements.RemoveAt(i--);
                    }
                }
            }
            for (int i = 0; i < model.BouquetElements.Count; ++i)
            {
                if (model.BouquetElements[i].Id == 0)
                {
                    for (int j = 0; j < origin.BouquetElements.Count; ++j)
                    {
                        if (origin.BouquetElements[j].BouquetId == model.Id &&
                        origin.BouquetElements[j].ElementId ==
                       model.BouquetElements[i].ElementId)
                        {
                            origin.BouquetElements[j].Amount +=
                           model.BouquetElements[i].Amount;
                            model.BouquetElements[i].Id =
                           origin.BouquetElements[j].Id;
                            break;
                        }
                    }
                    if (model.BouquetElements[i].Id == 0)
                    {
                        origin.BouquetElements.Add(new BouquetElement
                        {
                            Id = ++maxPCId,
                            BouquetId = model.Id,
                            ElementId = model.BouquetElements[i].ElementId,
                            Amount = model.BouquetElements[i].Amount
                        });
                    }
                }
            }
        }
        public void DeleteElement(int id)
        {
            for (int i = 0; i < origin.BouquetElements.Count; ++i)
            {
                if (origin.BouquetElements[i].BouquetId == id)
                {
                    origin.BouquetElements.RemoveAt(i--);
                }
            }
            for (int i = 0; i < origin.Bouquets.Count; ++i)
            {
                if (origin.Bouquets[i].Id == id)
                {
                    origin.Bouquets.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
    }
}