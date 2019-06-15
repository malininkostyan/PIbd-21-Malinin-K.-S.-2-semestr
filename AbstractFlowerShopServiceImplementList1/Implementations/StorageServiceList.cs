using AbstractFlowerShopModel1;
using AbstractFlowerShopServiceDAL.BindingModel;
using AbstractFlowerShopServiceDAL.Interfaces;
using AbstractFlowerShopServiceDAL.ViewModel;
using AbstractFlowerShopServiceImplementList;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbstractFlowerShopServiceImplementList1.Implementations
{
    public class StorageServiceList : IStorageService
    {
        private SingleDataList origin;
        public StorageServiceList()
        {
            origin = SingleDataList.GetInstance();
        }
        public List<StorageViewModel> ListGet()
        {
            List<StorageViewModel> result = origin.Storages
            .Select(rec => new StorageViewModel
            {
                Id = rec.Id,
                StorageName = rec.StorageName,
                StorageElements = origin.StorageElements
                .Where(recPC => recPC.StorageId == rec.Id)
                .Select(recPC => new StorageElementViewModel
                {
                    Id = recPC.Id,
                    StorageId = recPC.StorageId,
                    ElementId = recPC.ElementId,
                    ElementName = origin.Elements
                    .FirstOrDefault(recC => recC.Id == recPC.ElementId)?.ElementName,
                    Amount = recPC.Amount
                }).ToList()
            }).ToList();
            return result;
        }
        public StorageViewModel ElementGet(int id)
        {
            Storage component = origin.Storages.FirstOrDefault(rec => rec.Id == id);
            if (component != null)
            {
                return new StorageViewModel
                {
                    Id = component.Id,
                    StorageName = component.StorageName,
                    StorageElements = origin.StorageElements
                    .Where(recPC => recPC.StorageId == component.Id)
                    .Select(recPC => new StorageElementViewModel
                    {
                        Id = recPC.Id,
                        StorageId = recPC.StorageId,
                        ElementId = recPC.ElementId,
                        ElementName = origin.Elements
                        .FirstOrDefault(recC => recC.Id == recPC.ElementId)?.ElementName,
                         Amount = recPC.Amount
                    }).ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(StorageBindingModel model)
        {
            Storage component = origin.Storages.FirstOrDefault(rec => rec.StorageName == model.StorageName);
            if (component != null)
            {
                throw new Exception("Уже есть склад с таким названием");
            }
            int maxId = origin.Storages.Count > 0 ? origin.Storages.Max(rec => rec.Id) : 0;
            origin.Storages.Add(new Storage
            {
                Id = maxId + 1,
                StorageName = model.StorageName
            });
        }
        public void UpdateElement(StorageBindingModel model)
        {
            Storage component = origin.Storages.FirstOrDefault(rec => rec.StorageName == model.StorageName && rec.Id != model.Id);
            if (component != null)
            {
                throw new Exception("Уже есть склад с таким названием");
            }
            component = origin.Storages.FirstOrDefault(rec => rec.Id == model.Id);
            if (component == null)
            {
                throw new Exception("Элемент не найден");
            }
            component.StorageName = model.StorageName;
        }
        public void DeleteElement(int id)
        {
            Storage component = origin.Storages.FirstOrDefault(rec => rec.Id == id);
            if (component != null)
            {
                origin.StorageElements.RemoveAll(rec => rec.StorageId == id);
                origin.Storages.Remove(component);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}