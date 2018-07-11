using RWA_MVC_LeaRezic.DAL.Entities;
using RWA_MVC_LeaRezic.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace RWA_MVC_LeaRezic.BLL.DataManagers
{
    public class ReceiptItemManager : ManagerBase
    {
        public static IEnumerable<ReceiptItemVM> GetAllForReceipt(int id)
        {
            return _repository.GetAllReceiptItems()
                                .Where(i => i.Racun.IDRacun == id)
                                .Select(i => ConvertEntityToViewModel(i))
                                .ToList();
        }

        private static ReceiptItemVM ConvertEntityToViewModel(Stavka entity)
        {
            return new ReceiptItemVM
            {
                Product = GetStringOrNotDefined(entity.Proizvod.Naziv),
                Color = GetStringOrNotDefined(entity.Proizvod.Boja),
                Subcategory = GetStringOrNotDefined(entity.Proizvod.Potkategorija.Naziv),
                Category = GetStringOrNotDefined(entity.Proizvod.Potkategorija.Kategorija.Naziv),
                Price = decimal.Round(entity.CijenaPoKomadu,2),
                Amount = entity.Kolicina,
                DiscountPercentage = decimal.Round(entity.PopustUPostocima,2),
                TotalPrice = decimal.Round(entity.UkupnaCijena,2)
            };
        }

        private static string GetStringOrNotDefined(object name)
        {
            return name != null ? name.ToString() : "Not defined";
        }
    }
}