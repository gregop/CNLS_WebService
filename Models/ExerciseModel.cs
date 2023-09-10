using System.ComponentModel.DataAnnotations;
using CNSL_WepService.Interfaces;
using CNSL_WepService.Models.Validators;

namespace CNSL_WepService.Models
{
    public class ExerciseModel : IExercise
    {

        private int _reps;

        private int _sets;

        private float _weight;

        private ValidationMethods _validationMethods;

        private ValidationMessages _validationMessages;

        private ValidationHelper _validationHelper;


        public ExerciseModel()
        {
            _validationHelper = new ValidationHelper();
            _validationMessages = new ValidationMessages();
            _validationMethods = new ValidationMethods();  
        }

        public void DefineNoReps(object reps)
        {
            if (_validationMethods.IsValidPositiveInteger(reps))
            {
                _reps = Convert.ToInt32(reps);
                return;
            }
            else
            {
                _validationHelper.AddError(_validationMessages.StrictlyPositiveIntegerValMessage("Repetitions"));
                return;
            }
            
            throw new NotImplementedException();
        }

        public void DefineNoSets(object sets)
        {
            if (_validationMethods.IsValidPositiveInteger(sets))
            {
                _sets = Convert.ToInt32(sets);
                return;
            }
            else
            {
                _validationHelper.AddError(_validationMessages.StrictlyPositiveIntegerValMessage("Sets"));
                return;
            }

            throw new NotImplementedException();
        }

        public void DefineWeight(object weight)
        {
            if (_validationMethods.IsValidPositiveNumber(weight))
            {
                _weight = Convert.ToSingle(weight);
                return;
            }
            else
            {
                _validationHelper.AddError(_validationMessages.StrictlyPositiveFloatValMessage("Weight"));
                return;
            }

            throw new NotImplementedException();
        }

        
    }
}
