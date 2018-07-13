using RWA_MVC_LeaRezic.BLL.DataManagers;
using RWA_MVC_LeaRezic.DAL.Entities;
using RWA_MVC_LeaRezic.Models.ViewModels;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace RWA_MVC_LeaRezic.Controllers
{

    public class CountryController : Controller
    {
        // GET: Country
        public ActionResult BrowseAll()
        {
            var model = new CountriesAndCitiesVM();
            // ovo mi je zapravo nepotrebno ako ću preko ajax-a dohvaćat
            model.Countries = CountryManager.GetAllEntities().OrderBy(c => c.Naziv).ToList();
            model.Cities = CityManager.GetAllEntities().ToList();
            model.CreatedCountry = CountryManager.CreateEmptyViewModel();
            return View(model);
        }

        // AJAX - dohvaća gradove za državu
        public ActionResult GetCitiesForCountry(int id)
        {
            // tu moram pitat kaj je s asinkronim ajax-om i lazy-loadingom u Entity-ju
            List<Grad> cities = CityManager.GetAllEntities()
                                           .Where(c => c.DrzavaID == id)
                                           .OrderBy(c => c.Naziv)
                                           .ToList();
            return Json(cities, JsonRequestBehavior.AllowGet);
        }

        // Dodaje novu državu
        //[Authorize(Roles ="Administrator")]
        public ActionResult AddCountry(CountryVM c)
        {
            if (!User.IsInRole("Administrator"))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
            else if (ModelState.IsValid)
            {
                CountryManager.AddCountry(c);
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            return new HttpStatusCodeResult(HttpStatusCode.NotModified);
        }

        // Dodaje novi grad u državu
        //[Authorize(Roles = "Administrator")]
        public ActionResult AddCity(CityVM c)
        {
            if (!User.IsInRole("Administrator"))
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }
            else if (ModelState.IsValid)
            {
                CityManager.AddCity(c);
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            return new HttpStatusCodeResult(HttpStatusCode.NotModified);
        }

        // AJAX - vrati sve države (jer se mora osvježit)
        public ActionResult GetAllCountries()
        {
            List<Drzava> countries = CountryManager.GetAllEntities().OrderBy(c => c.Naziv).ToList();
            return Json(countries, JsonRequestBehavior.AllowGet);
        }

        // test za ajax
        public ActionResult AjaxTest()
        {
            return Json("patka iz kontrolera", JsonRequestBehavior.AllowGet);
        }
    }
}