using RWA_MVC_LeaRezic.BLL.DataManagers;
using RWA_MVC_LeaRezic.Models.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace RWA_MVC_LeaRezic.Controllers
{
    public class CustomerController : Controller
    {

        public ActionResult ViewAll(int? id)
        {
            if (id.HasValue)
            {
                if (CityManager.GetAllEntities().ToList().Exists(g => g.IDGrad == id))
                {
                    ViewBag.cityName = CityManager.GetAllEntities().SingleOrDefault(c => c.IDGrad == id).Naziv;
                    ViewBag.cityId = id;
                    var model = CustomerManager.GetAllViewModels().Where(c => c.CityID == id).ToList();
                    return View(model);
                }
            }
            return RedirectToAction("BrowseAll", "Country");
        }

        // dohvaća ime grada po id-u
        [ChildActionOnly]
        public ActionResult GetCityName(int id)
        {
            var name = CityManager.GetAllEntities().SingleOrDefault(c => c.IDGrad == id).Naziv;
            return Content(name);
        }

        // get i post za dodavanje kupca
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create(int? id)
        {
            var model = CustomerManager.CreateEmptyViewModel();
            if (id.HasValue)
            {
                if (CityManager.GetAllEntities().ToList().Exists(c=>c.IDGrad == id))
                {
                    model.CityID = (int)id;
                }
            }
            ViewBag.allCities = CityManager.GetAllEntities().OrderBy(c => c.Naziv);
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create(CustomerVM customer)
        {
            if (ModelState.IsValid)
            {
                CustomerManager.Add(customer);
                return RedirectToAction("ViewAll", new { id = customer.CityID });
            }
            else
            {
                ViewBag.allCities = CityManager.GetAllEntities().OrderBy(c => c.Naziv);
                return View(customer);
            }
        }

        // get i post za edit
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int id)
        {
            var model = CustomerManager.Get(id);
            ViewBag.allCities = CityManager.GetAllEntities().OrderBy(c => c.Naziv);
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(CustomerVM customer)
        {
            if (ModelState.IsValid)
            {
                CustomerManager.Update(customer);
                return RedirectToAction("ViewAll", new { id = customer.CityID });
            }
            else
            {
                ViewBag.allCities = CityManager.GetAllEntities().OrderBy(c => c.Naziv);
                return View(customer);
            }
        }
    }
}