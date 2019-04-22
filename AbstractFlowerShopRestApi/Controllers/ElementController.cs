using AbstractFlowerShopServiceDAL1.BindingModel;
using AbstractFlowerShopServiceDAL1.Interfaces;
using System;
using System.Web.Http;

namespace AbstractFlowerShopRestApi.Controllers
{
    public class ElementController : ApiController
    {
        private readonly IElementService _service;
        public ElementController(IElementService service)
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
        public void AddElement(ElementBindingModel model)
        {
            _service.AddElement(model);
        }
        [HttpPost]
        public void UpdateElement(ElementBindingModel model)
        {
            _service.UpdateElement(model);
        }
        [HttpPost]
        public void DeleteElement(ElementBindingModel model)
        {
            _service.DeleteElement(model.Id);
        }
    }
}