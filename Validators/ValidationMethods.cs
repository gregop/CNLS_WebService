using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNSL_WepService.Validators
{
    public class ValidationMethods
    {
        public bool IsValidPositiveInteger(object value)
        {
            bool isNumeric = int.TryParse(value.ToString(), out int number);

            if (isNumeric && number > 0)
            {
                return true;
            }
            else { return false; }
        }


        public bool IsValidPositiveNumber(object value)
        {
            bool isNumeric = float.TryParse(value.ToString(), out float number);

            if (isNumeric && number > 0)
            {
                return true;
            }
            else { return false; }
        }
    }
}
