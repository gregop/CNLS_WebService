using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Core.Validators
{
    public static class DataValidator<T>
    {
        private static readonly T? _dataObject;

        private static List<ValidationResult>? _results;

        private static bool _valid = false;

        private static ValidationContext? _context;


        public static OperationalResult<Tuple<bool, List<ValidationResult>>> TryValidate(T dataObject)
        {
            try
            {
                if (dataObject == null) { throw new ArgumentNullException(nameof(dataObject)); }

                _context = new ValidationContext(dataObject, null, null);
                _results = new List<ValidationResult>();
                _valid = Validator.TryValidateObject(dataObject, _context, _results, true);

                return OperationalResult<Tuple<bool, List<ValidationResult>>>.SuccessResult(Tuple.Create(_valid, _results));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception at {MethodBase.GetCurrentMethod()} : {ex.Message}");
                return OperationalResult<Tuple<bool, List<ValidationResult>>>.FailureResult(ex);
            }

        }
    }
}
