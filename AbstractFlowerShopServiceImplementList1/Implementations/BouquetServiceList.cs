using AbstractFlowerShopModel1;
using AbstractFlowerShopServiceDAL1.BindingModel;
using AbstractFlowerShopServiceDAL1.Interfaces;
using AbstractFlowerShopServiceDAL1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbstractFlowerShopServiceImplementList1.Implementations
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
            List<BouquetViewModel> result = origin.Bouquets.Select(rec => new BouquetViewModel
            {
                Id = rec.Id,
                BouquetName = rec.BouquetName,
                Cost = rec.Cost,
                BouquetElements = origin.BouquetElements
                .Where(recPC => recPC.BouquetId == rec.Id)
                .Select(recPC => new BouquetElementViewModel
                {
                    Id = recPC.Id,
                    BouquetId = recPC.BouquetId,
                    ElementId = recPC.ElementId,
                    ElementName = origin.Elements.FirstOrDefault(recC =>
                    recC.Id == recPC.ElementId)?.ElementName,
                    Amount = recPC.Amount
                }) .ToList()
            }) .ToList();
            return result;
        }
        public BouquetViewModel ElementGet(int id)
        {
            Bouquet component = origin.Bouquets.FirstOrDefault(rec => rec.Id == id);
            if (component != null)
            {
                return new BouquetViewModel
                {
                    Id = component.Id,
                    BouquetName = component.BouquetName,
                    Cost = component.Cost,
                    BouquetElements = origin.BouquetElements
                        .Where(recPC => recPC.BouquetId == component.Id)
                        .Select(recPC => new BouquetElementViewModel
                        {
                            Id = recPC.Id,
                            BouquetId = recPC.BouquetId,
                            ElementId = recPC.ElementId,
                            ElementName = origin.Elements.FirstOrDefault(recC =>
                            recC.Id == recPC.ElementId)?.ElementName,
                            Amount = recPC.Amount
                        }).ToList()
                };
            }
                throw new Exception("Элемент не найден");
        }
        public void AddElement(BouquetBindingModel model)
        {
            Bouquet component = origin.Bouquets.FirstOrDefault(rec => rec.BouquetName == model.BouquetName);
            if (component != null)
            {
                throw new Exception("Уже есть изделие с таким названием");
            }
            int maxId = origin.Bouquets.Count > 0 ? origin.Bouquets.Max(rec => rec.Id) : 0;
            origin.Bouquets.Add(new Bouquet
            {
                Id = maxId + 1,
                BouquetName = model.BouquetName,
                Cost = model.Cost
            });
            int maxPCId = origin.BouquetElements.Count > 0 ?
            origin.BouquetElements.Max(rec => rec.Id) : 0;
            var groupElements = model.BouquetElements
                .GroupBy(rec => rec.ElementId)
                .Select(rec => new
                {
                    ElementId = rec.Key,
                    Count = rec.Sum(r => r.Amount)
                });
              
            foreach (var groupElement in groupElements)
            {
                origin.BouquetElements.Add(new BouquetElement
                {
                    Id = ++maxPCId,
                    BouquetId = maxId + 1,
                    ElementId = groupElement.ElementId,
                    Amount = groupElement.Count
                });
            }
        }
        public void UpdateElement(BouquetBindingModel model)
        {
            Bouquet component = origin.Bouquets.FirstOrDefault(rec => rec.BouquetName == model.BouquetName && rec.Id != model.Id);
            if (component != null)
            {
                throw new Exception("Уже есть изделие с таким названием");
            }
            component = origin.Bouquets.FirstOrDefault(rec => rec.Id == model.Id);
            if (component == null)
            {
                throw new Exception("Элемент не найден");
            }
            component.BouquetName = model.BouquetName;
            component.Cost = model.Cost;
            int maxPCId = origin.BouquetElements.Count > 0 ? origin.BouquetElements.Max(rec => rec.Id) : 0;
            var compIds = model.BouquetElements.Select(rec => rec.ElementId).Distinct();
            var updateElements = origin.BouquetElements.Where(rec => rec.BouquetId == model.Id && compIds.Contains(rec.ElementId));
            foreach (var updateElement in updateElements)
            {
                updateElement.Amount = model.BouquetElements.FirstOrDefault(rec => rec.Id == updateElement.Id).Amount;
            }
            origin.BouquetElements.RemoveAll(rec => rec.BouquetId == model.Id && !compIds.Contains(rec.ElementId));
            var groupElements = model.BouquetElements
            .Where(rec => rec.Id == 0)
            .GroupBy(rec => rec.ElementId)
            .Select(rec => new
            {
                ElementId = rec.Key,
                Count = rec.Sum(r => r.Amount)
            });
            foreach (var groupElement in groupElements)
            {
                BouquetElement componentPC = origin.BouquetElements.FirstOrDefault(rec => rec.BouquetId == model.Id && rec.ElementId == groupElement.ElementId);
                if (componentPC != null)
                {
                    componentPC.Amount += groupElement.Count;
                }
                else
                {
                    origin.BouquetElements.Add(new BouquetElement
                    {
                        Id = ++maxPCId,
                        BouquetId = model.Id,
                        ElementId = groupElement.ElementId,
                        Amount = groupElement.Count
                    });
                }
            }
        }
        public void DeleteElement(int id)
        {
            Bouquet component = origin.Bouquets.FirstOrDefault(rec => rec.Id == id);
            if (component != null)
            {
                origin.BouquetElements.RemoveAll(rec => rec.BouquetId == id);
                origin.Bouquets.Remove(component);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}