using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ch10.Mvc.Web.Models
{
    [CustomValidation(typeof(CustomValidationModel), "ValidateAtLeastOneIsChecked")]
    public class CustomValidationModel
    {
        [Required( ErrorMessage="This box must be checked")] //this does not work
        [CustomValidation(typeof(CustomValidationModel), "ValidateIMustBeCheckedTrue")] 
        [Display(Name="I Must Be Checked")]
        public bool IMustBeChecked { get; set; }

        [Display(Name = "You can check me")]
        public bool AtLeastOneShouldBeCheckedOne { get; set; }
        [Display(Name = "Or Me")]
        public bool AtLeastOneShouldBeCheckedTwo { get; set; }
        [Display(Name = "And even me")]
        public bool AtLeastOneShouldBeCheckedThree { get; set; }

        public static ValidationResult ValidateIMustBeCheckedTrue(bool value, ValidationContext vContext)
        {
            if (value)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("IMustBeChecked must be set to true");
        }

        public static ValidationResult ValidateAtLeastOneIsChecked(CustomValidationModel cvm, ValidationContext vContext)
        {
            if (cvm.AtLeastOneShouldBeCheckedOne || cvm.AtLeastOneShouldBeCheckedTwo || cvm.AtLeastOneShouldBeCheckedThree)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("At lease one of checkboxes must be checked");
        }


        
    }
}