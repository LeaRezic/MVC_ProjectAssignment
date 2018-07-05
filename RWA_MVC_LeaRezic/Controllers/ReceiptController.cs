using RWA_MVC_LeaRezic.BLL.DataManagers;
using RWA_MVC_LeaRezic.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RWA_MVC_LeaRezic.Controllers
{
    public class ReceiptController : Controller
    {
        // GET: Receipt
        public ActionResult ViewByCustomer(int id)
        {
            var Model = ReceiptManager.GetAllForCustomer(id);
            ViewBag.customerId = id;
            return View(Model);
        }

        [ChildActionOnly]
        public ActionResult GetCustomerName(int id)
        {
            return Content($"{CustomerManager.Get(id).FirstName} {CustomerManager.Get(id).LastName}");
        }

    }
}