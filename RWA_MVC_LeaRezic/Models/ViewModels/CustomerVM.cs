using RWA_MVC_LeaRezic.BLL.CustomValidators;
using System.ComponentModel.DataAnnotations;

namespace RWA_MVC_LeaRezic.Models.ViewModels
{
    public class CustomerVM
    {
        public int IDCustomer { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [UniqueEmailValidator]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        public string Telephone { get; set; }

        [Display(Name = "City")]
        public int CityID { get; set; }
    }
}