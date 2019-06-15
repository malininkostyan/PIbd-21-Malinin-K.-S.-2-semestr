using AbstractFlowerShopServiceDAL.BindingModel;
using AbstractFlowerShopServiceDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationFlowerShop.Controllers
{
    public class ElementController : Controller
    {
        private IElementService service = Globals.ElementService;
        // GET: Elements
        public ActionResult Index()
        {
            return View(service.ListGet());
        }


        // GET: Elements/Create
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult CreatePost()
        {
            service.AddElement(new ElementBindingModel
            {
                ElementName = Request["ElementName"]
            });
            return RedirectToAction("Index");
        }


        // GET: Elements/Edit/5
        public ActionResult Edit(int id)
        {
            var viewModel = service.ElementGet(id);
            var bindingModel = new ElementBindingModel
            {
                Id = id,
                ElementName = viewModel.ElementName
            };
            return View(bindingModel);
        }


        [HttpPost]
        public ActionResult EditPost()
        {
            service.UpdateElement(new ElementBindingModel
            {
                Id = int.Parse(Request["Id"]),
                ElementName = Request["ElementName"]
            });
            return RedirectToAction("Index");
        }


        // GET: Elements/Delete/5
        public ActionResult Delete(int id)
        {
            service.DeleteElement(id);
            return RedirectToAction("Index");
        }
    }
}