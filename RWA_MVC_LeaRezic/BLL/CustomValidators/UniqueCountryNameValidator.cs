using RWA_MVC_LeaRezic.BLL.DataManagers;
using RWA_MVC_LeaRezic.Models.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace RWA_MVC_LeaRezic.BLL.CustomValidators
{
    public class UniqueCountryNameValidator : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var countryVM = validationContext.ObjectInstance as CountryVM;
            var inputName = countryVM.Name.Trim().ToLower();
            var entity = CountryManager.GetAllEntities().FirstOrDefault(c => c.Naziv.ToLower() == inputName);

            // ako ne postoji takav email, ili ako postoji ali je to on sam - vraća true, u suprotnom validation error
            if (entity == null)
            {
                return ValidationResult.Success;
            }
            else if (entity.IDDrzava == countryVM.IDCountry)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Country name must be unique.");
            }
        }
    }
}