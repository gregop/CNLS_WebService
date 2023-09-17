using CNSL_WepService.Interfaces;
using CNSL_WepService.Models;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNSL_WepService.APIResponses
{
    public class GetWorkoutApiRes : IGetWorkoutApiRes
    {
        private string? _status;

        private string? _message;

        private WorkoutItemModel? _workoutItem;

        public string? Status { get { return _status; } }

        public string? Message { get { return _message; } }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public WorkoutItemModel WorkoutItem { get { return _workoutItem; } set { } }

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

        public void SetWorkoutItem(WorkoutItemModel workoutItem)
        {
            _workoutItem = workoutItem;
        }
    }

}
