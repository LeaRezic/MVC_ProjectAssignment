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
            ReceiptVM viewModel = new ReceiptVM();
            viewModel.Id = entity.IDRacun;
            viewModel.Code = entity.BrojRacuna;
            viewModel.Date = entity.DatumIzdavanja.ToShortDateString();
            if (entity.KreditnaKartica != null)
            {
                viewModel.CreditCardNumber = Utils.CheckIfNull(entity.KreditnaKartica.Broj);
                viewModel.CreditCardType = Utils.CheckIfNull(entity.KreditnaKartica.Tip);
            }
            if (entity.Komercijalist != null)
            {
                viewModel.ShopAssistant = Utils.CheckIfNull(entity.Komercijalist.Prezime)
                                + " " + Utils.CheckIfNull(entity.Komercijalist.Ime);
            }
            viewModel.TotalPrice = entity.Stavka.Select(s => s.UkupnaCijena).Sum();
            viewModel.CustomerId = entity.Kupac.IDKupac;
            return viewModel;
        }


    }
}