using FitnessApp.Core.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Core.DataObjects
{
    public class ExerciseSetDataObject
    {
        [StrictlyPositiveProperty("Id")]
        public int Id { get; set; }

        [StrictlyPositiveProperty("ExerciseHistoryId")]
        public int WorkoutExerciseHistoryId { get; set; }

        [StrictlyPositiveProperty("WorkoutId")]
        public int WorkoutId { get; set; }

        [StrictlyPositiveProperty("ExerciseId")]
        public int ExerciseId { get; set; }

        [StrictlyPositiveProperty("Reps")]
        public int Reps { get; set; }

        [StrictlyPositiveProperty("Kg")]
        public double Kg { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
