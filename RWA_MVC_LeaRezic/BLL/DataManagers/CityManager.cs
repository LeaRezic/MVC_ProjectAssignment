using RWA_MVC_LeaRezic.DAL.Domain.Repositories;
using RWA_MVC_LeaRezic.DAL.Entities;
using RWA_MVC_LeaRezic.DAL.Infrastructure;
using RWA_MVC_LeaRezic.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace RWA_MVC_LeaRezic.BLL.DataManagers
{
    public class CityManager
    {
        private static IRepository _repository = RepositoryFactory.GetDefaultInstance();

        // DOHVAĆANJE
        // svih entiteta
        public static IEnumerable<Grad> GetAllEntities()
        {
            return _repository.GetAllCities().ToList();
        }
        // svih view-modela prema entitetima
        public static IEnumerable<CityVM> GetAllViewModels()
        {
            return GetAllEntities().Select(e => convertEntityToViewModel(e)).ToList();
        }

        // CREATE i ADD
        public static CityVM CreateEmptyViewModel()
        {
            return new CityVM
            {
                IDCity = 0,
                CountryID = _repository.GetAllCountries().OrderBy(c => c.Naziv).FirstOrDefault().IDDrzava
            };
        }

        public static void AddCity(CityVM c)
        {
            _repository.InsertCity(convertViewModelToEntity(c));
        }


        // pomoćne za pretvaranje
        private static CityVM convertEntityToViewModel(Grad entity)
        {
            return new CityVM
            {
                IDCity = entity.IDGrad,
                Name = entity.Naziv,
                CountryID = entity.Drzava.IDDrzava
            };
        }

        private static Grad convertViewModelToEntity(CityVM viewModel)
        {
            return new Grad
            {
                IDGrad = viewModel.IDCity,
                Naziv = viewModel.Name,
                DrzavaID = viewModel.CountryID
            };
        }

    }
}