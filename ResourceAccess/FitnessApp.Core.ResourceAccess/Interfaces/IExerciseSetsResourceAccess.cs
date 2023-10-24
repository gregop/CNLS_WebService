using FitnessApp.Core.DataObjects;
using FitnessApp.Core.Validators;

namespace FitnessApp.Core.ResourceAccess
{
    public interface IExerciseSetsResourceAccess
    {
        Task<OperationalResult<ExerciseSetDataObject>> LogExerciseSetAsync(ExerciseSetDataObject dataObject);
        Task<OperationalResult<ExerciseSetDataObject>> UpdateExerciseSetAsync(ExerciseSetDataObject dataObject);
    }
}