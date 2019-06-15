using AbstractFlowerShopModel1;
using AbstractFlowerShopServiceDAL.BindingModel;
using AbstractFlowerShopServiceDAL.Interfaces;
using AbstractFlowerShopServiceDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbstractFlowerShopServiceImplementDataBase.Implementations
{
    public class BouquetServiceDB : IBouquetService
    {
        private AbstractContextDb context;
        public BouquetServiceDB(AbstractContextDb context)
        {
            this.context = context;
        }
        public List<BouquetViewModel> ListGet()
        {
            List<BouquetViewModel> result = context.Bouquets.Select(rec => new BouquetViewModel
            {
                Id = rec.Id,
                BouquetName = rec.BouquetName,
                Cost = rec.Cost,
                BouquetElements = context.BouquetElements
                .Where(recPC => recPC.BouquetId == rec.Id)
                .Select(recPC => new BouquetElementViewModel
                {
                    Id = recPC.Id,
                    BouquetId = recPC.BouquetId,
                    ElementId = recPC.ElementId,
                    ElementName = recPC.Element.ElementName,
                    Amount = recPC.Amount
                })
                .ToList()
            })
            .ToList();
            return result;
        }
        public BouquetViewModel ElementGet(int id)
        {
            Bouquet element = context.Bouquets.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new BouquetViewModel
                {
                    Id = element.Id,
                    BouquetName = element.BouquetName,
                    Cost = element.Cost,
                    BouquetElements = context.BouquetElements
                    .Where(recPC => recPC.BouquetId == element.Id)
                    .Select(recPC => new BouquetElementViewModel
                    {
                        Id = recPC.Id,
                        BouquetId = recPC.BouquetId,
                        ElementId = recPC.ElementId,
                        ElementName = recPC.Element.ElementName,
                        Amount = recPC.Amount
                    })
                .ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(BouquetBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Bouquet element = context.Bouquets.FirstOrDefault(rec =>
                    rec.BouquetName == model.BouquetName);
                    if (element != null)
                    {
                        throw new Exception("Уже есть изделие с таким названием");
                    }
                    element = new Bouquet
                    {
                        BouquetName = model.BouquetName,
                        Cost = model.Cost
                    };
                    context.Bouquets.Add(element);
                    context.SaveChanges();
                  
                    var groupElements = model.BouquetElements
                    .GroupBy(rec => rec.ElementId)
                    .Select(rec => new
                    {
                        ElementId = rec.Key,
                        Amount = rec.Sum(r => r.Amount)
                    });

                    foreach (var groupElement in groupElements)
                    {
                        context.BouquetElements.Add(new BouquetElement
                        {
                            BouquetId = element.Id,
                            ElementId = groupElement.ElementId,
                            Amount = groupElement.Amount
                        });
                        context.SaveChanges();
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        public void UpdateElement(BouquetBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Bouquet element = context.Bouquets.FirstOrDefault(rec =>
                    rec.BouquetName == model.BouquetName && rec.Id != model.Id);
                    if (element != null)
                    {
                        throw new Exception("Уже есть изделие с таким названием");
                    }
                    element = context.Bouquets.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                    element.BouquetName = model.BouquetName;
                    element.Cost = model.Cost;
                    context.SaveChanges();
                    
                    var compIds = model.BouquetElements.Select(rec =>
                    rec.ElementId).Distinct();
                    var updateElements = context.BouquetElements.Where(rec =>
                    rec.BouquetId == model.Id && compIds.Contains(rec.ElementId));
                    foreach (var updateElement in updateElements)
                    {
                        updateElement.Amount = model.BouquetElements.FirstOrDefault(rec => rec.Id == updateElement.Id).Amount;
                    }
                    context.SaveChanges();
                    context.BouquetElements.RemoveRange(context.BouquetElements.Where(rec =>
                    rec.BouquetId == model.Id && !compIds.Contains(rec.ElementId)));
                    context.SaveChanges();
                   
                    var groupElements = model.BouquetElements
                   .Where(rec => rec.Id == 0)
                   .GroupBy(rec => rec.ElementId)
                   .Select(rec => new
                   {
                       ElementId = rec.Key,
                       Amount = rec.Sum(r => r.Amount)
                   });
                    foreach (var groupElement in groupElements)
                    {
                        BouquetElement elementPC =
                        context.BouquetElements.FirstOrDefault(rec => rec.BouquetId == model.Id &&
                        rec.ElementId == groupElement.ElementId);
                        if (elementPC != null)
                        {
                            elementPC.Amount += groupElement.Amount;
                            context.SaveChanges();
                        }
                        else
                        {
                            context.BouquetElements.Add(new BouquetElement
                            {
                                BouquetId = model.Id,
                                ElementId = groupElement.ElementId,
                                Amount = groupElement.Amount
                            });
                            context.SaveChanges();
                        }
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        public void DeleteElement(int id)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Bouquet element = context.Bouquets.FirstOrDefault(rec => rec.Id == id);
                    if (element != null)
                    {
                        context.BouquetElements.RemoveRange(context.BouquetElements.Where(rec =>
                        rec.BouquetId == id));
                        context.Bouquets.Remove(element);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Элемент не найден");
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}