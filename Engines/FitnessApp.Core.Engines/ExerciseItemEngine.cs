using FitnessApp.Core.DataObjects;
using FitnessApp.Core.DataObjects.Requests;
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
        private readonly IExerciseTypeResourceAccess _exerciseTypeResourceAccess;

        public ExerciseItemEngine(
            IExerciseItemResourceAccess exerciseItemResourceAccess,
            IExerciseTypeResourceAccess exerciseTypeResourceAccess)
        {
            _exerciseItemResourceAccess = exerciseItemResourceAccess;
            _exerciseTypeResourceAccess = exerciseTypeResourceAccess;
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
                    return OperationalResult<ExerciseItemDataObject>.FailureResult("Cannot log null object");
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return OperationalResult<ExerciseItemDataObject>.FailureResult(ex);
            }
        }

        public async Task<OperationalResult<List<ExerciseItemDataObject>>> HandleExercisesRequestAsync(GetExercisesRequestDataObject getExercisesRequestData)
        {
            try
            {
                if (getExercisesRequestData != null)
                {

                    // Map Exercise Type to Exercise Type Id - to be implemented
                    OperationalResult<List<ExerciseTypeDataObject>> exerciseTypes = await _exerciseTypeResourceAccess.GetAllExerciseTypesAsync();

                    if (exerciseTypes.IsSuccessfulOperation && exerciseTypes.Data != null)
                    {
                        // Map Exercise Type
                        foreach (ExerciseTypeDataObject exerciseType in exerciseTypes.Data)
                        {
                            if (getExercisesRequestData.ExerciseType.ToUpper() == exerciseType.TypeName.ToUpper())
                            {
                                getExercisesRequestData.SetExerciseId(exerciseType.Id);
                            }
                        }
                    }


                    switch (getExercisesRequestData.ExerciseTypeId)
                    {
                        case null:
                            return await _exerciseItemResourceAccess.GetAllExerciseItemsAsync();

                        case ( > 0):
                            return await _exerciseItemResourceAccess.GetAllExerciseItemsAsync(getExercisesRequestData);

                        default:
                            return await _exerciseItemResourceAccess.GetAllExerciseItemsAsync();
                            
                    }
                
                }
                else
                {
                    return OperationalResult<List<ExerciseItemDataObject>>.FailureResult("Null object request");
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return OperationalResult<List<ExerciseItemDataObject>>.FailureResult(ex);
            }
        }
    }
}
