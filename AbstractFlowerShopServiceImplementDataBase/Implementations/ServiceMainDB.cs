using AbstractFlowerShopModel1;
using AbstractFlowerShopServiceDAL1.BindingModel;
using AbstractFlowerShopServiceDAL1.Interfaces;
using AbstractFlowerShopServiceDAL1.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Net;
using System.Net.Mail;

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
                ExecutorId = rec.ExecutorId,
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
                BouquetName = rec.Bouquet.BouquetName,
                ExecutorId = rec.ExecutorId,
                ExecutorFIO = rec.Executor.ExecutorFIO
            })
            .ToList();
            return result;
        }
        public void CreateBooking(BookingBindingModel model)
        {
            var booking = new Booking
            {
                CustomerId = model.CustomerId,
                BouquetId = model.BouquetId,
                ExecutorId = model.ExecutorId,
                CreateDate = DateTime.Now,
                Amount = model.Amount,
                Total = model.Total,
                Status = BookingStatus.Принят
            };
            var customer = context.Customers.FirstOrDefault(x => x.Id == model.CustomerId);
            SendEmail(customer.Mail, "Оповещение по заказам", string.Format("Заказ №{0} от {1} создан успешно", booking.Id, booking.CreateDate.ToShortDateString()));
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
                    if (element.Status != BookingStatus.Принят && element.Status != BookingStatus.НедостаточноРесурсов)

                    {
                        throw new Exception("Заказ не в статусе \"Принят\"");
                    }
                    var bouquetElements = context.BouquetElements.Include(rec => rec.Element).Where(rec => rec.BouquetId == element.BouquetId).ToList();
                    
                    foreach (var bouquetElement in bouquetElements)
                    {
                        int countOnStorages = bouquetElement.Amount * element.Amount;
                        var storageElements = context.StorageElements.Where(rec =>
                        rec.ElementId == bouquetElement.ElementId).ToList();
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
                    element.ExecutorId = model.ExecutorId;
                    element.ImplementDate = DateTime.Now;
                    element.ExecutorId = model.ExecutorId;
                    element.Status = BookingStatus.Выполняется;
                    context.SaveChanges();
                    SendEmail(element.Customer.Mail, "Оповещение по заказам", string.Format("Заказ №{0} от {1} передан в работу", element.Id, element.CreateDate.ToShortDateString()));
                    transaction.Commit();
                }
                catch (Exception)
                {
                    Booking element = context.Bookings.FirstOrDefault(rec => rec.Id == model.Id);
                    transaction.Rollback();
                    element.Status = BookingStatus.НедостаточноРесурсов;
                    context.SaveChanges();
                    transaction.Commit();
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
            SendEmail(element.Customer.Mail, "Оповещение по заказам", string.Format("Заказ №{0} от {1} передан на оплату", element.Id, element.CreateDate.ToShortDateString()));
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
            SendEmail(element.Customer.Mail, "Оповещение по заказам", string.Format("Заказ №{0} от {1} оплачен успешно", element.Id, element.CreateDate.ToShortDateString()));
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
        public List<BookingViewModel> GetFreeBookings()
        {
            List<BookingViewModel> result = context.Bookings
            .Where(x => x.Status == BookingStatus.Принят || x.Status == BookingStatus.НедостаточноРесурсов)
            .Select(rec => new BookingViewModel
            {
                Id = rec.Id
            })
            .ToList();
            return result;
        }
        private void SendEmail(string mailAddress, string subject, string text)
        {
            MailMessage objMailMessage = new MailMessage();
            SmtpClient objSmtpCustomer = null;
            try
            {
                objMailMessage.From = new
                MailAddress(ConfigurationManager.AppSettings["MailLogin"]);
                objMailMessage.To.Add(new MailAddress(mailAddress));
                objMailMessage.Subject = subject;
                objMailMessage.Body = text;
                objMailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
                objMailMessage.BodyEncoding = System.Text.Encoding.UTF8;
                objSmtpCustomer = new SmtpClient("smtp.gmail.com", 587);
                objSmtpCustomer.UseDefaultCredentials = false;
                objSmtpCustomer.EnableSsl = true;
                objSmtpCustomer.DeliveryMethod = SmtpDeliveryMethod.Network;
                objSmtpCustomer.Credentials = new
                NetworkCredential(ConfigurationManager.AppSettings["MailLogin"],
                ConfigurationManager.AppSettings["MailPassword"]);
                objSmtpCustomer.Send(objMailMessage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objMailMessage = null;
                objSmtpCustomer = null;
            }
        }
    }
}
