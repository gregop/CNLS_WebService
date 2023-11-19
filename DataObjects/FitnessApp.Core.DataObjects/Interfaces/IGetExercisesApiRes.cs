namespace FitnessApp.Core.DataObjects.Interfaces
{
    public interface IGetExercisesApiRes
    {
        string? Message { get; }
        string? Status { get; }

        void SetMessage(string message);
        void SetWorkoutItems(List<ExerciseItemDataObject> exerciseItems);
        void SetWorkoutItems(ExerciseItemDataObject exerciseItems);
        void StatusNOK();
        void StatusOK();
    }
}