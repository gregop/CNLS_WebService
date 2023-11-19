using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using FitnessApp.Core.DataObjects.Interfaces;

namespace FitnessApp.Core.DataObjects.APIResponses
{
    public class GetExercisesApiRes : IGetExercisesApiRes
    {
        private string? _status;

        private string? _message;

        private List<ExerciseItemDataObject>? _exerciseItems;

        public string? Status { get { return _status; } }

        public string? Message { get { return _message; } }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<ExerciseItemDataObject>? ExerciseItems { get { return _exerciseItems; } set { } }

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

        public void SetWorkoutItems(List<ExerciseItemDataObject> exerciseItems)
        {
            _exerciseItems = exerciseItems;
        }

        public void SetWorkoutItems(ExerciseItemDataObject exerciseItems)
        {
            _exerciseItems = new List<ExerciseItemDataObject>
            {
                exerciseItems
            };
        }
    }
}
