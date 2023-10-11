using FitnessApp.Core.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Core.ResourceAccess.Models
{
    public class ExerciseSetModel
    {
        [StrictlyPositiveProperty("Id")]
        public int Id { get; set; }

        [StrictlyPositiveProperty("ExerciseHistoryId")]
        public int ExerciseHistoryId { get; set; }

        [StrictlyPositiveProperty("WorkoutId")]
        public int WorkoutId { get; set; }

        [StrictlyPositiveProperty("Reps")]
        public int Reps { get; set; }

        [StrictlyPositiveProperty("Kg")]
        public double Kg { get; set; }

        public DateTime DateCreated { get; set; } 
    }
}
