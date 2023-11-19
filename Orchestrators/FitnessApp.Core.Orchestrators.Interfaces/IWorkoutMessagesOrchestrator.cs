using FitnessApp.Core.DataObjects.Interfaces;
using FitnessApp.Core.Validators;

namespace FitnessApp.Core.Orchestrators.Interfaces
{
    public interface IWorkoutMessagesOrchestrator
    {
        Task<OperationalResult<ResponseContext<IRegisterWorkoutApiRes>>> HandleWorkoutCreationMessagesAsync(string payload);

        Task<OperationalResult<ResponseContext<IGetWorkoutApiRes>>> HandleWorkoutRequestMessagesAsync(string payload);

    }
}