using FitnessApp.Core.DataObjects;
using FitnessApp.Core.DataObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CNSL_WepService.APIResponses
{
    public class RegisterWorkoutApiRes : IRegisterWorkoutApiRes
    {
        private string? _status;

        private string? _message;

        private int _workoutId;

        private int _systemWorkoutId;

        private WorkoutItemDataObject? _workoutObject;

        public string? Status { get { return _status; } }

        public string? Message { get { return _message; } }

        public int WorkoutId { get { return _workoutId; } }

        public int SystemWorkoutId { get { return _workoutObject.Id; } }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public WorkoutItemDataObject? WorkoutObject { get { return _workoutObject; } }
        

        public void StatusOK(int WorkoutId, WorkoutItemDataObject WorkoutObject)
        {
            _status = "Success";
            _message = "Workout Item successfully stored";
            _workoutId = WorkoutId;
            _workoutObject = WorkoutObject;
        }

        public void StatusNOK()
        {
            _status = "Error";
        }

        public void SetMessage(string message)
        {
            _message = message;
        }

    }
}
