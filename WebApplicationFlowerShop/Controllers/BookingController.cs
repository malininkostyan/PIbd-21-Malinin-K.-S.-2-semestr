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
    public class BookingController : Controller
    {
        private IBouquetService bouquetsService = Globals.BouquetService;
        private IServiceMain bouquetBookingService = Globals.MainService;
        private ICustomerService customerService = Globals.CustomerService;


        // GET: Booking
        public ActionResult Index()
        {
            return View(bouquetBookingService.ListGet());
        }

        public ActionResult Create()
        {
            var bouquets = new SelectList(bouquetsService.ListGet(), "Id", "BouquetName");
            var customers = new SelectList(customerService.ListGet(), "Id", "CustomerFIO");
            ViewBag.Bouquets = bouquets;
            ViewBag.Customers = customers;
            return View();
        }

        [HttpPost]
        public ActionResult CreatePost()
        {
            var customerId = int.Parse(Request["CustomerId"]);
            var bouquetId = int.Parse(Request["BouquetId"]);
            var bouquetCount = int.Parse(Request["Amount"]);
            var totalCost = CalcSum(bouquetId, bouquetCount);

            bouquetBookingService.CreateBooking(new BookingBindingModel
            {
                CustomerId = customerId,
                BouquetId = bouquetId,
                Amount = bouquetCount,
                Total = totalCost

            });
            return RedirectToAction("Index");
        }

        private Decimal CalcSum(int bouquetId, int bouquetCount)
        {
            BouquetViewModel bouquet = bouquetsService.ElementGet(bouquetId);
            return bouquetCount * bouquet.Cost;
        }

        public ActionResult SetStatus(int id, string status)
        {
            try
            {
                switch (status)
                {
                    case "Processing":
                        bouquetBookingService.TakeBookingInWork(new BookingBindingModel { Id = id });
                        break;
                    case "Ready":
                        bouquetBookingService.FinishBooking(new BookingBindingModel { Id = id });
                        break;
                    case "Paid":
                        bouquetBookingService.PayBooking(new BookingBindingModel { Id = id });
                        break;
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
            }
            return RedirectToAction("Index");
        }
    }
}