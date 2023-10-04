using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Core.Validators.ValidationHelpers
{
    public class ValidationHelper
    {
        private List<string> _validationErrors;

        public ValidationHelper()
        {
            _validationErrors = new List<string>();
        }

        public bool IsValid()
        {
            return _validationErrors.Count() == 0;
        }

        public void AddError(string errorMessage)
        {
            _validationErrors.Add(errorMessage);
        }

        public List<string> GetErrorMessages()
        {
            return _validationErrors;
        }

    }
}
