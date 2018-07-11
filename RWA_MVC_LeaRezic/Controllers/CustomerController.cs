using RWA_MVC_LeaRezic.BLL.DataManagers;
using RWA_MVC_LeaRezic.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RWA_MVC_LeaRezic.Controllers
{
    public class CustomerController : Controller
    {

        // dohvaća sve ak nije specificiran grad, sad je bezveze % 7 == 0 da mi ih vrati manje
        public ActionResult ViewAll(int? id)
        {
            var model = new List<CustomerVM>();
            if (id.HasValue)
            {
                ViewBag.cityName = CityManager.GetAllEntities().SingleOrDefault(c => c.IDGrad == id).Naziv;
                model = CustomerManager.GetAllViewModels().Where(c => c.CityID == id).ToList();
            }
            else
            {
                //model = CustomerManager.GetAllViewModels().Where(c => c.IDCustomer % 7 == 0).ToList();
                return RedirectToAction("BrowseAll", "Country");
            }
            return View(model);
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
        [Authorize(Roles ="Administrator")]
        public ActionResult Create()
        {
            var model = CustomerManager.CreateEmptyViewModel();
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
                return RedirectToAction("ViewAll");
            }
            else
            {
                ViewBag.allCities = CityManager.GetAllEntities().OrderBy(c=>c.Naziv);
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