using RWA_MVC_LeaRezic.BLL.DataManagers;
using System.Web.Mvc;

namespace RWA_MVC_LeaRezic.Controllers
{
    public class ReceiptController : Controller
    {
        // GET: Receipt
        public ActionResult ViewByCustomer(int id)
        {
            var Model = ReceiptManager.GetAllForCustomer(id);
            ViewBag.cityId = CustomerManager.Get(id).CityID;
            ViewBag.customerId = id;
            return View(Model);
        }

        [ChildActionOnly]
        public ActionResult GetCustomerName(int id)
        {
            return Content($"{CustomerManager.Get(id).ToString()}");
        }

    }
}