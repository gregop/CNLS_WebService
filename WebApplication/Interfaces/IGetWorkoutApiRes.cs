using FitnessApp.Core.DataObjects;

namespace CNSL_WepService.Interfaces
{
    public interface IGetWorkoutApiRes
    {
        string Status { get; }
        string Message { get; }
        WorkoutItemDataObject WorkoutItem { get; }
        void StatusOK();
        void StatusNOK();
        void SetMessage(string message);
        void SetWorkoutItem(WorkoutItemDataObject workoutItem);
    }
}