using CNSL_WepService.Interfaces;
using CNSL_WepService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CNSL_WepService.APIResponses
{
    public class RegisterWorkoutAPIResponse : IApiResponse
    {
        private string? _status;

        private string? _message;

        public string? Status { get { return _status; } set { } }

        public string? Message { get { return _message; } set { } }


        public void StatusOK()
        {
            _status = "Success";
            _message = "Workout Item successfully stored";
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
            return;
        }

    }
}
