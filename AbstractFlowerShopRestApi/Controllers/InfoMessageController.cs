using AbstractFlowerShopServiceDAL1.BindingModel;
using AbstractFlowerShopServiceDAL1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AbstractFlowerShopRestApi.Controllers
{
    public class InfoMessageController : ApiController
    {
        private readonly IInfoMessageService _service;
        public InfoMessageController(IInfoMessageService service)
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
        public void AddElement(InfoMessageBindingModel model)
        {
            _service.AddElement(model);
        }
    }
}