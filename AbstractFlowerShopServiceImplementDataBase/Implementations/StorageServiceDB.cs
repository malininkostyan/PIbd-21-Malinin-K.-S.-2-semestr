using AbstractFlowerShopModel1;
using AbstractFlowerShopServiceDAL1.BindingModel;
using AbstractFlowerShopServiceDAL1.Interfaces;
using AbstractFlowerShopServiceDAL1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbstractFlowerShopServiceImplementDataBase.Implementations
{
    public class StorageServiceDB : IStorageService
    {
        private AbstractContextDb context;

        public StorageServiceDB(AbstractContextDb context)
        {
            this.context = context;
        }

        public List<StorageViewModel> ListGet()
        {
            List<StorageViewModel> result = context.Storages.Select(rec => new
            StorageViewModel
            {
                Id = rec.Id,
                StorageName = rec.StorageName,
                StorageElements = context.StorageElements
            .Where(recPC => recPC.StorageId == rec.Id)
            .Select(recPC => new StorageElementViewModel
            {
                Id = recPC.Id,
                StorageId = recPC.StorageId,
                ElementId = recPC.ElementId,
                ElementName = recPC.Element.ElementName,
                Amount = recPC.Amount
            })
            .ToList()
            })
            .ToList();
            return result;
        }

        public StorageViewModel ElementGet(int id)
        {
            Storage element = context.Storages.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new StorageViewModel
                {
                    Id = element.Id,
                    StorageName = element.StorageName,
                    StorageElements = context.StorageElements
                    .Where(recPC => recPC.StorageId == element.Id)
                    .Select(recPC => new StorageElementViewModel
                    {
                        Id = recPC.Id,
                        StorageId = recPC.StorageId,
                        ElementId = recPC.ElementId,
                        ElementName = recPC.Element.ElementName,
                        Amount = recPC.Amount
                    })
                    .ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(StorageBindingModel model)
        {
            Storage element = context.Storages.FirstOrDefault(rec => rec.StorageName == model.StorageName);
            if (element != null)
            {
                throw new Exception("Уже есть склад с таким названием");
            }
            context.Storages.Add(new Storage
            {
                StorageName = model.StorageName
            });
            context.SaveChanges();
        }

        public void UpdateElement(StorageBindingModel model)
        {
            Storage element = context.Storages.FirstOrDefault(rec => rec.StorageName ==
            model.StorageName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть склад с таким названием");
            }
            element = context.Storages.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.StorageName = model.StorageName;
            context.SaveChanges();
        }

        public void DeleteElement(int id)
        {
            Storage element = context.Storages.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                context.Storages.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
