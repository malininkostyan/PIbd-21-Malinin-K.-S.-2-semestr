using AbstractFlowerShopModel;
using AbstractFlowerShopServiceDAL.BindingModel;
using AbstractFlowerShopServiceDAL.Interfaces;
using AbstractFlowerShopServiceDAL.ViewModel;
using System;
using System.Collections.Generic;

namespace AbstractFlowerShopServiceImplementList.Implementations
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
            List<BookingViewModel> result = new List<BookingViewModel>();
            for (int i = 0; i < origin.Bookings.Count; ++i)
            {
                string customerFIO = string.Empty;
                for (int j = 0; j < origin.Customers.Count; ++j)
                {
                    if (origin.Customers[j].Id == origin.Bookings[i].CustomerId)
                    {
                        customerFIO = origin.Customers[j].CustomerFIO;
                        break;
                    }
                }
                string bouquetName = string.Empty;
                for (int j = 0; j < origin.Bouquets.Count; ++j)
                {
                    if (origin.Bouquets[j].Id == origin.Bookings[i].BouquetId)
                    {
                        bouquetName = origin.Bouquets[j].BouquetName;
                        break;
                    }
                }
                result.Add(new BookingViewModel
                {
                    Id = origin.Bookings[i].Id,
                    CustomerId = origin.Bookings[i].CustomerId,
                    CustomerFIO = customerFIO,
                    BouquetId = origin.Bookings[i].BouquetId,
                    BouquetName = bouquetName,
                    Amount = origin.Bookings[i].Amount,
                    Total = origin.Bookings[i].Total,
                    CreateDate = origin.Bookings[i].CreateDate.ToLongDateString(),
                    ImplementDate = origin.Bookings[i].ImplementDate?.ToLongDateString(),
                    Status = origin.Bookings[i].Status.ToString()
                });
            }
            return result;
        }
        public void CreateBooking(BookingBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < origin.Bookings.Count; ++i)
            {
                if (origin.Bookings[i].Id > maxId)
                {
                    maxId = origin.Customers[i].Id;
                }
            }
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
            int index = -1;
            for (int i = 0; i < origin.Bookings.Count; ++i)
            {
                if (origin.Bookings[i].Id == model.Id)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            if (origin.Bookings[index].Status != BookingStatus.Принят)
            {
                throw new Exception("Заказ не в статусе \"Принят\"");
            }
            origin.Bookings[index].ImplementDate = DateTime.Now;
            origin.Bookings[index].Status = BookingStatus.Выполняется;
        }
        public void FinishBooking(BookingBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < origin.Bookings.Count; ++i)
            {
                if (origin.Customers[i].Id == model.Id)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            if (origin.Bookings[index].Status != BookingStatus.Выполняется)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }
            origin.Bookings[index].Status = BookingStatus.Готов;
        }
        public void PayBooking(BookingBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < origin.Bookings.Count; ++i)
            {
                if (origin.Customers[i].Id == model.Id)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            if (origin.Bookings[index].Status != BookingStatus.Готов)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            origin.Bookings[index].Status = BookingStatus.Оплачен;
        }
    }
}
