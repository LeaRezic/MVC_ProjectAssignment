using RWA_MVC_LeaRezic.DAL.Domain.Repositories;
using RWA_MVC_LeaRezic.DAL.Entities;
using RWA_MVC_LeaRezic.DAL.Infrastructure;
using RWA_MVC_LeaRezic.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RWA_MVC_LeaRezic.BLL.DataManagers
{
    public class CustomerManager
    {
        private static IRepository _repository = RepositoryFactory.GetDefaultInstance();

        // dohvaća sve entity kupce
        public static IEnumerable<Kupac> GetAllEntities()
        {
            return _repository.GetAllCustomers();
        }

        // vraća kolekciju customer view modela
        public static IEnumerable<CustomerVM> GetAllViewModels()
        {
            return _repository.GetAllCustomers().Select(c => convertEntityToViewModel(c)).ToList();
        }

        // vraća praznog ViewModela customer
        public static CustomerVM CreateEmptyViewModel()
        {
            return new CustomerVM
            {
                IDCustomer = 0,
                CityID = _repository.GetAllCities().OrderBy(c => c.IDGrad).FirstOrDefault().IDGrad
            };
        }

        // dohvaća customer view model po id-u
        public static CustomerVM Get(int id)
        {
            var entity = _repository.GetAllCustomers().SingleOrDefault(c => c.IDKupac == id);
            if (entity != null)
            {
                return convertEntityToViewModel(entity);
            }
            else
            {
                throw new Exception("No such customer!");
            }
        }

        // za spremanje novog kupca
        public static void Add(CustomerVM customerVM)
        {
            InsertOrUpdate(convertViewModelToEntity(customerVM));
        }

        public static void Update(CustomerVM customerVM)
        {
            InsertOrUpdate(convertViewModelToEntity(customerVM));
        }

        // privatna metoda za pretvaranje iz Entitija u ViewModel
        private static CustomerVM convertEntityToViewModel(Kupac c)
        {
            return new CustomerVM
            {
                IDCustomer = c.IDKupac,
                FirstName = c.Ime,
                LastName = c.Prezime,
                Email = c.Email,
                Telephone = c.Telefon,
                CityID = c.Grad.IDGrad
            };
        }

        // privatna metoda za pretvaranje iz ViewModela u Entity
        private static Kupac convertViewModelToEntity(CustomerVM customerVM)
        {
            return new Kupac
            {
                IDKupac = customerVM.IDCustomer,
                Ime = customerVM.FirstName,
                Prezime = customerVM.LastName,
                Email = customerVM.Email,
                Telefon = customerVM.Telephone,
                GradID = customerVM.CityID
            };
        }

        private static void InsertOrUpdate(Kupac entity)
        {
            _repository.InsertOrUpdateKupac(entity);
        }
    }
}