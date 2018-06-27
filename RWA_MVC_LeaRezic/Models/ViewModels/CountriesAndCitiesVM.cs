using RWA_MVC_LeaRezic.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RWA_MVC_LeaRezic.Models.ViewModels
{
    public class CountriesAndCitiesVM
    {
        public List<Drzava> Countries { get; set; }
        public List<Grad> Cities { get; set; }

        public CityVM CreatedCity { get; set; }
        public CountryVM CreatedCountry { get; set; }

        public CountriesAndCitiesVM()
        {
            Countries = new List<Drzava>();
            Cities = new List<Grad>();
        }
    }
}