using RWA_MVC_LeaRezic.DAL.Domain.Repositories;
using RWA_MVC_LeaRezic.DAL.Entities;
using RWA_MVC_LeaRezic.DAL.Infrastructure;
using RWA_MVC_LeaRezic.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace RWA_MVC_LeaRezic.BLL.DataManagers
{
    public class CountryManager : ManagerBase
    {

        // DOHVAĆANJE svih entiteta / modela
        public static IEnumerable<Drzava> GetAllEntities()
        {
            return _repository.GetAllCountries().OrderBy(c => c.Naziv).ToList();
        }

        public static IEnumerable<CountryVM> GetAllViewModels()
        {
            return GetAllEntities().Select(e => convertEntityToViewModel(e)).ToList();
        }

        // CREATE i ADD
        public static CountryVM CreateEmptyViewModel()
        {
            return new CountryVM
            {
                IDCountry = 0
            };
        }

        public static void AddCountry(CountryVM c)
        {
            _repository.InsertCountry(convertViewModelToEntity(c));
        }

        // POMOĆNE
        // privatne metode za pretvaranje entiy <-> model
        private static CountryVM convertEntityToViewModel(Drzava entity)
        {
            return new CountryVM
            {
                IDCountry = entity.IDDrzava,
                Name = entity.Naziv
            };
        }

        private static Drzava convertViewModelToEntity(CountryVM viewModel)
        {
            return new Drzava
            {
                IDDrzava = viewModel.IDCountry,
                Naziv = Utils.GetCleanTitleString(viewModel.Name)
            };
        }
    }
}