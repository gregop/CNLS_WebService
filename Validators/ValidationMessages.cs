using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNSL_WepService.Validators
{
    public class ValidationMessages
    {
        private string? _message;

        public string StrictlyPositiveIntegerValMessage(string property)
        {
            _message = $"{property} should be a positive integer";
            return _message;
        }

        public string StrictlyPositiveFloatValMessage(string property)
        {
            _message = $"{property} should be a positive number";
            return _message;
        }
    }
}
