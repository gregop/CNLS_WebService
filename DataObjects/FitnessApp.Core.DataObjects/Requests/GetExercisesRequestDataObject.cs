using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Core.DataObjects.Requests
{
    public class GetExercisesRequestDataObject
    {
        private int? _exerciseTypeId;

        public string ExerciseType { get; set; } = string.Empty;

        public int? ExerciseTypeId { get { return _exerciseTypeId;  } }

        public void SetExerciseId(int exerciseTypeId)
        {
            _exerciseTypeId = exerciseTypeId;
        }
    }
}
