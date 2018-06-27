using RWA_MVC_LeaRezic.BLL.CustomValidators;
using System.ComponentModel.DataAnnotations;

namespace RWA_MVC_LeaRezic.Models.ViewModels
{
    public class CountryVM
    {
        public int IDCountry { get; set; }

        [Required]
        [UniqueCountryNameValidator]
        public string Name { get; set; }

        public override string ToString() => $"{Name}";
    }
}