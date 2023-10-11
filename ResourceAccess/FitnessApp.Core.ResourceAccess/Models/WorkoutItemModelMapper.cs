using FitnessApp.Core.DataObjects;

namespace FitnessApp.Core.ResourceAccess.Models
{
    public class WorkoutItemModelMapper
    {
        public WorkoutItemModelMapper() { }

        public static WorkoutItemModel MapWorkoutItemDataObjectToModel(WorkoutItemDataObject dataObject)
        {
            WorkoutItemModel model = new WorkoutItemModel();

            model.WorkoutId = dataObject.Id;
            model.UserId = dataObject.Id;
            model.Duration = dataObject.Duration;
            model.Distance = dataObject.Distance;
            model.Calories = dataObject.Calories;
            model.Date = dataObject.Date;
            model.Cardio = dataObject.Cardio;
            model.Description = dataObject.Description;

            return model;
        }

        public static WorkoutItemDataObject MapWorkoutItemModelToDataObject(WorkoutItemModel model)
        {
            WorkoutItemDataObject dataObject = new WorkoutItemDataObject();

            dataObject.Id = model.WorkoutId;
            dataObject.WorkoutId = model.Id;
            dataObject.UserId = model.UserId;
            dataObject.Duration = model.Duration;
            dataObject.Distance = model.Distance;
            dataObject.Calories = model.Calories;
            dataObject.Date = model.Date;
            dataObject.Cardio = model.Cardio;
            dataObject.Description = model.Description;

            return dataObject;
        }

    }
}
