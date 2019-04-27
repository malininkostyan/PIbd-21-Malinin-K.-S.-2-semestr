using AbstractFlowerShopServiceDAL1.BindingModel;
using AbstractFlowerShopServiceDAL1.Interfaces;
using System;
using System.Web.Http;

namespace AbstractFlowerShopRestApi.Controllers
{
    public class ExecutorController : ApiController
    {
        private readonly IExecutorService _service;
        public ExecutorController(IExecutorService service)
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
        public void AddElement(ExecutorBindingModel model)
        {
            _service.AddElement(model);
        }
        [HttpPost]
        public void UpdateElement(ExecutorBindingModel model)
        {
            _service.UpdateElement(model);
        }
        [HttpPost]
        public void DeleteElement(ExecutorBindingModel model)
        {
            _service.DeleteElement(model.Id);
        }
    }
}
