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

        public int ExerciseHistoryId { get; set; }

        [StrictlyPositiveProperty("Id")]
        public int Reps { get; set; }

        [StrictlyPositiveProperty("Id")]
        public double Kg { get; set; }
    }
}
