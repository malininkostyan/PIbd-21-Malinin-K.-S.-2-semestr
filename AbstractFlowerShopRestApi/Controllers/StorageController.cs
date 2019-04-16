using AbstractFlowerShopServiceDAL1.BindingModel;
using AbstractFlowerShopServiceDAL1.Interfaces;
using System;
using System.Web.Http;

namespace AbstractFlowerShopRestApi.Controllers
{
    public class StorageController : ApiController
    {
        private readonly IStorageService _service;
        public StorageController(IStorageService service)
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
        public void AddElement(StorageBindingModel model)
        {
            _service.AddElement(model);
        }
        [HttpPost]
        public void UpdateElement(StorageBindingModel model)
        {
            _service.UpdateElement(model);
        }
        [HttpPost]
        public void DeleteElement(StorageBindingModel model)
        {
            _service.DeleteElement(model.Id);
        }
    }
}