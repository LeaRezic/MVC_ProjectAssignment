using RWA_MVC_LeaRezic.BLL.CustomValidators;
using System.ComponentModel.DataAnnotations;

namespace RWA_MVC_LeaRezic.Models.ViewModels
{
    public class CityVM
    {
        public int IDCity { get; set; }

        [Required]
        [UniqueCityNameValidator]
        public string Name { get; set; }

        public int CountryID { get; set; }
    }
}