using FitnessApp.Core.DataObjects;
using FitnessApp.Core.Validators;

namespace FitnessApp.Core.ResourceAccess.Interfaces
{
    public interface IWorkoutItemResourceAccess
    {
        Task<OperationalResult<WorkoutItemDataObject>> GetWorkoutItemAsync(WorkoutItemDataObject dataObject);
        Task<OperationalResult<WorkoutItemDataObject>> LogWorkoutItemAsync(WorkoutItemDataObject dataObject);
        Task<OperationalResult<WorkoutItemDataObject>> UpdateWorkoutItemAsync(WorkoutItemDataObject dataObject);
    }
}