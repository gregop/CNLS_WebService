using FitnessApp.Core.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Core.DataObjects
{
    public class WorkoutExercisesHistoryDataObject
    {
        [StrictlyPositiveProperty("Id")]
        public int Id { get; set; }

        [StrictlyPositiveProperty("WorkoutId")]
        public int WorkoutId { get; set; }

        [StrictlyPositiveProperty("UserId")]
        public int UserId { get; set; }

        [StrictlyPositiveProperty("ExerciseId")]
        public int ExerciseId { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
