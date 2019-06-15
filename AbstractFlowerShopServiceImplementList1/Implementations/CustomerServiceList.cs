using AbstractFlowerShopModel1;
using AbstractFlowerShopServiceDAL1.BindingModel;
using AbstractFlowerShopServiceDAL1.Interfaces;
using AbstractFlowerShopServiceDAL1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AbstractFlowerShopServiceImplementList1.Implementations
{
    public class CustomerServiceList : ICustomerService
    {
        private SingleDataList origin;
        public CustomerServiceList()
        {
            origin = SingleDataList.GetInstance();
        }
        public List<CustomerViewModel> ListGet()
        {
            List<CustomerViewModel> result = origin.Customers.Select(rec => new CustomerViewModel
            {
                Id = rec.Id,
                CustomerFIO = rec.CustomerFIO
            }).ToList();
            return result;
        }
        public CustomerViewModel ElementGet(int id)
        {
            Customer component = origin.Customers.FirstOrDefault(rec => rec.Id == id);
            if (component != null)
            {
                return new CustomerViewModel
                {
                    Id = component.Id,
                    CustomerFIO = component.CustomerFIO
                };
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(CustomerBindingModel model)
        {
            Customer component = origin.Customers.FirstOrDefault(rec => rec.CustomerFIO == model.CustomerFIO);
            if (component != null)
            {
                throw new Exception("Уже есть покупатель с таким ФИО");
            }
            int maxId = origin.Customers.Count > 0 ? origin.Customers.Max(rec => rec.Id) : 0;
            origin.Customers.Add(new Customer
            {
                Id = maxId + 1,
                CustomerFIO = model.CustomerFIO
            });

        }
        public void UpdateElement(CustomerBindingModel model)
        {
            Customer component = origin.Customers.FirstOrDefault(rec => rec.CustomerFIO == model.CustomerFIO && rec.Id != model.Id);
            if (component != null)
            {
                throw new Exception("Уже есть клиент с таким ФИО");
            }
            component = origin.Customers.FirstOrDefault(rec => rec.Id == model.Id);
            if (component == null)
            {
                throw new Exception("Элемент не найден");
            }
            component.CustomerFIO = model.CustomerFIO;

        }
        public void DeleteElement(int id)
        {
            Customer component = origin.Customers.FirstOrDefault(rec => rec.Id == id);
            if (component != null)
            {
                origin.Customers.Remove(component);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}