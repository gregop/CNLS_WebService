using FitnessApp.Core.DataObjects;
using FitnessApp.Core.Validators;

namespace FitnessApp.Core.Engines.Interfaces
{
    public interface IWorkoutItemEngine
    {
        Task<OperationalResult<WorkoutItemDataObject>> HandleWorkoutCreationAsync(WorkoutItemDataObject workoutItemDataObject);
    }
}