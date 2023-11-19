using FitnessApp.Core.DataObjects;
using FitnessApp.Core.DataObjects.Requests;
using FitnessApp.Core.Validators;

namespace FitnessApp.Core.ResourceAccess.Interfaces
{
    public interface IExerciseItemResourceAccess
    {
        Task<OperationalResult<List<ExerciseItemDataObject>>> GetAllExerciseItemsAsync();

        Task<OperationalResult<List<ExerciseItemDataObject>>> GetAllExerciseItemsAsync(GetExercisesRequestDataObject getExercisesRequestData);

        Task<OperationalResult<ExerciseItemDataObject>> LogExerciseItemAsync(ExerciseItemDataObject dataObject);

        Task<OperationalResult<ExerciseItemDataObject>> UpdateExerciseItemAsync(ExerciseItemDataObject dataObject);
    }
}