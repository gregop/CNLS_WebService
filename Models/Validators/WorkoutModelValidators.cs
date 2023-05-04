using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNSL_WepService.Models.Validators.WorkoutModelValidators
{
    /*
     * CUSTOM DATA ATTRIBUTE VALIDATOR: StrictlyPositivePropery
     */
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class StrictlyPositivePropery : ValidationAttribute
    {
        private readonly string _property_name;
        public StrictlyPositivePropery(string property_name)
        {
            _property_name = property_name;
        }

        protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult($"The {_property_name} field is required");
            }

            // check if value is number
            bool isNumber = int.TryParse(value.ToString(), out int number);
            
            if (isNumber && number > 0)
            {
                return ValidationResult.Success;
                
            }
            else
            {
                return new ValidationResult($"{_property_name} field must be a positive integer");
                
            }

            
        }
    }
}