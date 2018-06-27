using RWA_MVC_LeaRezic.BLL.DataManagers;
using RWA_MVC_LeaRezic.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RWA_MVC_LeaRezic.BLL.CustomValidators
{
    public class UniqueCityNameValidator : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var cityVM = validationContext.ObjectInstance as CityVM;
            var entity = CityManager.GetAllEntities().SingleOrDefault(c => c.Naziv == cityVM.Name && c.DrzavaID == cityVM.CountryID);

            // ako ne postoji takav naziv u toj državi, ili ako postoji ali je to on sam - vraća true, u suprotnom validation error
            if (entity == null)
            {
                return ValidationResult.Success;
            }
            else if (entity.IDGrad == cityVM.IDCity)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("City name must be unique within the same country.");
            }
        }
    }
}