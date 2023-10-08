using System.ComponentModel.DataAnnotations;
using FitnessApp.Core.Validators;

namespace FitnessApp.Core.ResourceAccess.Models
{
    public class WorkoutItemModel
    {
        [StrictlyPositiveProperty("Id")]
        public int Id { get; set; }

        [StrictlyPositiveProperty("WorkoutId")]
        public int WorkoutId { get; set; }

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
