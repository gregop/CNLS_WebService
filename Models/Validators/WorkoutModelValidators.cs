﻿using System;
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
                return new ValidationResult($"The {_property_name} field is required");
            }

            // check if value is number
            
            bool isNumericAndPositive = IsNumericAndPositive(value);
            

            if (isNumericAndPositive)
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