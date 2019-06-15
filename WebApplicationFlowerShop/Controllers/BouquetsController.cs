using AbstractFlowerShopServiceDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationFlowerShop.Controllers
{
    public class BouquetsController : Controller
    {
        public IBouquetService service = Globals.BouquetService;
        // GET: Bouquets
        public ActionResult Index()
        {
            return View(service.ListGet());
        }

        public ActionResult Delete(int id)
        {
            service.DeleteElement(id);
            return RedirectToAction("Index");
        }
    }
}