using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RWA_MVC_LeaRezic.Models.ViewModels
{
    public class ReceiptVM
    {
        public int Id { get; set; }
        public string Code { get; set; }

        [Display(Name ="Issue date")]
        public string Date { get; set; }

        [Display(Name ="Credit card number")]
        public string CreditCardNumber { get; set; }

        [Display(Name ="Credit card type")]
        public string CreditCardType { get; set; }

        [Display(Name ="Shop assistant")]
        public string ShopAssistant { get; set; }

        [Display(Name ="Total price")]
        public decimal TotalPrice { get; set; }
    }
}