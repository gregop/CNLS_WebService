using FitnessApp.Core.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Core.ResourceAccess.Models
{
    public class ExerciseItemModel
    {
        [StrictlyPositiveProperty("Id")]
        public int Id { get; set; }

        [Required]
        public string? ExerciseName { get; set; }

        [Required]
        public string? ExerciseUrl { get; set; }

        public int ExerciseType { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
