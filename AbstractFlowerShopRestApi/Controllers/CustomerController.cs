using AbstractFlowerShopServiceDAL1.BindingModel;
using AbstractFlowerShopServiceDAL1.Interfaces;
using System;
using System.Web.Http;

namespace AbstractFlowerShopRestApi.Controllers
{
    public class CustomerController : ApiController
    {
        private readonly ICustomerService _service;
        public CustomerController(ICustomerService service)
        {
            _service = service;
        }
        [HttpGet]
        public IHttpActionResult ListGet()
        {
            var list = _service.ListGet();
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }   
            return Ok(list);
        }
        [HttpGet]
        public IHttpActionResult ElementGet(int id)
        {
            var element = _service.ElementGet(id);
            if (element == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(element);
        }
        [HttpPost]
        public void AddElement(CustomerBindingModel model)
        {
            _service.AddElement(model);
        }
        [HttpPost]
        public void UpdateElement(CustomerBindingModel model)
        {
            _service.UpdateElement(model);
        }
        [HttpPost]
        public void DeleteElement(CustomerBindingModel model)
        {
            _service.DeleteElement(model.Id);
        }
    }
}