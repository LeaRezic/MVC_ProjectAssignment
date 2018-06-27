using RWA_MVC_LeaRezic.BLL.DataManagers;
using RWA_MVC_LeaRezic.Models.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace RWA_MVC_LeaRezic.BLL.CustomValidators
{
    public class UniqueEmailValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customerVM = validationContext.ObjectInstance as CustomerVM;
            var entity = CustomerManager.GetAllEntities().FirstOrDefault(c => c.Email == customerVM.Email);

            // ako ne postoji takav email, ili ako postoji ali je to on sam - vraća true, u suprotnom validation error
            if (entity == null)
            {
                return ValidationResult.Success;
            }
            else if (entity.IDKupac == customerVM.IDCustomer)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Sorry, e-mail already exists!");
            }
        }
    }
}