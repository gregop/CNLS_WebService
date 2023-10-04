using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Core.Validators
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class StrictlyPositiveProperty : ValidationAttribute
    {
        private readonly string _property_name;

        public StrictlyPositiveProperty(string property_name)
        {
            _property_name = property_name;
        }

        // Checks if object value is numeric
        public static bool IsNumericAndPositive(object value)
        {
            bool isInt = int.TryParse(value.ToString(), out int _int);
            bool isDouble = double.TryParse(value.ToString(), out double _double);
            if (isInt || isDouble)
            {
                return _int > 0 || _double > 0.0;
            }
            else
            {
                return false;
            };

        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                // Property calories is not required, we should not throw validationError
                // Instead we should define it as 0 and return validation success
                if (_property_name == "calories")
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult($"The {_property_name} field is requireed");

                }
            }

            // check if value is number           
            if (IsNumericAndPositive(value))
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
