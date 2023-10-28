using FitnessApp.Core.DataObjects;
using FitnessApp.Core.ResourceAccess.Models;
using FitnessApp.Core.Validators;
using System.Text.RegularExpressions;

#pragma warning disable IDE0090 // Use 'new(...)'

namespace FitnessApp.Core.ResourceAccess.Mappers
{
    internal static class WorkoutItemModelMapper
    {
        internal static WorkoutItemModel? MapWorkoutItemDataObjectToModel(WorkoutItemDataObject dataObject)
        {
            try
            {
                if (dataObject == null)
                {
                    return null;
                }

                return new WorkoutItemModel
                {
                    WorkoutId = dataObject.WorkoutId,
                    UserId = dataObject.Id,
                    Duration = dataObject.Duration,
                    Distance = dataObject.Distance,
                    Calories = dataObject.Calories,
                    Date = dataObject.Date,
                    Cardio = dataObject.Cardio,
                    Description = dataObject.Description,
            
                };


            } catch (Exception ex) 
            {
                Console.WriteLine(ex.Message.ToString());
                return null;
            }

            
        }

        internal static WorkoutItemDataObject? MapWorkoutItemModelToDataObject(WorkoutItemModel model)
        {
            try
            {
                if (model == null)
                {
                    return null;
                }

                return new WorkoutItemDataObject
                {
                    Id = model.Id,
                    WorkoutId = model.WorkoutId,
                    UserId = model.UserId,
                    Duration = model.Duration,
                    Distance = model.Distance,
                    Calories = model.Calories,
                    Date = model.Date,
                    Cardio = model.Cardio,
                    Description = model.Description,

                };

                
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return null;
            }

            
        }

    }
}
