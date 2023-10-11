using FitnessApp.Core.DataObjects;
using FitnessApp.Core.ResourceAccess.Models;
using FitnessApp.Core.Validators;

#pragma warning disable IDE0017 // Simplify object initialization
#pragma warning disable IDE0090 // Use 'new(...)'

namespace FitnessApp.Core.ResourceAccess.Mappers
{
    public class WorkoutItemModelMapper
    {
        public WorkoutItemModelMapper() { }

        public static OperationalResult<WorkoutItemModel> MapWorkoutItemDataObjectToModel(WorkoutItemDataObject dataObject)
        {
            try
            {
                WorkoutItemModel model = new WorkoutItemModel
                {
                    WorkoutId = dataObject.Id,
                    UserId = dataObject.Id,
                    Duration = dataObject.Duration,
                    Distance = dataObject.Distance,
                    Calories = dataObject.Calories,
                    Date = dataObject.Date,
                    Cardio = dataObject.Cardio,
                    Description = dataObject.Description,
            
                };

                return OperationalResult<WorkoutItemModel>.SuccessResult(model);


            } catch (Exception ex) 
            {
                Console.WriteLine(ex.Message.ToString());
                return OperationalResult<WorkoutItemModel>.FailureResult(ex);
            }

            
        }

        public static OperationalResult<WorkoutItemDataObject> MapWorkoutItemModelToDataObject(WorkoutItemModel model)
        {
            try
            {
                WorkoutItemDataObject dataObject = new WorkoutItemDataObject
                {
                    Id = model.WorkoutId,
                    WorkoutId = model.Id,
                    UserId = model.UserId,
                    Duration = model.Duration,
                    Distance = model.Distance,
                    Calories = model.Calories,
                    Date = model.Date,
                    Cardio = model.Cardio,
                    Description = model.Description,

                };

                return OperationalResult<WorkoutItemDataObject>.SuccessResult(dataObject);


            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return OperationalResult<WorkoutItemDataObject>.FailureResult(ex);
            }

            
        }

    }
}
