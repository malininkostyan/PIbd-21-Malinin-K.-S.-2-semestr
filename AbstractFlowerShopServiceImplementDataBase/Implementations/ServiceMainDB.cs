using AbstractFlowerShopModel1;
using AbstractFlowerShopServiceDAL.BindingModel;
using AbstractFlowerShopServiceDAL.ViewModel;
using AbstractFlowerShopServiceDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;

namespace AbstractFlowerShopServiceImplementDataBase.Implementations
{
    public class ServiceMainDB : IServiceMain
    {
        private AbstractContextDb context;
        public ServiceMainDB(AbstractContextDb context)
        {
            this.context = context;
        }
        public List<BookingViewModel> ListGet()
        {
            List<BookingViewModel> result = context.Bookings.Select(rec => new BookingViewModel
            {
                Id = rec.Id,
                CustomerId = rec.CustomerId,
                BouquetId = rec.BouquetId,
                CreateDate = SqlFunctions.DateName("dd", rec.CreateDate) + " " +
                SqlFunctions.DateName("mm", rec.CreateDate) + " " +
                SqlFunctions.DateName("yyyy", rec.CreateDate),
                ImplementDate = rec.ImplementDate == null ? "" :
                SqlFunctions.DateName("dd",
                rec.ImplementDate.Value) + " " +
                SqlFunctions.DateName("mm",
                rec.ImplementDate.Value) + " " +
                SqlFunctions.DateName("yyyy",
                rec.ImplementDate.Value),
                Status = rec.Status.ToString(),
                Amount = rec.Amount,
                Total = rec.Total,
                CustomerFIO = rec.Customer.CustomerFIO,
                BouquetName = rec.Bouquet.BouquetName
            })
            .ToList();
            return result;
        }
        public void CreateBooking(BookingBindingModel model)
        {
            context.Bookings.Add(new Booking
            {
                CustomerId = model.CustomerId,
                BouquetId = model.BouquetId,
                CreateDate = DateTime.Now,
                Amount = model.Amount,
                Total = model.Total,
                Status = BookingStatus.Принят
            });
            context.SaveChanges();
        }
        public void TakeBookingInWork(BookingBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Booking element = context.Bookings.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                    if (element.Status != BookingStatus.Принят)
                    {
                        throw new Exception("Заказ не в статусе \"Принят\"");
                    }
                    var bouquetElements = context.BouquetElements.Include(rec => rec.Element).Where(rec => rec.BouquetId == element.BouquetId);
                    
                    foreach (var bouquetElement in bouquetElements)
                    {
                        int countOnStorages = bouquetElement.Amount * element.Amount;
                        var storageElements = context.StorageElements.Where(rec =>
                        rec.ElementId == bouquetElement.ElementId);
                        foreach (var storageElement in storageElements)
                        {
                           
                            if (storageElement.Amount >= countOnStorages)
                            {
                                storageElement.Amount -= countOnStorages;
                                countOnStorages = 0;
                                context.SaveChanges();
                                break;
                            }
                            else
                            {
                                countOnStorages -= storageElement.Amount;
                                storageElement.Amount = 0;
                                context.SaveChanges();
                            }
                        }
                        if (countOnStorages > 0)
                        {
                            throw new Exception("Не достаточно компонента " + bouquetElement.Element.ElementName + " требуется " + bouquetElement.Amount + ", не  хватает " + countOnStorages);
                        }
                    }
                    element.ImplementDate = DateTime.Now;
                    element.Status = BookingStatus.Выполняется;
                    context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        public void FinishBooking(BookingBindingModel model)
        {
            Booking element = context.Bookings.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != BookingStatus.Выполняется)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }
            element.Status = BookingStatus.Готов;
            context.SaveChanges();
        }
        public void PayBooking(BookingBindingModel model)
        {
            Booking element = context.Bookings.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != BookingStatus.Готов)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            element.Status = BookingStatus.Оплачен;
            context.SaveChanges();
        }
        public void PutElementOnStorage(StorageElementBindingModel model)
        {
            StorageElement element = context.StorageElements.FirstOrDefault(rec =>
            rec.StorageId == model.StorageId && rec.ElementId == model.ElementId);
            if (element != null)
            {
                element.Amount += model.Amount;
            }
            else
            {
                context.StorageElements.Add(new StorageElement
                {
                    StorageId = model.StorageId,
                    ElementId = model.ElementId,
                    Amount = model.Amount
                });
            }
            context.SaveChanges();
        }
    }
}