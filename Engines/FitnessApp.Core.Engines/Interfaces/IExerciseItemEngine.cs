using FitnessApp.Core.DataObjects;
using FitnessApp.Core.DataObjects.Requests;
using FitnessApp.Core.Validators;

namespace FitnessApp.Core.Engines.Interfaces
{
    public interface IExerciseItemEngine
    {
        Task<OperationalResult<ExerciseItemDataObject>> HandleExerciseCreationAsync(ExerciseItemDataObject exerciseItemDataObject);
        Task<OperationalResult<List<ExerciseItemDataObject>>> HandleExercisesRequestAsync(GetExercisesRequestDataObject getExercisesRequestData);
    }
}