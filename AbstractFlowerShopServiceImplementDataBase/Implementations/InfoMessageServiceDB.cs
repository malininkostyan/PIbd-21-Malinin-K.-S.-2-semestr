using AbstractFlowerShopModel1;
using AbstractFlowerShopServiceDAL1.BindingModel;
using AbstractFlowerShopServiceDAL1.Interfaces;
using AbstractFlowerShopServiceDAL1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text.RegularExpressions;

namespace AbstractFlowerShopServiceImplementDataBase.Implementations
{
    public class InfoMessageServiceDB : IInfoMessageService
    {
        private AbstractContextDb context;
        public InfoMessageServiceDB(AbstractContextDb context)
        {
            this.context = context;
        }
        public List<InfoMessageViewModel> ListGet()
        {
            List<InfoMessageViewModel> result = context.InfoMessages
            .Where(rec => !rec.CustomerId.HasValue)
            .Select(rec => new InfoMessageViewModel
            {
                MessageId = rec.MessageId,
                CustomerFIO = rec.FromMailAddress,
                DeliveryDate = rec.DeliveryDate,
                Subject = rec.Subject,
                Body = rec.Body
            })
            .ToList();
            return result;
        }
        public InfoMessageViewModel ElementGet(int id)
        {
            InfoMessage element = context.InfoMessages.Include(rec => rec.Customers)
            .FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new InfoMessageViewModel
                {
                    MessageId = element.MessageId,
                    CustomerFIO = element.Customers.CustomerFIO,
                    DeliveryDate = element.DeliveryDate,
                    Subject = element.Subject,
                    Body = element.Body
                };
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(InfoMessageBindingModel model)
        {
            InfoMessage element = context.InfoMessages.FirstOrDefault(rec =>
           rec.MessageId == model.MessageId);
            if (element != null)
            {
                return;
            }
            var message = new InfoMessage
            {
                MessageId = model.MessageId,
                FromMailAddress = model.FromMailAddress,
                DeliveryDate = model.DeliveryDate,
                Subject = model.Subject,
                Body = model.Body
            };
            var mailAddress = Regex.Match(model.FromMailAddress,
           @"(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9az])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))");
            if (mailAddress.Success)
            {
                var customer = context.Customers.FirstOrDefault(rec => rec.Mail ==  mailAddress.Value);
                if (customer != null)
                {
                    message.CustomerId = customer.Id;
                }
            }
            context.InfoMessages.Add(message);
            context.SaveChanges();
        }
    }
}