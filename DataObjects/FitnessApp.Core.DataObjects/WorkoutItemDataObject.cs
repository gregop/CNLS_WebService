using FitnessApp.Core.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Core.DataObjects
{
    public class WorkoutItemDataObject
    {
        [StrictlyPositiveProperty("Id")]
        public int Id { get; set; }

        [Required]
        [StrictlyPositiveProperty("WorkoutId")]
        public int WorkoutId { get; set; }

        [Required]
        [StrictlyPositiveProperty("UserId")]
        public int UserId { get; set; }

        [Required]
        [StrictlyPositiveProperty("duration")]
        public int Duration { get; set; }

        [Required]
        [StrictlyPositiveProperty("distance")]
        public int Distance { get; set; }

        [StrictlyPositiveProperty("calories")]
        public int Calories { get; set; }

        public DateTime Date { get; set; }

        public bool Cardio { get; set; }

        public string? Description { get; set; }

    }
}
