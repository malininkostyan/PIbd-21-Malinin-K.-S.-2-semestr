using AbstractFlowerShopServiceDAL1.BindingModel;
using AbstractFlowerShopServiceDAL1.Interfaces;
using System;
using System.Web.Http;

namespace AbstractFlowerShopRestApi.Controllers
{
    public class LogController : ApiController
    {
        private readonly ILogService _service;
        public LogController(ILogService service)
        {
            _service = service;
        }
        [HttpGet]
        public IHttpActionResult GetStoragesLoad()
        {
            var list = _service.GetStoragesLoad();
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }
        [HttpPost]
        public IHttpActionResult GetCustomerBookings(LogBindingModel model)
        {
            var list = _service.GetCustomerBookings(model);
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }
        [HttpPost]
        public void SaveBouquetPrice(LogBindingModel model)
        {
            _service.SaveBouquetPrice(model);
        }
        [HttpPost]
        public void SaveStoragesLoad(LogBindingModel model)
        {
            _service.SaveStoragesLoad(model);
        }
        [HttpPost]
        public void SaveCustomerBookings(LogBindingModel model)
        {
            _service.SaveCustomerBookings(model);
        }
    }
}
