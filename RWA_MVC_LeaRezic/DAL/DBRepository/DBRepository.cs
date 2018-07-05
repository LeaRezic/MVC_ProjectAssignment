using RWA_MVC_LeaRezic.DAL.Domain.Repositories;
using RWA_MVC_LeaRezic.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RWA_MVC_LeaRezic.DAL.DBRepository
{
    public class DBRepository : IRepository
    {
        public IEnumerable<Grad> GetAllCities()
        {
            try
            {
                using (var _dbContext = new DBContext())
                {
                    //return _dbContext.Grad.Include("Drzava").ToList();
                    return _dbContext.Grad.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Drzava> GetAllCountries()
        {
            try
            {
                using (var _dbContext = new DBContext())
                {
                    return _dbContext.Drzava.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Kupac> GetAllCustomers()
        {
            try
            {
                using (var _dbContext = new DBContext())
                {
                    return _dbContext.Kupac.Include("Grad").Include("Grad.Drzava").ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Racun> GetAllReceipts()
        {
            try
            {
                using (var _dbContext = new DBContext())
                {
                    return _dbContext.Racun.Include("Komercijalist")
                                            .Include("KreditnaKartica")
                                            .Include(r => r.Stavka)
                                            .ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertCity(Grad city)
        {
            try
            {
                using (var _dbContext = new DBContext())
                {
                    _dbContext.Entry(city).State = EntityState.Added;
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertCountry(Drzava country)
        {
            try
            {
                using (var _dbContext = new DBContext())
                {
                    _dbContext.Entry(country).State = EntityState.Added;
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void InsertOrUpdateKupac(Kupac customer)
        {
            try
            {
                using (var _dbContext = new DBContext())
                {
                    _dbContext.Entry(customer).State = customer.IDKupac == 0 ?
                                                        EntityState.Added :
                                                        EntityState.Modified;
                    _dbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}