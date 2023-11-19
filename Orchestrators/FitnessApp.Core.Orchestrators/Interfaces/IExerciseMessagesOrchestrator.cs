using FitnessApp.Core.DataObjects;
using FitnessApp.Core.DataObjects.Interfaces;
using FitnessApp.Core.Validators;

namespace FitnessApp.Core.Orchestrators.Interfaces
{
    public interface IExerciseMessagesOrchestrator
    {
        Task<OperationalResult<ResponseContext<ICreateExerciceItemApiRes>>> HandleExerciseCreationMessagesAsync(string payload);
        Task<OperationalResult<ResponseContext<ExerciseItemDataObject>>> HandleExerciseUpdateMessagesAsync(string payload);

        Task<OperationalResult<ResponseContext<IGetExercisesApiRes>>> HandleExerciseRequestMessagesAsync(string payload);
    }
}