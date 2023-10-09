using FitnessApp.Core.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Core.ResourceAccess.Models
{
    public class ExerciseItemHistoryModel
    {
        [StrictlyPositiveProperty("Id")]
        public int Id { get; set; }

        [StrictlyPositiveProperty("WorkoutId")]
        public int WorkoutId { get; set; }

        [StrictlyPositiveProperty("ExerciseId")]
        public int ExerciseId { get; set; }

        public DateTime Date { get; set; }

        public List<ExerciseSetModel> ExerciseSets { get; set; }
    }
}
