using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using FitnessApp.Core.DataObjects.Interfaces;

namespace FitnessApp.Core.DataObjects.APIResponses
{
    public class CreateExerciceItemApiRes : ICreateExerciceItemApiRes
    {
        private string _status;

        private string? _message;

        private ExerciseItemDataObject? _exerciseItem;

        public string Status { get { return _status; } }

        public string? Message { get { return _message; } }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ExerciseItemDataObject ExerciseItem { get { return _exerciseItem; } set { } }

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

        public void SetWorkoutItem(ExerciseItemDataObject exerciseItem)
        {
            _exerciseItem = exerciseItem;
        }
    }
}
