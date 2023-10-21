using FitnessApp.Core.DataObjects;
using FitnessApp.Core.ResourceAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Core.ResourceAccess.Mappers
{
    internal static class WorkoutExercisesHistoryModelMapper
    {
        internal static WorkoutExercisesHistoryModel? MapWWorkoutExercisesHistoryDataObjectToModel(WorkoutExercisesHistoryDataObject dataObject)
        {
            try
            {
                if (dataObject == null)
                {
                    return null;
                }

                return new WorkoutExercisesHistoryModel
                {
                    WorkoutId = dataObject.WorkoutId,
                    UserId = dataObject.UserId,
                    ExerciseId = dataObject.ExerciseId,
                    DateCreated = dataObject.DateCreated.ToUniversalTime(),
                };

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return null;
            }

        }

        internal static WorkoutExercisesHistoryDataObject? MapWWorkoutExercisesHistoryModelToDataObject(WorkoutExercisesHistoryModel model)
        {
            try
            {
                if (model == null)
                {
                    return null;
                }

                return new WorkoutExercisesHistoryDataObject
                {
                    Id = model.Id,
                    WorkoutId = model.WorkoutId,
                    UserId = model.UserId,
                    ExerciseId = model.ExerciseId,
                    DateCreated = model.DateCreated.ToUniversalTime(),
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
