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
            var inputEmail = customerVM.Email.Trim().ToLower();

            bool exists = CustomerManager.GetAllEntities()
                                        .Select(k => Utils.GetCleanOrDummyString(k.Email))
                                        .ToList()
                                        .Exists(e => e == inputEmail);

            // ako ne postoji takav email, ili ako postoji ali je to on sam - vraća true, u suprotnom validation error
            if (exists)
            {
                var entity = CustomerManager.GetAllEntities().FirstOrDefault(c => Utils.GetCleanOrDummyString(c.Email) == inputEmail);
                if (entity.IDKupac != customerVM.IDCustomer)
                {
                    return new ValidationResult("Sorry, e-mail already exists!");
                }
            }
            return ValidationResult.Success;
        }
    }
}