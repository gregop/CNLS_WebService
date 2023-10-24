using FitnessApp.Core.DataObjects;
using FitnessApp.Core.Validators;

namespace FitnessApp.Core.ResourceAccess.Interfaces
{
    public interface IExerciseItemResourceAccess
    {
        Task<OperationalResult<List<ExerciseItemDataObject>>> GetAllExerciseItemsAsync();
        Task<OperationalResult<ExerciseItemDataObject>> LogExerciseItemAsync(ExerciseItemDataObject dataObject);
    }
}