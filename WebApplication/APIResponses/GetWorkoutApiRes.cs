using CNSL_WepService.Interfaces;
using FitnessApp.Core.DataObjects;
using System.Text.Json.Serialization;

namespace CNSL_WepService.APIResponses
{
    public class GetWorkoutApiRes : IGetWorkoutApiRes
    {
        private string _status;

        private string? _message;

        private RegisterWorkoutDataObject? _workoutItem;

        public string Status { get { return _status; } }

        public string? Message { get { return _message; } }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public RegisterWorkoutDataObject WorkoutItem { get { return _workoutItem; } set { } }

        public void StatusOK()
        {
            _status = "Success";
            _message = "Success";
        }

        public void StatusNOK()
        {
            _status = "Error";
        }

        public void SetMessage(string message)
        {
            _message = message;
        }

        public void SetWorkoutItem(RegisterWorkoutDataObject workoutItem)
        {
            _workoutItem = workoutItem;
        }
    }

}
