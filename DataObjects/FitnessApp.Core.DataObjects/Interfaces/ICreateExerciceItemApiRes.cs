namespace FitnessApp.Core.DataObjects.Interfaces
{
    public interface ICreateExerciceItemApiRes
    {
        string? Message { get; }
        string Status { get; }

        ExerciseItemDataObject ExerciseItem { get; set; }

        void SetMessage(string message);
        void SetWorkoutItem(ExerciseItemDataObject exerciseItem);
        void StatusNOK();
        void StatusOK(ExerciseItemDataObject ExerciseObject);
    }
}