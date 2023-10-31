using FitnessApp.Core.DataObjects;
using FitnessApp.Core.Validators;

namespace FitnessApp.Core.Orchestrators.Interfaces
{
    public interface IExerciseMessagesOrchestrator
    {
        Task<OperationalResult<ExerciseItemDataObject>> HandleExerciseCreationMessagesAsync(string payload);
        Task<OperationalResult<ExerciseItemDataObject>> HandleExerciseUpdateMessagesAsync(string payload);
    }
}