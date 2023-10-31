using FitnessApp.Core.DataObjects;
using FitnessApp.Core.Engines.Interfaces;
using FitnessApp.Core.ResourceAccess.Interfaces;
using FitnessApp.Core.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Core.Engines
{
    public class ExerciseItemEngine : IExerciseItemEngine
    {
        private readonly IExerciseItemResourceAccess _exerciseItemResourceAccess;

        public ExerciseItemEngine(IExerciseItemResourceAccess exerciseItemResourceAccess)
        {
            _exerciseItemResourceAccess = exerciseItemResourceAccess;
        }

        public async Task<OperationalResult<ExerciseItemDataObject>> HandleExerciseCreationAsync(ExerciseItemDataObject exerciseItemDataObject)
        {
            try
            {
                if (exerciseItemDataObject != null) 
                {

                    exerciseItemDataObject.DateCreated = DateTime.UtcNow;
                    return await _exerciseItemResourceAccess.LogExerciseItemAsync(exerciseItemDataObject);

                }
                else
                {
                    return OperationalResult<ExerciseItemDataObject>.SuccessResult(null);
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return OperationalResult<ExerciseItemDataObject>.FailureResult(ex);
            }
        }

        public async Task<OperationalResult<ExerciseItemDataObject>> HandleExerciseRequestAsync(ExerciseItemDataObject exerciseItemDataObject)
        {
            throw new NotImplementedException();
        }
    }
}
