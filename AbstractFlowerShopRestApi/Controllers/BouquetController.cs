using AbstractFlowerShopServiceDAL1.BindingModel;
using AbstractFlowerShopServiceDAL1.Interfaces;
using System;
using System.Web.Http;

namespace AbstractFlowerShopRestApi.Controllers
{
    public class BouquetController : ApiController
    {
        private readonly IBouquetService _service;
        public BouquetController(IBouquetService service)
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
        public void AddElement(BouquetBindingModel model)
        {
            _service.AddElement(model);
        }
        [HttpPost]
        public void UpdateElement(BouquetBindingModel model)
        {
            _service.UpdateElement(model);
        }
        [HttpPost]
        public void DeleteElement(BouquetBindingModel model)
        {
            _service.DeleteElement(model.Id);
        }
    }
}