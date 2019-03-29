using AbstractFlowerShopModel;
using AbstractFlowerShopServiceDAL.BindingModel;
using AbstractFlowerShopServiceDAL.Interfaces;
using AbstractFlowerShopServiceDAL.ViewModel;
using System;
using System.Collections.Generic;

namespace AbstractFlowerShopServiceImplementList.Implementations
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
            List<CustomerViewModel> result = new List<CustomerViewModel>();
            for (int i = 0; i < origin.Customers.Count; ++i)
            {
                result.Add(new CustomerViewModel
                {
                    Id = origin.Customers[i].Id,
                    CustomerFIO = origin.Customers[i].CustomerFIO
                });
            }
        return result;
        }
        public CustomerViewModel ElementGet(int id)
        {
            for (int i = 0; i < origin.Customers.Count; ++i)
            {
                if (origin.Customers[i].Id == id)
                {
                    return new CustomerViewModel
                    {
                        Id = origin.Customers[i].Id,
                        CustomerFIO = origin.Customers[i].CustomerFIO
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(CustomerBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < origin.Customers.Count; ++i)
            {
                if (origin.Customers[i].Id > maxId)
                {
                    maxId = origin.Customers[i].Id;
                }
                if (origin.Customers[i].CustomerFIO == model.CustomerFIO)
                {
                    throw new Exception("Уже есть клиент с таким ФИО");
                }
            }
            origin.Customers.Add(new Customer
            {
                Id = maxId + 1,
                CustomerFIO = model.CustomerFIO
            });
        }
        public void UpdateElement(CustomerBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < origin.Customers.Count; ++i)
            {
                if (origin.Customers[i].Id == model.Id)
                {
                    index = i;
                }
                if (origin.Customers[i].CustomerFIO == model.CustomerFIO &&
                origin.Customers[i].Id != model.Id)
                {
                    throw new Exception("Уже есть клиент с таким ФИО");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            origin.Customers[index].CustomerFIO = model.CustomerFIO;
        }
        public void DeleteElement(int id)
        {
            for (int i = 0; i < origin.Customers.Count; ++i)
        {
                if (origin.Customers[i].Id == id)
                {
                    origin.Customers.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
    }
}