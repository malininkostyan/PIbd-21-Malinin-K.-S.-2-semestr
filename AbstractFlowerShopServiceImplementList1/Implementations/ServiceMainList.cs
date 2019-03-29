using AbstractFlowerShopModel1;
using AbstractFlowerShopServiceDAL1.Interfaces;
using AbstractFlowerShopServiceDAL1.ViewModel;
using AbstractFlowerShopServiceDAL1.BindingModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbstractFlowerShopServiceImplementList1.Implementations
{
    public class ServiceMainList : IServiceMain
    {
        private SingleDataList origin;
        public ServiceMainList()
        {
            origin = SingleDataList.GetInstance();
        }
        public List<BookingViewModel> ListGet()
        {
            List<BookingViewModel> result = origin.Bookings.Select(rec => new BookingViewModel
            {
                Id = rec.Id,
                CustomerId = rec.CustomerId,
                BouquetId = rec.BouquetId,
                CreateDate = rec.CreateDate.ToLongDateString(),
                ImplementDate = rec.ImplementDate?.ToLongDateString(),
                Status = rec.Status.ToString(),
                Amount = rec.Amount,
                Total = rec.Total,
                CustomerFIO = origin.Customers.FirstOrDefault(recC => recC.Id ==
                rec.CustomerId)?.CustomerFIO,
                BouquetName = origin.Bouquets.FirstOrDefault(recP => recP.Id ==
                rec.BouquetId)?.BouquetName,
            }).ToList();
            return result;
        }
        public void CreateBooking(BookingBindingModel model)
        {
            int maxId = origin.Bookings.Count > 0 ? origin.Bookings.Max(rec => rec.Id) : 0;
            origin.Bookings.Add(new Booking
            {
                Id = maxId + 1,
                CustomerId = model.CustomerId,
                BouquetId = model.BouquetId,
                CreateDate = DateTime.Now,
                Amount = model.Amount,
                Total = model.Total,
                Status = BookingStatus.Принят
            });
        }
        public void TakeBookingInWork(BookingBindingModel model)
        {
            Booking component = origin.Bookings.FirstOrDefault(rec => rec.Id == model.Id);
            if (component == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (component.Status != BookingStatus.Принят)
            {
                throw new Exception("Заказ не в статусе \"Принят\"");
            }
            var bouquetElements = origin.BouquetElements.Where(rec => rec.BouquetId == component.BouquetId);
            foreach (var bouquetElement in bouquetElements)
            {
                int amountOnStorages = origin.StorageElements
                .Where(rec => rec.ElementId == bouquetElement.ElementId)
                .Sum(rec => rec.Amount);
                if (amountOnStorages < bouquetElement.Amount * component.Amount)
                {
                    var componentName = origin.Elements.FirstOrDefault(rec => rec.Id ==
                    bouquetElement.ElementId);
                    throw new Exception("Не достаточно компонента " +
                    componentName?.ElementName + " требуется " + (bouquetElement.Amount * component.Amount) +
                   ", в наличии " + amountOnStorages);
                }
            }
            foreach (var bouquetElement in bouquetElements)
            {
                int amountOnStorages = bouquetElement.Amount * component.Amount;
                var storageElements = origin.StorageElements.Where(rec => rec.ElementId == bouquetElement.ElementId);
                foreach (var storageElement in storageElements)
                {
                    if (storageElement.Amount >= amountOnStorages)
                    {
                        storageElement.Amount -= amountOnStorages;
                        break;
                    }
                    else
                    {
                        amountOnStorages -= storageElement.Amount;
                        storageElement.Amount = 0;
                    }
                }
            }
            component.ImplementDate = DateTime.Now;
            component.Status = BookingStatus.Выполняется;
        }

        public void FinishBooking(BookingBindingModel model)
        {
            Booking component = origin.Bookings.FirstOrDefault(rec => rec.Id == model.Id);
            if (component == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (component.Status != BookingStatus.Выполняется)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }
            component.Status = BookingStatus.Готов;
        }
        public void PayBooking(BookingBindingModel model)
        {
            Booking component = origin.Bookings.FirstOrDefault(rec => rec.Id == model.Id);
            if (component == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (component.Status != BookingStatus.Готов)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            component.Status = BookingStatus.Оплачен;
        }
        public void PutElementOnStorage(StorageElementBindingModel model)
        {
            StorageElement component = origin.StorageElements.FirstOrDefault(rec => rec.StorageId == model.StorageId && rec.ElementId == model.ElementId);
            if (component != null)
            {
                component.Amount += model.Amount;
            }
            else
            {
                int maxId = origin.StorageElements.Count > 0 ?
                origin.StorageElements.Max(rec => rec.Id) : 0;
                origin.StorageElements.Add(new StorageElement
                {
                    Id = ++maxId,
                    StorageId = model.StorageId,
                    ElementId = model.ElementId,
                    Amount = model.Amount
                });
            }
        }
    }
}
