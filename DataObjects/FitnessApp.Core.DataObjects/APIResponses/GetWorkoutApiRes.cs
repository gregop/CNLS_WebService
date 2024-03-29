﻿using FitnessApp.Core.DataObjects;
using FitnessApp.Core.DataObjects.Interfaces;
using System.Text.Json.Serialization;

namespace CNSL_WepService.APIResponses
{
    public class GetWorkoutApiRes : IGetWorkoutApiRes
    {
        private string _status;

        private string? _message;

        private WorkoutItemDataObject? _workoutItem;

        public string Status { get { return _status; } }

        public string? Message { get { return _message; } }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public WorkoutItemDataObject WorkoutItem { get { return _workoutItem; } set { } }

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

        public void SetWorkoutItem(WorkoutItemDataObject workoutItem)
        {
            _workoutItem = workoutItem;
        }

    }

}
