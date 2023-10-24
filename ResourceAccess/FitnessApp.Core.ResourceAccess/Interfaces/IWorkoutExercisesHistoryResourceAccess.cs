using FitnessApp.Core.DataObjects;
using FitnessApp.Core.Validators;

namespace FitnessApp.Core.ResourceAccess.Interfaces
{
    public interface IWorkoutExercisesHistoryResourceAccess
    {
        Task<OperationalResult<List<WorkoutExercisesHistoryDataObject>>> GetWorkoutExercisesAsync(WorkoutItemDataObject dataObject);
        Task<OperationalResult<WorkoutExercisesHistoryDataObject>> LogWorkoutExerciseAsync(WorkoutExercisesHistoryDataObject dataObject);
    }
}