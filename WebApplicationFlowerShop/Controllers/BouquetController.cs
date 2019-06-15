using AbstractFlowerShopServiceDAL.BindingModel;
using AbstractFlowerShopServiceDAL.Interfaces;
using AbstractFlowerShopServiceDAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationFlowerShop.Controllers
{
    public class BouquetController : Controller
    {
        private IBouquetService bouquetService = Globals.BouquetService;
        private IElementService elementService = Globals.ElementService;

        // GET: Bouquets
        public ActionResult Index()
        {
            if (Session["Bouquet"] == null)
            {
                var bouquet = new BouquetViewModel();
                bouquet.BouquetElements = new List<BouquetElementViewModel>();
                Session["Bouquet"] = bouquet;
            }
            return View((BouquetViewModel)Session["Bouquet"]);
        }

        public ActionResult AddElement()
        {
            var ingredients = new SelectList(elementService.ListGet(), "Id", "ElementName");
            ViewBag.Element = ingredients;
            return View();
        }

        [HttpPost]
        public ActionResult AddElementPost()
        {
            var bouquet = (BouquetViewModel)Session["Bouquet"];
            var ingredient = new BouquetElementViewModel
            {
                ElementId = int.Parse(Request["Id"]),
                ElementName = elementService.ElementGet(int.Parse(Request["Id"])).ElementName,
                Amount = int.Parse(Request["Amount"])
            };
            bouquet.BouquetElements.Add(ingredient);
            Session["Bouquet"] = bouquet;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult CreateBouquetPost()
        {
            var bouquet = (BouquetViewModel)Session["Bouquet"];
            var elementBouquet = new List<BouquetElementBindingModel>();
            for (int i = 0; i < bouquet.BouquetElements.Count; ++i)
            {
                elementBouquet.Add(new BouquetElementBindingModel
                {
                    Id = bouquet.BouquetElements[i].Id,
                    BouquetId = bouquet.BouquetElements[i].BouquetId,
                    ElementId = bouquet.BouquetElements[i].ElementId,
                    Amount = bouquet.BouquetElements[i].Amount
                });
            }
            bouquetService.AddElement(new BouquetBindingModel
            {
                BouquetName = Request["BouquetName"],
                Cost = Convert.ToDecimal(Request["Cost"]),
                BouquetElements = elementBouquet
            });
            Session.Remove("Bouquet");
            return RedirectToAction("Index", "Bouquet");
        }
    }
}