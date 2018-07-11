using RWA_MVC_LeaRezic.DAL.Entities;
using System.Collections.Generic;

namespace RWA_MVC_LeaRezic.DAL.Domain.Repositories
{
    public interface IRepository
    {
        IEnumerable<Drzava> GetAllCountries();
        IEnumerable<Grad> GetAllCities();
        IEnumerable<Kupac> GetAllCustomers();
        IEnumerable<Racun> GetAllReceipts();
        IEnumerable<Stavka> GetAllReceiptItems();
        void InsertOrUpdateKupac(Kupac customer);
        void InsertCity(Grad city);
        void InsertCountry(Drzava country);
    }
}
