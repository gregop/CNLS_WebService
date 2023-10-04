using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessApp.Core.Validators;

namespace FitnessApp.Core.DataObjects
{
    public class RegisterWorkoutDataObject
    {
        [StrictlyPositiveProperty("Id")]
        public int Id { get; set; }

        [Required]
        [StrictlyPositiveProperty("duration")]
        public int Duration { get; set; }

        [Required]
        [StrictlyPositiveProperty("distance")]
        public double Distance { get; set; }

        [StrictlyPositiveProperty("calories")]
        public int Calories { get; set; }

        public DateTime Date { get; set; }

        public bool Cardio { get; set; }

        public string? Description { get; set; }

    }


    public class GetWorkoutById
    {
        [Required]
        [StrictlyPositiveProperty("Id")]
        public int Id { get; set; }
    }
}
