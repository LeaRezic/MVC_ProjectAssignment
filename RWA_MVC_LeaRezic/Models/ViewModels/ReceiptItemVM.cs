using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RWA_MVC_LeaRezic.Models.ViewModels
{
    public class ReceiptItemVM
    {
        [Display(Name ="Product")]
        public string Product { get; set; }

        [Display(Name = "Color")]
        public string Color { get; set; }

        [Display(Name ="Subcategory")]
        public string Subcategory { get; set; }

        [Display(Name ="Category")]
        public string Category { get; set; }

        [Display(Name ="Price")]
        public decimal Price { get; set; }

        [Display(Name ="Discount (percentage)")]
        public decimal DiscountPercentage { get; set; }

        [Display(Name ="Amount")]
        public int Amount { get; set; }

        [Display(Name ="Total price")]
        public decimal TotalPrice { get; set; }
    }
}