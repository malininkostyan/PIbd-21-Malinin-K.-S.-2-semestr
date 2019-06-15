using AbstractFlowerShopServiceDAL.Interfaces;
using AbstractFlowerShopServiceDAL.BindingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationFlowerShop.Controllers
{
    public class AddElementStorageController : Controller
    {
        private IElementService ingredientService = Globals.ElementService;
        private IStorageService storageService = Globals.StorageService;
        private IServiceMain mainService = Globals.MainService;

        // GET: AddElementStorage
        public ActionResult Index()
        {
            var ingredients = new SelectList(ingredientService.ListGet(), "Id", "ElementName");
            ViewBag.Element = ingredients;

            var storages = new SelectList(storageService.ListGet(), "Id", "StorageName");
            ViewBag.Storages = storages;
            return View();
        }

        [HttpPost]
        public ActionResult AddElementPost()
        {
            mainService.PutElementOnStorage(new StorageElementBindingModel
            {
                ElementId = int.Parse(Request["ElementId"]),
                StorageId = int.Parse(Request["StorageId"]),
                Amount = int.Parse(Request["Amount"])
            });
            return RedirectToAction("Index", "Home");
        }
    }
}