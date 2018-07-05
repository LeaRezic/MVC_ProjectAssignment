using RWA_MVC_LeaRezic.DAL.Entities;
using RWA_MVC_LeaRezic.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace RWA_MVC_LeaRezic.BLL.DataManagers
{
    public class ReceiptManager : ManagerBase
    {

        public static ReceiptVM Get(int id)
        {
            return ConvertEntityToViewModel(_repository.GetAllReceipts().SingleOrDefault(r => r.IDRacun == id));
        }

        public static IEnumerable<ReceiptVM> GetAllForCustomer(int id)
        {
            return _repository.GetAllReceipts()
                                .Where(r => r.KupacID == id)
                                .Select(r => ConvertEntityToViewModel(r))
                                .ToList();
        }

        private static ReceiptVM ConvertEntityToViewModel(Racun entity)
        {
            return new ReceiptVM
            {
                Id = entity.IDRacun,
                Code = entity.BrojRacuna,
                Date = entity.DatumIzdavanja.ToShortDateString(),
                CreditCardNumber = entity.KreditnaKartica.Broj,
                CreditCardType = entity.KreditnaKartica.Tip,
                ShopAssistant = entity.Komercijalist.Prezime + " " + entity.Komercijalist.Ime,
                TotalPrice = entity.Stavka.Select(s => s.UkupnaCijena).Sum()
            };
        }
    }
}