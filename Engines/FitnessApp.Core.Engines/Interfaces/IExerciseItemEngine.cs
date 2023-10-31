using FitnessApp.Core.DataObjects;
using FitnessApp.Core.Validators;

namespace FitnessApp.Core.Engines.Interfaces
{
    public interface IExerciseItemEngine
    {
        Task<OperationalResult<ExerciseItemDataObject>> HandleExerciseCreationAsync(ExerciseItemDataObject exerciseItemDataObject);
        Task<OperationalResult<ExerciseItemDataObject>> HandleExerciseRequestAsync(ExerciseItemDataObject exerciseItemDataObject);
    }
}