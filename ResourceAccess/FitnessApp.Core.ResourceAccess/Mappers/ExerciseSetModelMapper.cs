using FitnessApp.Core.DataObjects;
using FitnessApp.Core.ResourceAccess.Models;


namespace FitnessApp.Core.ResourceAccess.Mappers
{
    internal static class ExerciseSetModelMapper
    {
        internal static ExerciseSetModel? MapExerciseSetDataObjectToModel(ExerciseSetDataObject dataObject)
        {
            try
            {
                if (dataObject == null)
                {
                    return null;
                }

                return new ExerciseSetModel
                {
                    WorkoutExerciseHistoryId = dataObject.WorkoutExerciseHistoryId,
                    WorkoutId = dataObject.WorkoutId,
                    ExerciseId = dataObject.ExerciseId,
                    Reps = dataObject.Reps,
                    Kg = dataObject.Kg,
                    DateCreated = dataObject.DateCreated,
                };

            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message.ToString());
                return null;
            }

        }

        internal static ExerciseSetDataObject? MapExerciseSetModelToDataObject(ExerciseSetModel model)
        {
            try
            {
                if (model == null)
                {
                    return null;
                }

                return new ExerciseSetDataObject
                {
                    Id = model.Id,
                    WorkoutExerciseHistoryId = model.WorkoutExerciseHistoryId,
                    WorkoutId = model.WorkoutId,
                    ExerciseId = model.ExerciseId,
                    Reps = model.Reps,
                    Kg = model.Kg,
                    DateCreated = model.DateCreated,
                };

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return null;
            }

        }
    }
}
